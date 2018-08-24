ROApp.controller('mainController', ['$scope', function ($scope) {

}]);


ROApp.controller('AdDetailController', ['$scope', function ($scope) {

    $scope.images = [];

    $scope.init = function (images) {
        $scope.images = images;
    }

    $scope.galleryOpen = function (data) {
        $scope.$broadcast('gallery-open', data);
    }

}]);

ROApp.controller('adGalleryController', ['$scope', function ($scope) {

    $scope.open = function (selected) {
        $scope.$parent.galleryOpen({ index: selected });
    }

}]);

ROApp.controller('adCarouselController', ['$scope', function ($scope) {

    var index = 0;
    $scope.visible = false;
    var image = {};

    var images = [];

    $scope.$on('esc-trigger', function (evt, data) {
        $scope.close();
        $scope.$apply();
    });

    $scope.$on('gallery-open', function (event, data) {

        images = $scope.$parent.images;

        open(data.index);

        console.log(data.index);
    });

    var getImage = function (i) {

        if (images[i]) {
            image = images[i];
            index = i;
        }
    }

    $scope.close = function () {
        $scope.visible = false;
    }

    var open = function (i) {
        index = i;
        $scope.visible = true;
        getImage(i);
    }

    $scope.previous = function () {
        getImage(--index);

    }

    $scope.next = function () {
        getImage(++index);
    }

    $scope.selected = function () {
        return image;
    }

    $scope.previousShow = function () {
        return index > 0;
    }

    $scope.nextShow = function () {
        return index < (images.length - 1);
    }



}]);

