
ROApp.directive('productRegister', ['baseFactory', 'adFactory', 'adService', 'addressService', '$routeParams', '$window', function (baseFactory, adFactory, adService, addressService, $routeParams, $window) {

    return {
        restrict: 'E',
        replace: true,
        scope: {
            dto: '=',
            completed: '&',
            fallback: '&' 
        },
        templateUrl: '/_page/component/product-register.html',
        controller: ['$rootScope', '$scope', 'baseFactory', 'adFactory', 'adService', 'addressService', '$routeParams', function ($rootScope, $scope, baseFactory, adFactory, adService, addressService, $routeParams) {

            $scope.internalerror = false;
            $scope.addresseslist = false;

            var loader = new Array();
            var loadersave = 'ad-save'

            $scope.completed = $scope.completed();
            $scope.fallback = $scope.fallback();


            $scope.addresses = [];

            $scope.states = baseFactory.data.states;

            $scope.registerProduct = function () {

                $scope.loaderStart(loadersave);

                adService.save($scope.dto)
                    .success(function (response) {

                        $scope.dto = response.dto;

                        $scope.completed(response.dto);
                    })
                    .error(function (err, status) {
                        $scope.dto = err.dto;
                        $scope.fallback(err, status);
                    })
                    .finally(function () {
                        $window.scrollTo(0, 0);
                        $scope.loaderStop(loadersave);
                    });

            }

            $scope.loaderActivity = function (target) {
                return loader[target];
            }

            $scope.loaderSaveActivity = function () {
                return $scope.loaderActivity(loadersave);
            }

            $scope.loaderStart = function (target) {
                 loader[target] = true;
            }

            $scope.loaderStop = function (target) {
                loader[target] = false;
            }

            $scope.isEdit = function () {
                return $scope.dto && $scope.dto.product.id !== 0;
            }

            $scope.productTypeDonation = function () {
                return adFactory.helper.productTypeDonation($scope.dto.product);
            }

            $scope.productTypeSale = function () {
                return adFactory.helper.productTypeSale($scope.dto.product);
            }

            $scope.statusClass = function (property) {

                return baseFactory.helper.statusClass(property, 'input-div-valid', 'input-div-invalid');
            }

            $scope.selectState = function (item) {
                $scope.dto.address.state.value = item;
            }

            $scope.addressSelect = function (address) {
                baseFactory.helper.addProperty('id', address.id, $scope.dto.address);
                //angular.copy(address, $scope.dto.address);
            }

            $scope.listAddressSelect = function () {
                $scope.addressList();
            }

            $scope.haslistAddress = function () {
                return $scope.addresses.length > 0;
            }

            $scope.newAddressSelect = function () {
                adFactory.helper.resetAddress($scope.dto);
                $scope.addresseslist = false;
                $scope.dto.address.newOrUpdate = true;
            }

            $scope.checkAddressSelect = function (address) {
                return $scope.dto.address.id.value === address.id;
            }

            $scope.addressList = function () {

                addressService.list()
                    .success(function (response) {
                        $scope.addresses = response.dtos;
                        $scope.addresseslist = $scope.addresses && $scope.addresses.length > 0;
                        $scope.dto.address.newOrUpdate = !$scope.addresseslist;

                    })
                    .error(function (err, status) {
                        $scope.fallback(err, status);
                    });
            }

            $scope.addressList();
        }]
    }
}]);

ROApp.directive('productRegisterImage', ['$rootScope', 'productImageService', 'baseFactory', 'Upload', '$timeout', function ($rootScope, productImageService, baseFactory, Upload, $timeout) {

    return {
        restrict: 'E',
        replace: true,
        scope: {
            dto: '=',
            fallback: '&'
        },
        templateUrl: '/_page/component/product-register-image.html',
        controller: ['$scope', 'baseFactory', 'adService', '$routeParams', 'addressService', 'Upload', function ($scope, baseFactory, adService, $routeParams, addressService, Upload) {

            var _imageLimit = 6;

            var imageArray = [];

            var resetImages = function () {

                imageArray = [];

                for (var i = 0; i < $scope.dto.images.list.length; i++) {
                    imageArray.push(imageArrayExistItemFactory(i));
                }

                //$scope.dto.images.list.length usado na edicao de ad, ao inves de 0.
                for (var j = $scope.dto.images.list.length; j < _imageLimit; j++) {
                    $scope.dto.images.list.push({ id: 0, full: '' });
                    imageArray.push(imageArrayNewItemFactory(j));
                }
            }

            var imageArrayExistItemFactory = function (i) {
                var item = imageArrayNewItemFactory(i);
                item.empty = false;
                item.up = false;

                return item;
            }

            var imageArrayNewItemFactory = function (i) {
                return { index: i, file: {}, empty: true, up: false, loader: false }
            }


            $scope.controlFirstElement = function (i) {
                return (i === 0 && !$scope.checkHasImage(i));
            }

            $scope.statusClass = function (property) {
                return baseFactory.helper.statusClass(property, '', 'ad-image-invalid');
            }

            $scope.uploads = function (files) {

                var notReachedLimit = !$scope.checkImageLimit();

                if (notReachedLimit) {

                    var indexFile = 0;

                    for (var j = 0; j < _imageLimit; j++) {

                        if (indexFile >= files.length) {
                            break;
                        }

                        if (imageArray[j].empty) {
                            imageArray[j].file = files[indexFile++];
                            imageArray[j].empty = false;
                            imageArray[j].up = true;
                            imageArray[j].loader = false;
                        }
                    }

                    var images = $scope.dto.images.list;

                    for (var i = 0; i < _imageLimit; i++) {

                        if (imageArray[i].up) {

                            imageArray[i].loader = true;

                            Upload.upload(
                                {
                                    url: 'api/productimage',
                                    data: {
                                        index: i,
                                        guid: $scope.dto.product.guid,
                                        file: imageArray[i].file
                                    }
                                }).
                                then(
                                function (response) {
                                    var indexReturn = response.data.dto.list[0].index;
                                    $scope.dto.images.status = baseFactory.data.statusProperty.none;
                                    $scope.dto.images.list[indexReturn] = response.data.dto.list[0];
                                    imageArray[indexReturn].up = false;
                                    imageArray[indexReturn].loader = false;
                                },
                                function (error) {

                                    if (error && error.config && error.config.data && error.config.data.index >= 0) {

                                        var index = error.config.data.index;

                                        imageArray[index] = imageArrayNewItemFactory(index);
                                    }
                                },
                                function (evt) {
                                });


                        }
                    }
                }
            }

            $scope.delete = function (i) {

                imageArray[i].loader = true;


                $timeout(function () {

                    var id = $scope.dto.images.list[i].id;

                    productImageService.delete(id)
                        .success(function (response) {
                            imageArray[i].empty = true;
                            imageArray[i].up = false;
                            $scope.dto.images.list[i] = { full: '', id: 0 };

                        })
                        .error(function (err, status) {
                            $scope.fallback(err, status);
                        })
                        .finally(function () {
                            imageArray[i].loader = false;
                        });

                }, 200);
            }

            $scope.loaderImage = function (i) {
                return imageArray[i].loader;
            }

            $scope.checkImageLimit = function () {
                var images = imageArray.filter(function (f) { return !f.empty });
                return images.length === _imageLimit;
            }

            $scope.checkHasImage = function (i) {
                return $scope.dto.images.list[i].id !== 0;
            }

            resetImages();

        }]
    }
}]);
