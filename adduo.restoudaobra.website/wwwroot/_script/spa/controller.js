ROApp.controller('mainController', ['$scope', '$rootScope', '$anchorScroll', '$location', 'baseFactory', 'authFactory', '$window', '$timeout', function ($scope, $rootScope, $anchorScroll, $location, baseFactory, authFactory, $window, $timeout) {

    $scope.title = '';
    $scope.data = {};
    $scope.helper = {};
    $scope.helper.form = {};
    $scope.helper.loader = {};
    $scope.staticmenu = false;


    $rootScope.$on('$routeChangeStart', function (event, currRoute, prevRoute) {

        if (currRoute) {
            authFactory.verifyAuthentication(currRoute);
            $scope.staticmenu = currRoute.staticmenu;
        }
    });


    $rootScope.$on('$locationChangeStart', function (event, toUrl, fromUrl) {

        var notScrollTop = fromUrl.indexOf('/anuncio/'); // (detail to home)

        if (notScrollTop == -1) {
            window.scrollTo(0, 0);
        }
    });

    $scope.loader = new Array();

    $scope.loaderStart = function (target) {
        $scope.loader[target] = true;
    }

    $scope.loaderStop = function (target) {
        $timeout(function () {
            $scope.loader[target] = false;
        }, 300);
    }

    $scope.loaderActivity = function (target) {
        return $scope.loader[target];
    }

    $scope.setTitle = function (title) {
        $scope.title = title;
    }

    $scope.error = { has: false, messages: [] };

    $scope.control = {
        page: {
            success: false
        }
    };

    $scope.event = {};
    $scope.function = {};

    $scope.event.error = function (err, status) {
        console.log('--------------------');
        console.log(err);
        console.log(status);
        console.log('--------------------');
    }



    $scope.helper.loader.show = function () {
        $scope.$broadcast("loader-show");
    }

    $scope.helper.loader.hide = function () {
        $scope.$broadcast("loader-hide");
    }

    $scope.helper.form.statusClass = function (prop) {
        return baseFactory.helper.statusClass(prop, 'input-div-valid', 'input-div-invalid');
    }

    $scope.helper.form.if = function (condition, _true, _false) {
        return condition ? _true : _false;
    }

    $scope.helper.redirect = function (path) {
        $location.path(path);
    }

    $scope.helper.form.showError = function (err) {
        $scope.error.has = true;
        if (err && err.error && err.error.messages) {
            for (var i = 0; i < err.error.messages.length; i++) {
                $scope.error.messages.push(err.error.messages[i]);
            }
        }
    }

    $scope.scrollTo = function () {
        window.scrollTo(0, 0);
    }


}]);