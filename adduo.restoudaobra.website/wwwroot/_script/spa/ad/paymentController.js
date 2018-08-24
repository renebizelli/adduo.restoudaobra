ROApp.controller('paymentController', ['$scope', 'baseFactory', function ($scope, baseFactory) {

    $scope.ok = function () {
        $scope.helper.redirect('/meus-anuncios');
    }

}]);

