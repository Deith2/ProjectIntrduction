var app = angular.module('appTable', []);

app.controller('deafultCtrl', function ($scope, getUserDetails) {
 
    getUserDetails.getData(function (dataRespone) {
        $scope.FirstName = dataRespone.data.FirstName;
        $scope.LastName = dataRespone.data.LastName;
        $scope.Email = dataRespone.data.Email;

        $scope.concat = {
            FirstName: dataRespone.data.FirstName,
            LastName: dataRespone.data.LastName,
            Email: dataRespone.data.Email
        };
    });
    
    $scope.saveChanges = function (concat) {
        console.log(concat);
        $scope.FirstName = concat.FirstName;
        $scope.LastName = concat.LastName;
        $scope.Email = concat.Email;
    };
});