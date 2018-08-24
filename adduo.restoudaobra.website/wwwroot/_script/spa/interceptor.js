ROApp.factory('loaderInterceptor', ['$q', '$rootScope', function ($q, $rootScope) {

    return {
        'request': function (config) {
            return config;
        },

        'requestError': function (rejection) {
            return $q.reject(rejection);
        },

        'response': function (response) {
            return response;
        },

        'responseError': function (rejection) {
            return $q.reject(rejection);
        }
    };
}]);


ROApp.factory('authInterceptor', ['authFactory', function (authFactory) {

    return {
        'request': function (config) {

            if (authFactory.isAuthenticated()) {
                config.headers.Authorization = 'Bearer ' + authFactory.getToken();
            }

            return config;
        }

    };
}]);