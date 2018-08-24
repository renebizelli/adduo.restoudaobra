ROApp.controller('adController', ['$compile', '$scope', '$routeParams', 'baseFactory', function ($compile, $scope, $routeParams, baseFactory) {

    $scope.helper.loader.show();

    $scope.helper.form.success = false;

    $scope.productRegisterFactory = $compile('<product-register dto="dto" completed="event.registerCompleted" fallback="fallback"></product-register>');

    $scope.addProductRegisterDirective = function (scope) {
        var productRegister = $scope.productRegisterFactory(scope);
        var container = document.getElementById('product-register-container');
        angular.element(container).append(productRegister);
    }

    $scope.event.error = function (err, status) {
        $scope.helper.form.showError(err);
        baseFactory.http.httpStatusAction(status);
    }

    $scope.fallback = function (err, status) {
        $scope.helper.form.showError(err);
    }

}]);

ROApp.controller('adTypeDonationController', ['$scope', 'adFactory', 'adService', 'baseFactory', function ($scope, adFactory, adService, baseFactory) {

    $scope.dto = adFactory.helper.createProductDonation();

    adService.getGuid()
        .success(function (response) {

            $scope.dto.product.guid = response.dto.guid;

            $scope.addProductRegisterDirective($scope);

        })
        .error(function (err, status) {
            baseFactory.http.httpStatusAction(status);
            $scope.event.error(err, status);
        });


    $scope.event.registerCompleted = function (product) {
        $scope.scrollTo();

        $scope.helper.form.success = true;
    }

}]);

ROApp.controller('adTypeSaleController', ['$scope', 'adFactory', 'adService', 'baseFactory', function ($scope, adFactory, adService, baseFactory) {

    $scope.dto = adFactory.helper.createProductSale();

    adService.getGuid()
        .success(function (response) {
            $scope.dto.product.guid = response.dto.guid;
            $scope.addProductRegisterDirective($scope);
        })
        .error(function (err, status) {
            baseFactory.http.httpStatusAction(status);
            $scope.event.error(err, status);

        });

    $scope.event.registerCompleted = function (product) {
        $scope.helper.redirect('/quero-vender/pagamento');
    }

}]);

ROApp.controller('adEditController', ['$scope', '$routeParams', 'adFactory', 'adService', 'baseFactory', function ($scope, $routeParams, adFactory, adService, baseFactory) {

    $scope.dto = {};

    var loadername = 'ad-edit';

    if ($routeParams.id) {

        $scope.loaderStart(loadername);

        adService.get($routeParams.id)
            .success(function (response) {

                $scope.dto = response.dto;

                $scope.addProductRegisterDirective($scope);
            })
            .error(function (err, status) {
                baseFactory.http.httpStatusAction(status);
                $scope.event.error(err, status);
            })
            .finally(function () {
                $scope.loaderStop(loadername);
            });
    }

    $scope.event.registerCompleted = function (product) {
        $scope.helper.redirect('/meus-anuncios');
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }

}]);

ROApp.controller('adDetailController', ['$scope', 'adService', 'adFactory', 'baseFactory', '$routeParams', function ($scope, adService, adFactory, baseFactory, $routeParams) {

    $scope.ad = {
        images: []
    };

    $scope.show = false;

    $scope.phones = [];
    $scope.emailAndText = 'clique para ver os contatos';
    $scope.contactVisible = false;

    var loadername = 'ad-detail';

    $scope.gallery = {
        rows: []
    };

    $scope.loaderStart(loadername);

    adService.detail($routeParams.guid)
        .success(function (response) {
            $scope.ad = response.dto;

            $scope.setImagesConfig();
            $scope.prepare();
            $scope.setDetailTitle();

            $scope.show = true;
        })
        .error(function (err, status) {
            baseFactory.http.httpStatusAction(status);
            $scope.event.error(err, status);
        })
        .finally(function () {
            $scope.loaderStop(loadername);
        });

    $scope.carouselOpen = function (index) {
        $scope.$broadcast('open', { index: index });
    }


    $scope.galleryWidth = function (imageWidth, spaceWidth) {

        var length = $scope.ad.images.length;

        return (length == 3 || length >= 5) ? (3 * imageWidth) + (spaceWidth * 2) :
            ((length == 2 || length == 4) ? 2 * imageWidth + (spaceWidth) :
                imageWidth);
    }

    $scope.showContact = function () {

        $scope.contactVisible = true;

        $scope.phones = [];

        $scope.emailAndText = $scope.ad.owner.email;

        if ($scope.ad.owner.phone) {
            $scope.phones.push($scope.ad.owner.phone);
        }

        if ($scope.ad.owner.cellphone) {
            $scope.phones.push($scope.ad.owner.cellphone);
        }
    }

    $scope.prepare = function () {
        var quantity = $scope.ad.product.quantity;
        if (!isNaN(quantity)) {
            $scope.ad.product.quantity = quantity + (parseInt(quantity) == 1 ? ' unidade' : ' unidades');
        }
    }

    $scope.setDetailTitle = function () {
        $scope.setTitle($scope.ad.product.name + ' - Restou da Obra');
    }

    $scope.setImagesConfig = function () {

        var length = $scope.ad.images.length;
        var images = $scope.ad.images;
        var column = (length == 1 || length == 2 || length == 4) ? 2 : 3;

        var l = 0;
        var index = 0;
        while (l <= length) {
            var row = [];
            for (var i = 0; i < column; i++) {
                if (!images[l]) { break; }
                row.push({ img: images[l++], index: index++ });
            }
            $scope.gallery.rows.push(row);

            if (!images[l]) { break; }
        }
    }

    $scope.productTypeDonation = function () {
        return adFactory.helper.productTypeDonation($scope.ad.product);
    }

    $scope.productTypeSale = function () {
        return adFactory.helper.productTypeSale($scope.ad.product);
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }

}]);

ROApp.controller('adDetailCarouselController', ['$scope', function ($scope) {

    var index = 0;
    $scope.visible = false;
    var image = {};

    var images = [];

    $scope.$on('esc-trigger', function (evt, data) {
        $scope.close();
        $scope.$apply();
    });

    $scope.$on('open', function (event, data) {

        images = $scope.$parent.ad.images;

        open(data.index);
    });

    var getImage = function (i) {

        if (images[i]) {
            image = images[i];
            index = i;
        }
    }

    $scope.close = function () {
        $scope.visible = false;
    }

    var open = function (i) {
        index = i;
        $scope.visible = true;
        getImage(i);
    }

    $scope.previous = function () {
        getImage(index - 1);

    }

    $scope.next = function () {
        getImage(index + 1);
    }

    $scope.selected = function () {
        return image;
    }

    $scope.previousShow = function () {
        return index > 0;
    }

    $scope.nextShow = function () {
        return index < (images.length - 1);
    }

}]);


