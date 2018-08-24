ROApp.factory('authFactory', ['$location', '$cookies', function ($location, $cookies) {

    var cookiename = "authentication";

    var path;

    var _pathDefault = function () {
        path = '/'
    }

    _pathDefault();

    var cookieAuthentication = $cookies.getObject(cookiename);

    var _isAuthenticated = function () {
        return cookieAuthentication && cookieAuthentication.token.access_token != '';
    }

    var redirect = function () {
        if (_isAuthenticated()) {
            if (path != '/') {
                $location.path(path);
            }
            else if ($location.url() == '/identificacao'){
                $location.path('/');
            }
        }
    }

    var _authenticated = function (dto) {

        if (dto && dto.token && dto.token.access_token) {

            $cookies.putObject(cookiename, dto);

            cookieAuthentication = dto;

            redirect();
        }
    }

    var _redirectToLogin = function (_path) {
        path = _path;
        $location.path('/identificacao');
    }

    var _verifyAuthentication = function (currRoute) {
        if (currRoute && currRoute.restrict && !_isAuthenticated()) {
            _redirectToLogin(currRoute.originalPath);
        }
    }


    var _logout = function () {

        _pathDefault();

        $cookies.remove(cookiename);

        cookieAuthentication = null;

        _pathDefault();

        _redirectToLogin(path);
    }

    var _getName = function () {
        return cookieAuthentication ? cookieAuthentication.name : '';
    }

    var _getToken = function () {
        return cookieAuthentication ? cookieAuthentication.token.access_token : '';
    }

    if (cookieAuthentication) {
        _authenticated(cookieAuthentication);
    }

    return {
        getName: _getName,
        getToken: _getToken,
        isAuthenticated: _isAuthenticated,
        authenticated: _authenticated,
        logout: _logout,
        redirectToLogin: _redirectToLogin,
        verifyAuthentication: _verifyAuthentication
    };

    return {
        getName: _getName,
        getToken: _getToken,
        isAuthenticated: _isAuthenticated,
        authenticated: _authenticated,
        logout: _logout,
        redirectToLogin: _redirectToLogin,
        verifyAuthentication: _verifyAuthentication
    };


}]);
