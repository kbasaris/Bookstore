(function () {
    angular.module('BookStore', ['core', 'ui'])
    .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/books/addbook", {
                templateUrl: "Scripts/Spa/Books/addBook.html",
                controller: "addBookController"
            }).when("/books/getbook", {
                templateUrl: "Scripts/Spa/Books/getBook.html",
                controller: "getBookController"
            }).when("/Books/editBook/:id", {
                templateUrl: "Scripts/Spa/Books/editBook.html",
                controller: "editBookController"
            }).otherwise({ redirectTo: "/" });
    }
})();