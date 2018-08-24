ROApp.service('addressService', ['$http', 'adFactory', function ($http, adFactory) {

    this.list = function () {

        var request = adFactory.helper.createRequest(product);

        return $http.get('/api/address/list', {});
    }

}]);