
angular.module('WorkoutModule', ['ui.calendar'])


    .controller('WorkoutController', ['$scope', '$location', '$window', '$http',
        function ($scope, $location, $window, $http) {

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
        }])


    .controller('CalendarController', ['$scope', '$compile', 
        function ($scope, $compile) {
            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            /* config object */
            $scope.uiConfig = {
                calendar: {
                    height: 450,
                    editable: true,
                    header: {
                        left: 'month basicWeek basicDay agendaWeek agendaDay',
                        center: 'title',
                        right: 'today prev,next'
                    },
                    eventClick: $scope.alertEventOnClick,
                    eventDrop: $scope.alertOnDrop,
                    eventResize: $scope.alertOnResize
                }
            };

            $scope.events = [
                { title: 'All Day Event', start: new Date(y, m, 1) },
                { title: 'Long Event', start: new Date(y, m, d - 5), end: new Date(y, m, d - 2) },
                { id: 999, title: 'Repeating Event', start: new Date(y, m, d - 3, 16, 0), allDay: false },
                { id: 999, title: 'Repeating Event', start: new Date(y, m, d + 4, 16, 0), allDay: false },
                { title: 'Birthday Party', start: new Date(y, m, d + 1, 19, 0), end: new Date(y, m, d + 1, 22, 30), allDay: false },
                { title: 'Click for Google', start: new Date(y, m, 28), end: new Date(y, m, 29), url: 'http://google.com/' }
            ];

            
        }]) //closing controller brackets

