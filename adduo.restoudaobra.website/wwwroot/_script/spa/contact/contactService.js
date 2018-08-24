ROApp.service('contactService', ['$http', 'contactFactory', function ($http, contactFactory) {

    this.send = function (contact) {

        var request = contactFactory.helper.createRequest(contact);

        return $http.post('/api/contact', request);
    }
}]);