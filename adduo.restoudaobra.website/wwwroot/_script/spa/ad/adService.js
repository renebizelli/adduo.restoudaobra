ROApp.service('adService', ['$http', 'adFactory', function ($http, adFactory) {

    this.save = function (product) {

        var request = adFactory.helper.createRequest(product);

        return $http.post('/api/ad/register', request);
    }

    this.getGuid = function () {

        return $http.get('/api/ad/getguid');
    }

    this.list = function () {
        return $http.get('/api/ad/list');
    }

    this.get = function (guid) {
        return $http.get('/api/ad/get?guid=' + guid);
    }

    this.detail = function (guid) {
        return $http.get('/api/ad/detail?guid=' + guid);
    }


    this.changeStatus = function (dto) {
        var request = adFactory.helper.createRequest(dto);
        return $http.post('/api/ad/changestatus', request);
    }


}]);