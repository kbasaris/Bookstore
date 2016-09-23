(function (app) {
    'use strict';

    app.controller('getBookController', getBookController);
    getBookController.$inject = ['$scope', '$routeParams', 'apiService', 'notificationService'];

    function getBookController($scope, $routeParams, apiService, notificationService) {

        $scope.book;

        $scope.getBook = getBook;

        $scope.id;

        function getBook() {
            apiService.get('/api/Books/GetBook/'+$scope.id, null, bookLoadCompleted, bookLoadFailed)
        }

        function bookLoadCompleted(result) {
           $scope.book = result.data;
        }

        function bookLoadFailed(response) {
            notificationService.displayError(response.data);
        }
    }

})(angular.module('BookStore'));