var app = angular.module('appTable', []);

app.controller('deafultCtrl', function ($scope, $http) {

   
      
    
    //$scope.login = function () {
    //    $http({
    //        method: "GET",
    //        url: '../UserSettings/GetUser'
    //    }).then(function mySucces(response) {

    //    }, function myError(response) {
    //        alert("Proszę spróbować za chwilę");
    //    });
    //};
        $http({
            method: "GET",
            url: "../UserSettings/GetUser"
        }).then(function mySucces(response) {
           $scope.Email = response.data.Email
           $scope.FirstName = response.data.FirstName
           $scope.LastName = response.data.LastName          
        }, function myError(response) {
            alert("Proszę spróbować za chwilę");
        });


  

        $scope.saveChanges = function (concat) {
            console.log(concat)
            $scope.FirstName = concat;

    };
});