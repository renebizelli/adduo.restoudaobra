ROApp.service('ownerService', ['httpFactory', 'ownerFactory', function (httpFactory, ownerFactory) {

    this.save = function (owner) {
        var request = ownerFactory.helper.createRequest(owner);
        return httpFactory.post('owner', request);
    }

    this.login = function (login) {

        var request = ownerFactory.helper.createRequest(login);

        return httpFactory.post('login', request);
    }

    this.resend = function (login) {

        var request = ownerFactory.helper.createRequest(login);

        return httpFactory.post('owner/resend', request);
    }

    this.confirmation = function (confirmation) {

        var request = ownerFactory.helper.createRequest(confirmation);

        return httpFactory.post('owner/confirmation', request);
    }

    this.get = function () {

        return httpFactory.get('owner');
    }

    this.update = function (owner) {

        var request = ownerFactory.helper.createRequest(owner);

        return httpFactory.put('owner', request);
    }

    this.resetPasswordSolicitation = function (owner) {

        var request = ownerFactory.helper.createRequest(owner);

        return httpFactory.post('resetpassword/solicitation', request);
    }

    this.resetPasswordVerification = function (key) {

        return httpFactory.get('resetpassword/verification/?key=' + key);
    }

    this.resetPasswordchange = function (reset) {

        var request = ownerFactory.helper.createRequest(reset);

        return httpFactory.put('resetpassword/change', request);
    }

}]);