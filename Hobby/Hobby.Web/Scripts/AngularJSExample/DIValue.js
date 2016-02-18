////////////////////////////Value/////////////////////////////////
var app = angular.module('app', []);

app.value("numberValue", 100);
app.value('stringValue', 'AngularJS');
app.value('objectValue', { v1: 123, v2: 'ABCD', v3: { 'v31': 'ABCDF' } });
//zmieniam nazwy farametrow ale musza byc w odpowiedniej kolejnosci :)
app.controller('defaultCtrl',
    ['$scope', 'objectValue', 'stringValue', 'numberValue', function ($scope, o, s, n) {
        console.log(o);
        console.log(s);
        console.log(n);

        $scope.objectValue = o;
        $scope.stringValue = s;
        $scope.numberValue = n;
    }]);

////////////////////////////Factory/////////////////////////////////


var app2 = angular.module('app2', []);

app2.value('stringValue', 'AngularJs');

app2.factory('oneFactory', ['stringValue', function (val) {
    return 'Wartość z fabyki + wartość z value: ' + val;
}]);

app2.controller('defaultCtrl',
    ['$scope', 'oneFactory', function ($scope, oneF) {
        console.log(oneF);

        $scope.oneFactory = oneF;
    }]);

angular.bootstrap(document.getElementById('factory'), ['app2']);

////////////////////////////Service/////////////////////////////////

var app3 = angular.module('app3', []);


///serwis 1
function OneService() {
    this.printLog = function () {
        console.log('Log z serwisu - AngularJS');
    },
    this.newValue = function () {
        return 'Nowa wiadomość z serwisu';
    };
}
app3.service('oneService', OneService);

//serwis2
app3.service('twoService', function () {
    this.printLog = function () {
        console.log('Log z drugiego seriwsu - AngularJS');
    },
    this.newValue = function () {
        return 'Nowa wartość drugiego serwisu';
    };
});

//serwis3
app3.value('stringValue', 'AngularJS');

function FourService() {
    this.printLog = function (x) {
        console.log('Log z czwartego serwisu ' + x + ' łączony!');
    };
}
//druga wersja serwisu 3
app3.service('threeService', function (stringValue) {
    this.printLog = function () {
        console.log('Log z trzeciegu serwisu ' + stringValue + ' łączony!');
    };
});

app3.service('fourService', FourService);

app3.controller('defaultCtrl', function ($scope, oneService, twoService, threeService, fourService, stringValue) {
    oneService.printLog();
    $scope.newValue = oneService.newValue();

    twoService.printLog();
    $scope.newValue2 = twoService.newValue();

    threeService.printLog();

    fourService.printLog(stringValue);
});

angular.bootstrap(document.getElementById('service'), ['app3']);
