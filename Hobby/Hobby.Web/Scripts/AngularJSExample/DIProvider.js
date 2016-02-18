////////////////////////////Provider/////////////////////////////////

var app4 = angular.module('app4', []);

app4.value('stringValue', 'AngularJS');

app4.provider('oneProvider', function () {
    var provider = {};

    var config = { paramOne: 'jest niesamowity!' };

    provider.addConfig = function (paramOne) {
        config.paramOne = paramOne;
    };

    provider.$get = function (stringValue) {
        var service = {};
        service.printLog = function () {
            console.log('Log z providera + value i paramone: ' + stringValue + config.paramOne);
        },
        service.viewTest = function () {
            return 'Log z provaidera: ' + stringValue + config.paramOne;
        };
        return service;
    };
    console.log(provider);
    return provider;
});

app4.config(function (oneProviderProvider) {
    oneProvider0Provider.addConfig('nowa konfiguracja');
});

app4.controller('defaultCtrl', function ($scope, oneProvider) {
    $scope.viewTest = oneProvider.viewTest();
    oneProvider.printLog();
});
