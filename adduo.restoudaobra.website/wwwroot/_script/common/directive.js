ROApp.directive('escTrigger', ['$window', '$rootScope', function ($window, $rootScope) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            angular.element($window.document).bind('keyup', function (e) {
                var key = e.which || e.keyCode || 0;

                if (key === 27) {
                    console.log('cc')
                    $rootScope.$broadcast('esc-trigger', {})
                }
            });
        }
    };
}]);

ROApp.directive('scrollAction', ['$window', '$location', '$rootScope', function ($window, $location, $rootScope) {

    return {
        restrict: 'A',
        scope: {
            action: "@",
            limit: '@'
        },
        link: function (scope, element, attrs) {

            var _limit =  100;
            var _action = 'show';

            if (_action == 'none' || _action == '') {
                element.fadeIn('slow');
            }
            else {

                element.hide();

                angular.element($window).bind('scroll', function () {

                    var displayNone = element.css('display') == 'none';

                    if (this.pageYOffset >= _limit) {

                        if (_action == 'show' && displayNone) {
                            element.fadeIn('slow');
                        }
                        else if (_action == 'hide' && !displayNone) {
                            element.fadeOut('slow');
                        }
                    }
                    else if (this.pageYOffset < _limit) {
                        if (_action == 'show' && !displayNone) {
                            element.fadeOut('slow');
                        }
                        else if (_action == 'hide' && displayNone) {
                            element.fadeIn('slow');
                        }
                    }
                });
            }

        }
    }
}]);