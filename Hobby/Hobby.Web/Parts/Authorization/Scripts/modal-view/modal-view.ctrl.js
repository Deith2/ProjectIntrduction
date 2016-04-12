var mymodal = angular.module('mymodal', []);

mymodal.controller('MainCtrl', function ($scope, $http) {

    //Modal show
    $scope.showModal = false;
    $scope.toggleModal = function () {
        $scope.showModal = !$scope.showModal;
    };

    $scope.cancel = function () {
        $scope.toggleModal();
    };

    //Login
    $scope.login = function (concat) {
        $http({
            method: "POST",
            url: "../Authorization/Login",
            data: concat
        }).then(function mySucces(response) {
            if (response.data.isRedirect) {
                $scope.showModal = false;
                window.location = response.data.redirectUrl;
            }
        }, function myError(response) {
            alert("Proszę spróbować za chwilę");
        });
    };

    //Register
    $scope.register = function (content) {
        $http({
            method: "POST",
            url: "../Authorization/Register",
            data: content
        }).then(function mySucces(response) {
            console.log(response)
            if (!response.data.userExist) {
                console.log("udalo sie");
                $scope.login(response.data.userModel);
            }
            else {
                console.log("login Istnieje")
                $scope.mailVerify = true;
            }
        }, function myError(response) {
            alert("Proszę spróbować za chwilę");
        });
    };
});
