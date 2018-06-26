﻿
angular.module('WorkoutModule', ['ui.calendar'])


    .controller('ExerciseController', ['$scope', '$location', '$window', '$http',
        function ($scope, $location, $window, $http) {

            var setExerciseScope = function (evmList) {
                $scope.evmList = evmList.data;
            }


            var onError = function () {
                $scope.errorMessage = "Cannot retreive now. Try later.";
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
            var CID = getParameterByName('CID');

            $http.get("/personaltrainer/getexercises?UID=" + UID)
                .then(setExerciseScope, onError);

            

            //Set evmList.Exercise title = Workout.exerciseTitle
            $scope.openExercisePopup = function (exerciseTitle) {
                $scope.ExerciseName = exerciseTitle;
                console.log("button clicked");
                //$("#exerciseTitleForm").attr("placeholder", exerciseTitle);
                $("#exerciseTitleForm").attr("value", exerciseTitle);


            }

            

            
        }])


    .controller('WorkoutController', ['$scope', '$location', '$window', '$http',
        function ($scope, $location, $window, $http) {

            function getParameterByName(name, url) {
                if (!url) url = window.location.href;
                name = name.replace(/[\[\]]/g, "\\$&");
                var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                    results = regex.exec(url);
                if (!results) return null;
                if (!results[2]) return '';
                return decodeURIComponent(results[2].replace(/\+/g, " "));
            }
            
            var setWorkoutScope = function (workouts) {
                $scope.workouts = workouts.data;
            }

            var onError = function () {
                $scope.errorMessage = "Cannot retreive now. Try later.";
            }

            var UID = getParameterByName('UID');
            var CID = getParameterByName('CID');


            $http.get("/personaltrainer/getworkout?UID=" + UID + "&CID=" + CID)
                .then(setWorkoutScope, onError);


        }])

    .controller('ClientWorkoutController', ['$scope', '$location', '$window', '$http',
        function ($scope, $location, $window, $http) {

            function getParameterByName(name, url) {
                if (!url) url = window.location.href;
                name = name.replace(/[\[\]]/g, "\\$&");
                var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                    results = regex.exec(url);
                if (!results) return null;
                if (!results[2]) return '';
                return decodeURIComponent(results[2].replace(/\+/g, " "));
            }

            var setWorkoutScope = function (workouts) {
                $scope.workouts = workouts.data;
            }

            var onError = function () {
                $scope.errorMessage = "Cannot retreive now. Try later.";
            }
            
            var UID = getParameterByName('UID');


            $http.get("/client/getworkout?UID=" + UID)
                .then(setWorkoutScope, onError);


        }])

    


    .controller('CalendarController', ['$scope', '$compile', 
        function ($scope, $compile) {
            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            //$scope.eventSource = {
            //    url: "http://www.google.com/calendar/feeds/usa__en%40holiday.calendar.google.com/public/basic",
            //    className: 'gcal-event',           // an option!
            //    currentTimezone: 'America/Chicago' // an option!
            //};

            //$scope.eventSource = {
            //    url: "testurl",
            //    className: 'testClass',
            //    currentTimeZone: 'America/Chicago'
            //};


            /* event source that contains custom events on the scope */
            $scope.events = [
                { title: 'All Day Event', start: new Date(y, m, 1) },
                { title: 'Long Event', start: new Date(y, m, d - 5), end: new Date(y, m, d - 2) },
                { id: 999, title: 'Repeating Event', start: new Date(y, m, d - 3, 16, 0), allDay: false },
                { id: 999, title: 'Repeating Event', start: new Date(y, m, d + 4, 16, 0), allDay: false },
                { title: 'Birthday Party', start: new Date(y, m, d + 1, 19, 0), end: new Date(y, m, d + 1, 22, 30), allDay: false },
                { title: 'Click for Google', start: new Date(y, m, 28), end: new Date(y, m, 29), url: 'http://google.com/' }
            ];
            /* event source that calls a function on every view switch */
            $scope.eventsF = function (start, end, timezone, callback) {
                var s = new Date(start).getTime() / 1000;
                var e = new Date(end).getTime() / 1000;
                var m = new Date(start).getMonth();
                var events = [{ title: 'Feed Me ' + m, start: s + (50000), end: s + (100000), allDay: false, className: ['customFeed'] }];
                callback(events);
            };

            $scope.calEventsExt = {
                color: '#f00',
                textColor: 'yellow',
                events: [
                    { type: 'party', title: 'Lunch', start: new Date(y, m, d, 12, 0), end: new Date(y, m, d, 14, 0), allDay: false },
                    { type: 'party', title: 'Lunch 2', start: new Date(y, m, d, 12, 0), end: new Date(y, m, d, 14, 0), allDay: false },
                    { type: 'party', title: 'Click for Google', start: new Date(y, m, 28), end: new Date(y, m, 29), url: 'http://google.com/' }
                ]
            };
            /* alert on eventClick */
            $scope.alertOnEventClick = function (date, jsEvent, view) {
                $scope.alertMessage = (date.title + ' was clicked ');
            };
            /* alert on Drop */
            $scope.alertOnDrop = function (event, delta, revertFunc, jsEvent, ui, view) {
                $scope.alertMessage = ('Event Droped to make dayDelta ' + delta);
            };
            /* alert on Resize */
            $scope.alertOnResize = function (event, delta, revertFunc, jsEvent, ui, view) {
                $scope.alertMessage = ('Event Resized to make dayDelta ' + delta);
            };
            /* add and removes an event source of choice */
            $scope.addRemoveEventSource = function (sources, source) {
                var canAdd = 0;
                angular.forEach(sources, function (value, key) {
                    if (sources[key] === source) {
                        sources.splice(key, 1);
                        canAdd = 1;
                    }
                });
                if (canAdd === 0) {
                    sources.push(source);
                }
            };

            /* add custom event*/
            $scope.addEvent = function () {
                console.log("button clicked");
                $scope.events.push({
                    title: 'Open Sesame',
                    start: new Date(y, m, 28),
                    end: new Date(y, m, 29),
                    className: ['openSesame']
                });
            };

            /* remove event */
            $scope.remove = function (index) {
                $scope.events.splice(index, 1);
            };

            /* Change View */
            $scope.changeView = function (view, calendar) {
                uiCalendarConfig.calendars[calendar].fullCalendar('changeView', view);
            };

            /* Change View */
            $scope.renderCalender = function (calendar) {
                if (uiCalendarConfig.calendars[calendar]) {
                    uiCalendarConfig.calendars[calendar].fullCalendar('render');
                }
            };

            /* Render Tooltip */
            $scope.eventRender = function (event, element, view) {
                element.attr({
                    'tooltip': event.title,
                    'tooltip-append-to-body': true
                });
                $compile(element)($scope);
            };

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
                    eventClick: $scope.alertOnEventClick,
                    eventDrop: $scope.alertOnDrop,
                    eventResize: $scope.alertOnResize,
                    eventRender: $scope.eventRender
                }
            };

            
            /* event sources array*/
            $scope.eventSources = [$scope.events, $scope.eventsF];
            $scope.eventSources2 = [$scope.calEventsExt, $scope.eventsF, $scope.events];
        }]) //closing controller brackets

