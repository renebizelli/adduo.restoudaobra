
ROApp.controller('contactController', ['$scope', 'contactFactory', 'contactService', function ($scope, contactFactory, contactService) {

    $scope.dto = contactFactory.helper.createContact();

    $scope.control.page.success = false;

    var loadername = 'loader-contact'

    $scope.event.send = function () {

        $scope.loaderStart(loadername);

        contactService.send($scope.dto)
            .success(function (response) {

                $scope.control.page.success = response.success;
            })
            .error(function (err, status) {
                $scope.helper.form.showError(err);

                if (err && err.dto) {
                    $scope.dto = err.dto;
                }
            })
            .finally(function () {
                $scope.scrollTo();
                $scope.loaderStop(loadername);
            });
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }
}]);