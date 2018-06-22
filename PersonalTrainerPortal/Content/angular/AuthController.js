﻿(function () {
    //Main App
    var app = angular.module("MainModule", ['ngRoute']);


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

    //Register Controller
    var RegisterController = function ($scope, $http, $window) {

        $scope.RegisterUser = function (user) {
            $http.post("/home/registeruser", user).then(function (response) {
                //console.log(response)

                //Redirect if success
                if (response.data.registerStatus == "success") {
                    console.log(user.UserType);
                    //Redirect to PT/index page with the userID if it's a trainerType is true
                    if (user.UserType == "trainer") {
                        $window.location.href = '/personaltrainer/index?UID=' + response.data.UID;
                    }

                    //Redirect to Client/index page with userID if ClientType is true
                    if (user.UserType == "client") {
                        $window.location.href = '/client/index?UID=' + response.data.UID;
                    }

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


    //Exercise Controller
    var ExerciseController = function ( $route, $routeParams) {



        //Get Exercises
        var param1 = $route;
        console.log(param1);


        

        //Create Exercise
        //$scope.CreateExercise = function (exercise) {
        //    $http.post("/personaltrainer/createexercise", exercise).then(function (response) {


        //    })


        //Edit Exercise

        //Delete Exercise

    }


    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/personaltrainer/exercises', {
                templateUrl: 'exercises',
                controller: 'ExerciseController'
            });
    })

    app.controller("ExerciseController", [ "$route", "$routeParams", ExerciseController]);


//closing app function bracket
}());

