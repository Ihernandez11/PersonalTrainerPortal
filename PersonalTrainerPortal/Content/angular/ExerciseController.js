(function () {
    //Main App
    var app = angular.module("ExerciseModule", ['ngRoute']);
    //Exercise Controller
    var ExerciseController = function ($http, $scope, $window, $route, $routeParams) {


        //Create Exercise
        $scope.CreateExercise = function (exercise) {
            $http.post("/personaltrainer/createexercise", exercise).then(function (response) {
                console.log(response.data);

                if (response.data.createStatus == "success") {
                    $window.location.href = '/personaltrainer/exercises?UID=' + response.data.UID;
                }

                if (response.data.createStatus == "fail") {
                    $scope.errorMessages = response.data.errors;
                }

            })

            //Edit Exercise

            //Delete Exercise

        }
    }


    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/personaltrainer/exercises', {
                templateUrl: 'exercises',
                controller: 'ExerciseController'
            });
    })

    app.controller("ExerciseController", ["$http", "$scope", "$window", "$route", "$routeParams", ExerciseController]);

}());