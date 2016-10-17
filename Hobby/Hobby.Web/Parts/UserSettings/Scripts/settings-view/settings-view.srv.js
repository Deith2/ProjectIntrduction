var app = angular.module('appTable');

app.service("getUserDetails", function ($http) {
    this.getData = function (callbackFunc) {
        $http({
            method: "GET",
            url: "../UserSettings/GetUser"
        }).then(function mySucces(response) {
            callbackFunc(response);
        }, function myError() {
            alert("Proszę spróbować za chwilę");
        });
    };
});

app.service("Update", function ($http) {
    this.saveChanges = function (callbackFunc) {
        $http.post("../UserSettings/EditSettings", callbackFunc).success(function (data) {

        });
    };
});