ROApp.directive('heightBody', ['$window', function ($window) {

    var _setHeightBody = function (e, height) {

        var heightapply = height > 800 ? 800 : height;

        e.css('min-height', heightapply);
    }

    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            _setHeightBody(element, $window.innerHeight)
            angular.element($window).bind('resize', function () {
                _setHeightBody(element, $window.innerHeight)
            });
        }
    };
}]);

ROApp.directive('menu', ['$location', 'authFactory', function ($location, authFactory) {

    return {
        restrict: 'E',
        replace: true,
        scope: {
            action: "@",
            limit: '@'
        },
        templateUrl: '/_page/component/menu.html',
        controller: ['$scope', 'authFactory', function ($scope, authFactory) {

            $scope.$watch(authFactory.isAuthenticated, function (isAuthenticated) {
                $scope.name = isAuthenticated ? authFactory.getName() : '';
                $scope.authenticated = isAuthenticated;
            });

            $scope.logout = function () {
                authFactory.logout();
            }
        }]
    }
}]);

ROApp.directive('logoMenuPrincipal', ['$window', function ($window) {

    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            angular.element($window).bind('scroll', function () {
                var limit = 100;
                if (this.pageYOffset >= limit && element.css('display') == 'none') {
                    element.fadeIn('slow');
                }
                else if (this.pageYOffset < limit && element.css('display') != 'none') {
                    element.fadeOut('slow');
                }
            })
        },
        templateUrl: function (elem, attrs) {
            return attrs.src;
        }
    }
}]);


ROApp.directive('logo', ['$location', function ($location) {

    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/_page/component/logo.html'
    }
}]);

ROApp.directive('footer', ['$location', function ($location) {

    return {
        restrict: 'A',
        templateUrl: '/_page/component/footer.html'
    }
}]);

ROApp.directive('clearClass', function () {

    return {
        restrict: 'A',
        link: function (scope, element, attrs) {

            var parent = angular.element(element.parent()[0]);

            element.bind('keypress', function (c) {
                parent.removeClass('input-div-valid');
                parent.removeClass('input-div-invalid');
            });

        }
    }
});


ROApp.directive('dropdown', function () {

    return {
        restrict: 'A',
        scope: {
            options: '=',
            select: '&',
            selected: '='
        },
        templateUrl: '/_page/component/dropdown.html',
        controller: ['$scope',function ($scope) {

            $scope.search = '';

            $scope._options = $scope.options;

            var selectDefault = { id: 0, name: 'Selecione' };

            $scope._selected = selectDefault;

            if ($scope.selected && $scope.selected.id > 0) {
                $scope._selected = $scope.selected;
            }

            $scope.display = 'hidden';

            $scope.displayOptions = function () {
                $scope.display = $scope.display == 'block' ? 'hidden' : 'block';
            }

            $scope.checkSelected = function (o) {
                return $scope._selected.id == o.id;
            }

            $scope.selectOption = function (option) {
                $scope.select({ selected: option });
                $scope._selected = option;
                $scope.search = $scope._selected.name;
                $scope.displayOptions();
            }

            $scope.unselectOption = function () {
                $scope.select(selectDefault);
                $scope._selected = selectDefault;
            }

            $scope.displayHidden = function () {
                $scope.display = 'hidden';
            }

            $scope.filter = function () {
                $scope.display = 'block';
                $scope._options = $scope.options.filter(function (d) {
                    return d.name.toUpperCase().startsWith($scope.search.toUpperCase())
                });
            }
        }]
    }
});