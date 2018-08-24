ROApp.controller('ownerController', ['$scope', 'ownerService', function ($scope, ownerService) {

    $scope.helper.form.success = false;
    $scope.helper.form.internalerror = false;

}]);

ROApp.controller('ownerRegisterController', ['$scope', 'baseFactory', 'ownerService', 'ownerFactory', 'authFactory', function ($scope, baseFactory, ownerService, ownerFactory, authFactory) {

    $scope.dto = ownerFactory.helper.createOwner();

    $scope.stateSelected = {};

    var loadername = 'owner-register'

    $scope.event.save = function () {

        $scope.loaderStart(loadername);

        $scope.helper.form.internalerror = false;

        ownerService.save($scope.dto)
            .success(function (response) {

                $scope.dto = response.dto;

                $scope.scrollTo();

                $scope.helper.form.success = true;

            })
            .error(function (err, status) {

                $scope.scrollTo();

                $scope.helper.form.showError(err);
                baseFactory.http.httpStatusAction(status);
                $scope.dto = err.dto;

                if (err && err.error) {
                    $scope.helper.form.internalerror = err.error.code === 'ERRO';
                }
            })
            .finally(function () {
                $scope.loaderStop(loadername);
            });
    }

    $scope.event.alreadyboth = function () {
        var cpf = $scope.dto.cpf.code === 'ALREADY';
        var email = $scope.dto.email.code === 'ALREADY';
        return cpf && email;
    }

    $scope.event.alreadycpf = function () {
        var cpf = $scope.dto.cpf.code === 'ALREADY';
        var email = $scope.dto.email.code !== 'ALREADY';
        return cpf && email;
    }

    $scope.event.alreadyemail = function () {
        var cpf = $scope.dto.cpf.code !== 'ALREADY';
        var email = $scope.dto.email.code === 'ALREADY';
        return cpf && email;
    }

    $scope.event.already = function () {
        var cpf = $scope.dto.cpf.code === 'ALREADY';
        var email = $scope.dto.email.code === 'ALREADY';
        return cpf || email;
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }



}]);

ROApp.controller('ownerRegisterSuccessController', ['$scope', '$location', 'ownerService', 'authFactory', function ($scope, $location, ownerService, authFactory) {

    $scope.event.redirectAfterAuth = function () {
    }

}]);

ROApp.controller('ownerLoginController', ['$scope', 'baseFactory', 'ownerService', 'ownerFactory', 'authFactory', function ($scope, baseFactory, ownerService, ownerFactory, authFactory) {

    $scope.helper.form.unauthorized = false;
    $scope.helper.form.unauthorizedcode = '';

    var loadername = 'login';

    $scope.dto = ownerFactory.helper.createLogin();

    $scope.event.login = function () {

        $scope.helper.form.unauthorized = false;

        $scope.loaderStart(loadername);

        ownerService.login($scope.dto)
            .success(function (response) {
                authFactory.authenticated(response.dto);
            })
            .error(function (err, status) {
                $scope.helper.form.showError(err);
                baseFactory.http.httpStatusAction(status);

                if (err && err.error) {
                    $scope.helper.form.unauthorized = true;
                    $scope.helper.form.unauthorizedcode = err.error.code;
                }
            })
            .finally(function () {
                $scope.loaderStop(loadername);
            });
    }

    $scope.loaderLoginActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }


}]);

ROApp.controller('ownerConfirmationController', ['$scope', 'baseFactory', 'ownerService', '$location', 'authFactory', '$routeParams', function ($scope, baseFactory, ownerService, $location, authFactory, $routeParams) {

    $scope.helper.form.code = '';
    $scope.dto = {
        guid: $routeParams.guid
    };

    var loadername = 'loader-confirm';

    $scope.loaderStart(loadername);

    ownerService.confirmation($scope.dto)
        .success(function (response) {
            $scope.helper.form.code = 'OK';
            authFactory.authenticated(response.dto);
        })
        .error(function (err, status) {
            $scope.helper.form.showError(err);
            baseFactory.http.httpStatusAction(status);

            if (err && err.error) {
                $scope.helper.form.code = err.error.code;
            }
        })
        .finally(function () {
            $scope.loaderStop(loadername);
        });

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }

    $scope.event.confirmationOK = function () {
        return $scope.helper.form.code === 'OK';
    }

    $scope.event.confirmationErro = function () {
        return $scope.helper.form.code === 'ERRO';
    }

    $scope.event.confirmationAlready = function () {
        return $scope.helper.form.code === 'ALREADY';
    }

    $scope.event.confirmationEmpty = function () {
        return $scope.helper.form.code === 'EMPTY';
    }

    $scope.event.confirmationChoice = function () {
        return $scope.helper.form.code === 'OK' || $scope.helper.form.code === 'ALREADY';
    }

}]);

ROApp.controller('ownerResetPasswordSolicitationController', ['$scope', 'ownerService', 'ownerFactory', 'baseFactory', function ($scope, ownerService, ownerFactory, baseFactory) {

    $scope.dto = ownerFactory.helper.createResetPasswordSolicitation();

    var loadername = 'reset-password-solicitation';

    $scope.event.resetPassword = function () {

        $scope.helper.form.success = false;

        $scope.loaderStart(loadername);

        ownerService.resetPasswordSolicitation($scope.dto)
            .success(function (response) {
                $scope.dto = response.dto;
                $scope.helper.form.success = true;
            })
            .error(function (err, status) {

                $scope.helper.form.showError(err);

                baseFactory.http.httpStatusAction(status);

                if (err && err.error) {
                    $scope.helper.form.internalerror = err.error.code === 'ERRO';
                }

                if (err && err.dto) {
                    $scope.dto = err.dto;
                }
            })
            .finally(function () {
                $scope.loaderStop(loadername);
            });
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loadername);
    }


}]);

ROApp.controller('ownerResetPasswordController', ['$scope', 'ownerService', 'ownerFactory', '$routeParams', 'authFactory', 'baseFactory', function ($scope, ownerService, ownerFactory, $routeParams, authFactory, baseFactory) {

    $scope.dto = ownerFactory.helper.createResetPasswordChange();
    $scope.show = false;
    $scope.helper.form.success = false;

    var loaderreset = 'reset-password';
    var loaderverification = 'reset-verification';

    $scope.loaderStart(loaderverification);

    ownerService.resetPasswordVerification($routeParams.key)
        .success(function (response) {
            authFactory.authenticated(response.dto);
            $scope.show = true;
        })
        .error(function (err, status) {

            $scope.helper.form.showError(err);

            baseFactory.http.httpStatusAction(status);

        })
        .finally(function () {
            $scope.loaderStop(loaderverification);
        });

    $scope.event.resetPassword = function () {

        $scope.loaderStart(loaderreset);

        ownerService.resetPasswordchange($scope.dto)
            .success(function (response) {
                $scope.helper.form.success = true;
            })
            .error(function (err, status) {
                $scope.helper.form.showError(err);
                baseFactory.http.httpStatusAction(status);
                $scope.dto = err.dto;
            })
            .finally(function () {
                $scope.scrollTo();
                $scope.loaderStop(loaderreset);
            });
    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loaderreset);
    }

    $scope.loaderVerificationActivity = function () {
        return $scope.$parent.loaderActivity(loaderverification);
    }

}]);

ROApp.controller('ownerUpdateController', ['$scope', 'ownerService', 'ownerFactory', 'baseFactory', function ($scope, ownerService, ownerFactory, baseFactory) {

    $scope.dto = ownerFactory.helper.createOwner();

    $scope.show = false;

    var loaderget = 'owner-get'
    var loaderupdate = 'owner-update'

    $scope.loaderStart(loaderget);

    ownerService.get()
        .success(function (response) {
            $scope.dto = response.dto;
        })
        .error(function (err, status) {
            baseFactory.http.httpStatusAction(status);
            $scope.helper.form.showError(err);
        })
        .finally(function () {
            $scope.loaderStop(loaderget);
        });

    $scope.cancelEdit = function (property) {
        property.edit = false;
        property.value = property.defaultvalue;
    }

    $scope.resetProperties = function () {

        for (p in $scope.dto) {
            var _prop = $scope.dto[p];
            if (_prop && _prop.prop && _prop.edit) {
                $scope.cancelEdit(_prop);
            }
        }
    }

    $scope.edit = function (property) {

        $scope.resetProperties();
        property.edit = true;
        property.defaultvalue = property.value;
    }

    $scope.event.update = function () {

        $scope.loaderStart(loaderupdate);

        ownerService.update($scope.dto)
            .success(function (response) {
                $scope.dto = response.dto;
            })
            .error(function (error, status) {

                baseFactory.http.httpStatusAction(status);

                $scope.dto = error.dto;

                $scope.helper.form.showError(error);
            })
            .finally(function () {
                $scope.loaderStop(loaderupdate);
            });

    }

    $scope.loaderActivity = function () {
        return $scope.$parent.loaderActivity(loaderget);
    }

    $scope.loaderUpdateActivity = function () {
        return $scope.$parent.loaderActivity(loaderupdate);
    }

}]);