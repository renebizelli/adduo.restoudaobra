ROApp.service('adService', ['$http', 'adFactory', function ($http, adFactory) {



    this.list = function () {
        return $http.get('/api/product/list');
    }


}]);