var app = angular.module('app', []);

app.controller('deafultCtrl', function ($scope) {
    $scope.mountainList = [
        { mountain: "Mount Everest", metres: 8850 },
        { mountain: "k2", metres: 8611 },
        { mountain: "kanga", metres: 8898 },
        { mountain: "Lhotse", metres: 8501 },
        { mountain: "Mkalu", metres: 8463 },
        { mountain: "Cho Oyu", metres: 8201 },
    ];

    var drive = function (source, target) {
        var t = $scope.mountainList[target];
        $scope.mountainList[target] = $scope.mountainList[source];
        $scope.mountainList[source] = t;
    };

    $scope.up = function (index) {
        drive(index, index - 1);
    };

    $scope.down = function (index) {
        drive(index, index + 1);
    };

    $scope.saveChanges = function (index, mountain, metres) {
        $scope.mountainList[index] = { 'mountain': mountain, 'metres': metres };

    };
});