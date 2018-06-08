(function () {
    var app = angular.module("LoginModule", []);
    var LoginController = function ($scope, $http) {
        var onUserComplete = function (response) {
            console.log(response.data);
            $scope.loginCredentials = response.data;
        }
        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        }
        $http.get("/home/index/")
            .then(onUserComplete, onError);

        $scope.login = function () {
            $http.get("/home/login")
                .then(onUserComplete, onError);
        }

    };

    app.controller("LoginController", LoginController);
}());