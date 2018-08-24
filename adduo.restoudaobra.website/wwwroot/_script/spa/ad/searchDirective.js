
ROApp.directive('adShow', ['$timeout', function ($timeout) {

    return {

        restrict: 'A',
        scope: {
            rnd: '='
        },
        link: function (scope, element, attrs) {
            $timeout(function () { scope.rnd = 0; }, scope.rnd * 200);
        }
    }
}]);