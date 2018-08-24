ROApp.service('productImageService', ['$http', 'adFactory', function ($http, adFactory) {

    this.delete = function (id) {

        return $http.delete('/api/productimage?id=' + id);
    }

}]);