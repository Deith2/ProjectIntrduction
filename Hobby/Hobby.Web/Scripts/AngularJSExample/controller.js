var apps = angular.module('app', []);
apps.controller('FirstCtrl', ['$scope', function ($scope) {
    $scope.message = { sentence: 'świecie' };
}]);
apps.controller("myCtrl", function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
});

//przypisanie atrybutów do rootScope-a
var app = angular.module('myapp2', []);
app.run(function ($rootScope) {
    $rootScope.dateOrginal = new Date();
});

app.controller('dateCtrl', function ($rootScope, $scope) {
    $scope.orginal = function () {
        return $rootScope.dateOrginal;
    };
});



//Dziedziczenie
app.controller('defaultCtrl', function ($scope) {
    $scope.uczen = { zdanyTest: false };
});
app.controller('inheritanceCtrl', function ($scope) {
    $scope.poprawaTestu = function () {
        $scope.uczen.zdanyTest = true;
    };
});

app.controller('myDeafultCtrl', function ($scope) {
    $scope.oferty = [
        { nazwa: 'Krzesło', cena: 149.99 },
        { nazwa: 'Stolik', cena: 189.99 },
        { nazwa: 'Szafka', cena: 205.99 },
    ];
});

//Nasłuchiwanie
var apps3 = angular.module('listner', []);


apps3.controller('defaultCtrl', function ($scope) {
    $scope.number = 1;
    $scope.$watch('number', function () {
        console.log('Liczba: ' + $scope.number);
    });
    $scope.add = function () {
        $scope.number++;
    };
    $scope.dec = function () {
        $scope.number--;
    };
});
//apply - wyświetla zmiany ale tam gdzie nie możę :)
apps3.controller('defaultCtrl1', function ($scope) {
    $scope.go = function () {
        setTimeout(function () {
            $scope.msg = 'Wow, jestem opóźnioną informacją!';
            console.log('message:' + $scope.msg);
            $scope.$apply();
        }, 2000);
    };
    $scope.go();
});

//ładuje drugi moduł
angular.bootstrap(document.getElementById('DateSecondModule'), ['myapp2']);
angular.bootstrap(document.getElementById('watcher'), ['listner']);