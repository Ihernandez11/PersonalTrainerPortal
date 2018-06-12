﻿(function () {
    var app = angular.module("AuthModule", []);
    //LoginController
    var LoginController = function ($scope, $http, $window) {

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

    app.controller("LoginController", ["$scope", "$http", "$window", LoginController]);

    var RegisterController = function ($scope, $http, $window) {

        $scope.RegisterUser = function (user) {
            $http.post("/home/registeruser", user).then(function (response) {
                //console.log(response)

                //Redirect if success
                if (response.data.registerStatus == "success") {
                    //Redirect to PT/index page with the userID
                    $window.location.href = '/personaltrainer/index?UID=' + response.data.UID;
                }

                if (response.data.registerStatus == "modelfail") {
                    //console.log(response.data);
                    //create a scope variable with the errors returned in the response
                    $scope.errorMessages = response.data.errors;

                    //console.log($scope.errorMessages);

                    
            }

                //Reload page with error if fail
                if (response.data.registerStatus == "fail") {
                    //console.log(response.data);

                    $scope.errorMessages = response.data.result.Errors;
                }
            })

        }

    }

    app.controller("RegisterController", ["$scope", "$http", "$window", RegisterController]);
}());

