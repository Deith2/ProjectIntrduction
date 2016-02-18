var app = angular.module('app', []);

app.controller('defaultCtrl', function ($scope) {
    $scope.test = 123;
    $scope.name = "ABC";
    $scope.tempText = "123";
    console.log($scope.test);
    $scope.focus = false;
    $scope.blur = false;
});

