ROApp.controller('saleController', ['$scope', 'saleService', function ($scope, saleService) {

    

    $scope.dto = {
        products: [],
        owner: { address: {} },
        address: {}
    };

}]);

ROApp.controller('saleadController', ['$scope', 'saleService', function ($scope, saleService) {

    $scope.steper.addStep();

    $scope.dto.product = {};

    $scope.control.saleProductForm = true;

    $scope.helper.form.addProperty('name', '', $scope.dto.product);
    $scope.helper.form.addProperty('option', '', $scope.dto.product);
    $scope.helper.form.addProperty('brand', '', $scope.dto.product);
    $scope.helper.form.addProperty('quantity', '', $scope.dto.product);
    $scope.helper.form.addProperty('donation', true, $scope.dto.product);
    $scope.helper.form.addProperty('price', '', $scope.dto.product);

    $scope.event.addProduct = function () {

        saleService.registerProductValidation($scope.dto.product)
            .success(function (response) {
                if (response.success) {

                    $scope.function.setSaleProductForm(false);

                }
                else {
                    $scope.dto.product = response.dto;
                }
            })
      .error(function (err) {
          $scope.helper.form.showError(err);
      });
    }

    $scope.function.setSaleProductForm = function (show) {
        $scope.control.saleProductForm = show;
    }

    $scope.function.saleProductForm = function () {
        return $scope.control.saleProductForm;
    }

}]);

ROApp.controller('saleAddressController', ['$scope', 'saleService', function ($scope, saleService) {

    $scope.steper.addStep();

    $scope.helper.form.addProperty('city', '', $scope.dto.address);
    $scope.helper.form.addProperty('state', '', $scope.dto.address);
    $scope.helper.form.addProperty('zone', '', $scope.dto.address);

    $scope.event.addAddress = function () {

        saleService.registerAddressValidation($scope.dto.address)
            .success(function (response) {

                $scope.dto.address = response.dto;

                if (response.success) {
                    $scope.steper.nextStep();
                }
            })
      .error(function (err) {
          $scope.helper.form.showError(err);
      });
    }

}]);

ROApp.controller('saleConfirmController', ['$scope', 'saleService', function ($scope, saleService) {

    $scope.event.save = function () {
        addProduct();
        $scope.steper.nextStep();
    }

    $scope.event.newProduct = function () {
        addProduct();
        $scope.function.setSaleProductForm(true);
    }

    $scope.event.editProduct = function () {
        $scope.function.setSaleProductForm(true);
    }

    function addProduct() {

        var product = {};
        angular.copy($scope.dto.product, product);

        $scope.dto.products.push(product);
        $scope.helper.form.clearFields($scope.dto.product);
    }

}]);


ROApp.controller('saleFinishedController', ['$scope', 'saleService', function ($scope, saleService) {

    $scope.steper.addStep();

}]);

