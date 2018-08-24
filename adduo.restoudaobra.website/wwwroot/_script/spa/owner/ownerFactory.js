ROApp.factory('ownerFactory', ['baseFactory', function (baseFactory) {

    var _createRequest = function (dto, culture) {
        var baserequest = baseFactory.helper.createRequest(dto, culture, true);
        return baserequest;
    }


    var _createOwner = function () {

        var dto = {
            token: ''
        };

        baseFactory.helper.addProperty('cpf', '', dto);
        baseFactory.helper.addProperty('firstname', '', dto);
        baseFactory.helper.addProperty('lastname', '', dto);
        baseFactory.helper.addProperty('email', '', dto);
        baseFactory.helper.addProperty('emailconfirm', '', dto);
        baseFactory.helper.addProperty('phone', '', dto);
        baseFactory.helper.addProperty('cellphone', '', dto);
        baseFactory.helper.addProperty('password', '', dto);
        baseFactory.helper.addProperty('passwordconfirm', '', dto);

        return dto;
    }


    var _createLogin = function () {

        var dto = {};

        baseFactory.helper.addProperty('email', '', dto);
        baseFactory.helper.addProperty('password', '', dto);

        return dto;
    }


    var _createResetPasswordSolicitation = function () {

        var dto = {
            ofuscated: ''
        };

        baseFactory.helper.addProperty('cpfemail', '', dto);

        return dto;
    }

    var _createResetPasswordChange = function () {

        var dto = {
        };

        baseFactory.helper.addProperty('password', '', dto);
        baseFactory.helper.addProperty('confirmation', '', dto);

        return dto;
    }


    var _factory = {
        helper: {
            createRequest: _createRequest,
            createOwner: _createOwner,
            createLogin: _createLogin,
            createResetPasswordSolicitation: _createResetPasswordSolicitation,
            createResetPasswordChange: _createResetPasswordChange
        }
    };

    return _factory;
}]);
