ROApp.factory('baseFactory', ['$location', 'authFactory', function ($location, authFactory) {

    var _createRequest = function (dto, culture, autocloseloader) {
        return {
            culture: culture || 'pt-br',
            autocloseloader: autocloseloader || false,
            dto: dto || {}
        };
    }

    var _statusProperty = {
        none: 0,
        invalid: 1,
        valid: 2
    }

    var _addProperty = function (name, _value, entity) {
        entity[name] = {
            prop: true,
            value: _value,
            status: _statusProperty.none,
            defaultvalue: _value,
            code: '',
            format: '',
            edit: false,
            maxlength: 0
        };
    }

    var _addPropertyList = function (name, _value, entity) {

        var array = [];

        if (Array.isArray && _value && Array.isArray(_value)) {
            array = _value;
        }

        entity[name] = {
            list: array,
            status: _statusProperty.none,
            listdefault: array,
            code: ''
        };
    }

    var _clearFields = function (dto) {
        for (field in dto) {
            dto[field].value = dto[field].defaultvalue;
            dto[field].status = _statusProperty.none;
        }
    }

    var _statusInvalid = function (prop) {
        return prop.status == _statusProperty.invalid;
    }

    var _statusValid = function (prop) {
        return prop.status == _statusProperty.valid;
    }

    var _statusClass = function (prop, classValid, classInvalid) {

        var _class = '';

        if (_statusInvalid(prop)) {
            _class = classInvalid;
        }
        else if (_statusValid(prop)) {
            _class = classValid;
        }

        return _class;
    }

    var _checkEmpty = function (value) {
        return value && value != '';
    }

    var _states =
        [
            { id: 1, code: 'AC', name: 'Acre' },
            { id: 2, code: 'AL', name: 'Alagoas' },
            { id: 3, code: 'AP', name: 'Amapá' },
            { id: 4, code: 'AM', name: 'Amazonas' },
            { id: 5, code: 'BA', name: 'Bahia' },
            { id: 6, code: 'CE', name: 'Ceará' },
            { id: 7, code: 'DF', name: 'Distrito Federal' },
            { id: 8, code: 'ES', name: 'Espírito Santo' },
            { id: 9, code: 'GO', name: 'Goiás' },
            { id: 10, code: 'MA', name: 'Maranhão' },
            { id: 11, code: 'MT', name: 'Mato Grosso' },
            { id: 12, code: 'MS', name: 'Mato Grosso do Sul' },
            { id: 13, code: 'MG', name: 'Minas Gerais' },
            { id: 14, code: 'PA', name: 'Pará' },
            { id: 15, code: 'PB', name: 'Paraíba' },
            { id: 16, code: 'PR', name: 'Paraná' },
            { id: 17, code: 'PE', name: 'Pernambuco' },
            { id: 18, code: 'PI', name: 'Piauí' },
            { id: 19, code: 'RJ', name: 'Rio de Janeiro' },
            { id: 20, code: 'RN', name: 'Rio Grande do Norte' },
            { id: 21, code: 'RS', name: 'Rio Grande do Sul' },
            { id: 22, code: 'RO', name: 'Rondônia' },
            { id: 23, code: 'RR', name: 'Roraima' },
            { id: 24, code: 'SC', name: 'Santa Catarina' },
            { id: 25, code: 'SP', name: 'São Paulo' },
            { id: 26, code: 'SE', name: 'Sergipe' },
            { id: 27, code: 'TO', name: 'Tocantins' }
        ];

    var _httpstatus = {
        Unauthorized: 401,
        Badrequest: 400,
        Ok: 200,
        InternalError: 500
    }

    var _httpStatusAction = function (status) {
        if (status == _httpstatus.Unauthorized) {
            console.log('Não esta logado');
            authFactory.logout();
        }
    }

    var _httpStatusIsBadrequest = function (status) {
        return status == _httpstatus.Badrequest;
    }

    var _factory = {
        helper: {
            addProperty: _addProperty,
            addPropertyList: _addPropertyList,
            clearFields: _clearFields,
            statusInvalid: _statusInvalid,
            statusValid: _statusValid,
            statusClass: _statusClass,
            createRequest: _createRequest,
            checkEmpty: _checkEmpty
        },
        http: {
            httpStatusAction: _httpStatusAction
        },
        data: {
            statusProperty: _statusProperty,
            states: _states
        }
    };

    return _factory;

}]);


ROApp.factory('httpFactory', ['$http', function ($http) {

    var host = 'http://localhost:5000/'

    var _post = function (url, request) {
        return $http.post(host + url, request);
    }

    var _get = function (query) {
        return $http._get(host + query);
    }

    return {
        post: _post,
        get: _get
    }

}]);


