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

                //Redirect if success
                if (response.data.signInStatus == "success") {
                    //Redirect using window.location.href to the PT/index page using the userID parameter
                    $window.location.href = '/personaltrainer/index?UID=' + response.data.UID;
                }
                //Reload page if failure
                if (response.data.signInStatus == "fail") {
                    $scope.errorMessage = "Invalid Login. Please try again."
                }

            })
        }


        }

    app.controller("LoginController", LoginController);
}());

