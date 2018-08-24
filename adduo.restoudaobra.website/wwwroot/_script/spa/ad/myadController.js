ROApp.controller('myadController', ['$scope', 'adService', function ($scope, adService) {

    $scope.products = [];

    $scope.dto = {
        ads: {},
        status: []
    };

}]);


ROApp.controller('myadListController', ['$scope', 'baseFactory', 'adService', 'adFactory', '$timeout', function ($scope, baseFactory, adService, adFactory, $timeout) {

    $scope.statusSelected = {};

    var loaderget = 'myad-get'
    var loaderabastatus = 'myad-aba-status'
    var loadercommands = [];

    $scope.event.filterProduct = function (status) {

        $timeout(function () {
            $scope.statusSelected = status;
            $scope.ads = $scope.dto.ads[status.name];
            $scope.loaderStop(loaderabastatus);

        }, 500);

        $scope.loaderStart(loaderabastatus);
    }

    $scope.showPublished = function () {
        return adFactory.helper.isStatusPaused($scope.statusSelected.id);
    }

    $scope.showFinished = function () {
        return adFactory.helper.isStatusPublished($scope.statusSelected.id) ||
            adFactory.helper.isStatusPaused($scope.statusSelected.id);
    }

    $scope.showPaused = function () {
        return adFactory.helper.isStatusPublished($scope.statusSelected.id);
    }

    $scope.showEdit = function () {
        return adFactory.helper.isStatusPublished($scope.statusSelected.id) ||
            adFactory.helper.isStatusPaused($scope.statusSelected.id);
    }

    $scope.helper.productTypeSale = function (product) {
        return adFactory.helper.productTypeSale(product);
    }

    $scope.helper.productTypeDonation = function (product) {
        return adFactory.helper.productTypeDonation(product);
    }

    $scope.helper.statusSelected = function (status, _class) {
        return status === $scope.statusSelected ? _class : '';
    }

    $scope.editRedirect = function (url) {
        location.href = url;
    }

    var changeStatus = function (dto, card) {

        $scope.loaderStart(loadercommands[card.product.guid]);

        adService.changeStatus(dto)
            .success(function (response) {

                var index = $scope.ads.indexOf(card);

                $scope.ads.splice(index, 1);

                var status = $scope.dto.status.filter(function (s) { return s.id === dto.status });

                if (status.length) {
                    card.product.status = dto.status;
                    $scope.dto.ads[status[0].name].push(card);
                }

            })
            .error(function (err, status) {
                baseFactory.http.httpStatusAction(status);
            })
            .finally(function () {
                $scope.loaderStop(loadercommands[card.product.guid]);
            });
    }

    $scope.changeStatusPaused = function (card) {
        var dto = adFactory.helper.createChangeStatusPausedDTO(card.product)
        changeStatus(dto, card);
    }

    $scope.changeStatusPublished = function (card) {
        var dto = adFactory.helper.createChangeStatusPublishedDTO(card.product)
        changeStatus(dto, card);
    }

    $scope.changeStatusFinished = function (card) {

        if (confirm('Deseja realmente finalizar o anúncio ' + card.product.name.toUpperCase() + '?')) {
            var dto = adFactory.helper.createChangeStatusFinishedDTO(card.product)
            changeStatus(dto, card);
        }
    }

    $scope.init = function () {

        $scope.loaderStart(loaderget);

        adService.list()
            .success(function (response) {

                $scope.dto.ads = response.dto.ads;
                $scope.dto.status = response.dto.status;

                if ($scope.dto.status && $scope.dto.status.length) {

                    for (var i = 0; i < $scope.dto.status.length; i++) {
                        if (!$scope.dto.ads[$scope.dto.status[i].name]) {
                            $scope.dto.ads[$scope.dto.status[i].name] = [];
                        }
                    }

                    $scope.statusSelected = $scope.dto.status[0];

                    $scope.ads = $scope.dto.ads[$scope.dto.status[0].name];
                }

                for (var c = 0; c < $scope.dto.ads.length; c++) {
                    loadercommands.push($scope.dto.ads[c].product.guid);
                }

            })
            .error(function (err, status) {
                baseFactory.http.httpStatusAction(status);
            })
            .finally(function () {
                $scope.loaderStop(loaderget);
            });
    }

    $scope.init();

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loaderget);
    }

    $scope.loaderAbaStatusChangeActivity = function () {
        return $scope.$parent.loaderActivity(loaderabastatus);
    }

    $scope.loaderCommandsActivity = function (card) {
        return $scope.$parent.loaderActivity(loadercommands[card.product.guid]);
    }

}]);

