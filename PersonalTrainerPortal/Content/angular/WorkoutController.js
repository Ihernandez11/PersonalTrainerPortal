(function () {
    //Main App
    var app = angular.module("WorkoutModule", []);


    //WorkoutController
    var WorkoutController = function ($scope, $location, $window, $http) {
        

        var setExerciseScope = function (evmList) {
            $scope.evmList = evmList.data;
        }

        var onError = function () {
            $scope.errorMessage = "Cannot retreive exercises now. Try later.";
        }

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }

        var UID = getParameterByName('UID');
        

        $http.get("/personaltrainer/getexercises?UID=" + UID)
            .then(setExerciseScope, onError);
        
    }

    app.controller("WorkoutController", ["$scope", "$location", "$window", "$http", WorkoutController]);
    

    //closing app function bracket
}());

