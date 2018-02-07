angular.module('productsListApp', ['ngRoute'])

    .config(function ($routeProvider, $locationProvider) {

        $locationProvider.hashPrefix('');

        $routeProvider
            .when('/', {
                controller: 'productsListController as productlist',
                templateUrl: 'Home/List'
            })
            .when('/edit/:ProductId', {
                controller: 'editProductController as editProduct',
                templateUrl: 'Home/detail'
            })
            .when('/new', {
                controller: 'addProductController as newProduct',
                templateUrl: 'Home/detail'
            })
            .otherwise({
                redirectTo: '/'
            });
    })
    .controller('productsListController', function ($scope, $http) {
        $scope.products = [];       
        $scope.Reflesh = function () {
            $http({ method: 'Get', url: '/api/values' })
                .then(function success(response) {
                    $scope.products = response.data;
                });
        };

        $scope.IDelete = function (DlProduct) {
            $http({ method: 'Delete', url: '/api/values/' + DlProduct })
                .then(function success(response) {
                    $scope.Reflesh();
                });
        };
        $scope.Reflesh();

    })
    .controller('editProductController', function ($scope, $http, $routeParams, $location) {
        var ProductId = $routeParams.ProductId;
        $scope.ProductName;
        $scope.Count;
        $scope.Price;
        $http({ method: 'Get', url: '/api/values/' + ProductId })
            .then(function success(response) {
                $scope.ProductName = response.data.ProductName;
                $scope.Count = response.data.Count;
                $scope.Price = response.data.Price;
            });
        $scope.Save = function () {
            $http({ method: 'Post', data: { ProductId: ProductId, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName }, url: '/api/values' })
                .then(function success(response) {
                    $location.path('/');
                });
        };

    })

.controller('addProductController', function ($scope, $http, $routeParams, $location) {
    $scope.Save = function () {
        $http({ method: 'Post', data: { ProductId: 0, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName }, url: '/api/values'})
            .then(function success(response) {
                $location.path('/');
            });
    };

});