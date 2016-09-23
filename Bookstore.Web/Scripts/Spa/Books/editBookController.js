(function(app){
    'use strict';

    app.controller("editBookController", editBookController);
    editBookController.$inject = ['$scope', 'apiService', 'notificationService', '$routeParams']

    function editBookController($scope, apiService, notificationService, $routeParams) {
        $scope.bookID;
        $scope.book;
        $scope.updateBook = updateBook;
        loadBook();

        function loadBook() {
            apiService.get('/api/Books/getbook/'+ $routeParams.id, null,
            bookLoadCompleted, bookLoadFailed);
        }

        function updateBook() {
            apiService.post('/api/Books/updatebook/', $scope.book,
            bookLoadCompleted, bookLoadFailed);
        }

        function bookLoadCompleted(result) {
            $scope.book = result.data;
        }
        function bookLoadFailed(response) {
            notificationService.displayError(response.data);
        }
    }
})(angular.module('BookStore'));