ROApp.factory('contactFactory', ['baseFactory', function (baseFactory) {

    var _createRequest = function (dto, culture) {
        var baserequest = baseFactory.helper.createRequest(dto, culture, true);
        return baserequest;
    }


    var _createContact = function () {

        var dto = {
        };

        baseFactory.helper.addProperty('name', '', dto);
        baseFactory.helper.addProperty('email', '', dto);
        baseFactory.helper.addProperty('phone', '', dto);
        baseFactory.helper.addProperty('message', '', dto);

        return dto;
    }

    var _factory = {
        helper: {
            createRequest: _createRequest,
            createContact: _createContact,
        }
    };

    return _factory;
}]);
