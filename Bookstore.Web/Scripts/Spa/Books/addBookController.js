(function (app) {
    'use strict';

    app.controller('addBookController', addBookController)

    addBookController.$inject = ['$scope','apiService','notificationService'];

    function addBookController($scope, apiService, notificationService) {
        $scope.book = {};
        $scope.AddBook = AddBook;


        function AddBook() {
            apiService.post('/api/Books/AddBook',
            $scope.book,
            AddBookSucceded,
            AddBookFailed);
        }

        function AddBookSucceded(response) {
            notificationService.displaySuccess($scope.book.title + ' has been submitted successfully');
            response.book = response.data;
        }

        function AddBookFailed(response) {
            notificationService.displayError(response.statusText);
        }
    }
})(angular.module('BookStore'));