ROApp.factory('searchFactory', ['baseFactory', function (baseFactory) {

    var _createRequest = function (_term, culture) {

        var baserequest = baseFactory.helper.createRequest(culture);

        baserequest['dto'] = {
            term: _term
        };

        return baserequest;
    }



    var _factory = {
        helper : {
            createRequest: _createRequest
        }
    };

    return _factory;


}]);
