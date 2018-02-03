var productsListApp = angular.module('productsListApp', []);

productsListApp.controller('productsListController', function ($scope, $http) {
    $scope.products = [];
    $http({ method: 'Get', url: 'https://www.sima-land.ru/api/v3/category' })
        .then(function success(response) {
            $scope.products = response.data;
        });
});