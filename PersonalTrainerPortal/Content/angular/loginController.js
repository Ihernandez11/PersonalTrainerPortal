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

        $scope.LoginUser = function (user) {
            $http.post("/home/loginuser", user)
        }


        }

    app.controller("LoginController", LoginController);
}());

