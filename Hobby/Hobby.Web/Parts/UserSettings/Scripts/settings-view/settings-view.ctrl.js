var app = angular.module('appTable', ['ngMessages']);

app.controller('deafultCtrl', function ($scope, getUserDetails, Update) {

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
        $scope.FirstName = concat.FirstName;
        $scope.LastName = concat.LastName;
        $scope.Email = concat.Email;
    };

    $scope.Update = function (concat) {

        Update.saveChanges(concat)
    } //{ //TO DO: Alert o zapisie};
});
