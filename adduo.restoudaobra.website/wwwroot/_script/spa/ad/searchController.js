ROApp.controller('searchController', ['$window', '$scope', '$routeParams', 'searchService', 'pagerSearchService', 'adFactory', '$location', function ($window, $scope, $routeParams, searchService, pagerSearchService, adFactory, $location) {

    var loadername = 'ad-search';

    $scope.productsearch = { term: $routeParams.term };

    $scope.result = pagerSearchService.productList;

    $scope.all = function () {

        $scope.loaderStart(loadername);

        searchService.search('')
            .success(function (res) {
                $scope.result = pagerSearchService.init(res.dtos, 1000, $window.outerWidth);
            })
            .error(function (err) {
            })
            .finally(function () {
                $scope.loaderStop(loadername);

            });

    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }

    $scope.productTypeDonation = function (ad) {
        return adFactory.helper.productTypeDonation(ad);
    }

    $scope.productTypeSale = function (ad) {
        return adFactory.helper.productTypeSale(ad);
    }

    $scope.moreResults = function () {
        $scope.result = pagerSearchService.next();
    }

    if (!$scope.result.length) {
        $scope.all();
    }
    else {
        $scope.result = pagerSearchService.next();
    }

}]);




