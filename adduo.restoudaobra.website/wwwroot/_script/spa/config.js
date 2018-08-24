ROApp.config(['$locationProvider', '$httpProvider', '$routeProvider', function ($locationProvider, $httpProvider, $routeProvider) {

    $httpProvider.interceptors.push('loaderInterceptor');
    $httpProvider.interceptors.push('authInterceptor');

    $locationProvider.html5Mode(true);

    var tmp = new Date().getMilliseconds();
    $routeProvider
        .when('/identificacao', {
            templateUrl: '_page/owner-identification.html?tmp=' + tmp,
            title: 'Identificação',
            staticmenu: true,
            restrict: false
        })
        .when('/cadastro/confirmacao/:guid', {
            templateUrl: '_page/owner-confirmation.html?tmp=' + tmp,
            title: 'Confirmação de Cadastro',
            staticmenu: true,
            restrict: false
        })
        .when('/cadastro/redefinir-senha/', {
            templateUrl: '_page/owner-reset-password-solicitation.html?tmp=' + tmp,
            title: 'Redefinir senha',
            staticmenu: true,
            restrict: false,
        })
        .when('/cadastro/redefinir-senha/:key', {
            templateUrl: '_page/restrict/owner-reset-password.html?tmp=' + tmp,
            title: 'Redefinir senha',
            staticmenu: true,
            restrict: false,
        })
        .when('/meus-dados', {
            templateUrl: '_page/restrict/owner-update.html?tmp=' + tmp,
            title: 'Meus Dados',
            staticmenu: true,
            restrict: true
        })
        .when('/quero-vender', {
            templateUrl: '_page/restrict/product-register-sale.html?tmp=' + tmp,
            title: 'Quero Vender',
            restrict: true,
            staticmenu: true
        })
        .when('/quero-doar', {
            templateUrl: '_page/restrict/product-register-donation.html?tmp=' + tmp,
            title: 'Quero Doar',
            restrict: true,
            staticmenu: true
        })
        .when('/meus-anuncios', {
            templateUrl: '_page/restrict/my-ad-list.html?tmp=' + tmp,
            title: 'Meus Anúncios',
            restrict: true,
            staticmenu: true
        })
        .when('/quero-vender/pagamento', {
            templateUrl: '_page/restrict/ad-payment.html?tmp=' + tmp,
            title: 'Pagamento',
            staticmenu: true,
            restrict: true
        })
        .when('/meus-anuncios/anuncio/:id', {
            templateUrl: '_page/restrict/product-edit.html?tmp=' + tmp,
            title: 'Meus Anúncios',
            staticmenu: true,
            restrict: true
        })
        .when('/contato', {
            templateUrl: '_page/contact.html?tmp=' + tmp,
            title: 'Contato',
            staticmenu: true,
            restrict: false,
        })
        .when('/politica-de-privacidade', {
            templateUrl: '_page/privacy.html?tmp=' + tmp,
            title: 'Política de privacidade',
            staticmenu: true,
            restrict: false,
        })
        .when('/termos-de-uso', {
            templateUrl: '_page/terms.html?tmp=' + tmp,
            title: 'Termos de uso',
            staticmenu: true,
            restrict: false,
        });


}]);