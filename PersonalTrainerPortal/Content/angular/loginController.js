(function () {
    var app = angular.module("LoginModule", []);
    var LoginController = function ($scope, $http, $window) {


        var onUserComplete = function (response) {
            console.log(response.data);
            //$scope.loginCredentials = response.data;
        }
        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        }

        $scope.LoginUser = function (user) {
            $http.post("/home/loginuser", user).then(function (response) {
                console.log(response)

                if (response.data.signInStatus == "success") {
                    //Redirect using window.location.href to the PT/index page using the userID parameter
                    $window.location.href = '/personaltrainer/index?UID=' + response.data.UID;
                }
            })
        }


        }

    app.controller("LoginController", LoginController);
}());

