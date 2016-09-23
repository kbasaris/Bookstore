(function (app) {
    'use strict'

    app.directive('mainHeader', mainHeader);

    function mainHeader() {
        return {
            restrict: 'AEC',
            replace: true,
            templateUrl: '/Scripts/Spa/Layout/mainHeader.html'
        }
    }

})(angular.module('ui'))