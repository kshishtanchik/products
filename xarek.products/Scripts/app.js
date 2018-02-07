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
            //.when('/new', {
            //    controller: 'NewProjectController as editProject',
            //    templateUrl: 'detail.html',
            //    resolve: resolveProjects
            //})
            .otherwise({
                redirectTo: '/'
            });
    })
    .controller('productsListController', function ($scope, $http) {
        $scope.headers = [
            {
                header: 'Идентификатор продукта',
                idHeader: 'id'
            },
            {
                header: 'Наименование продукта',
                idHeader: 'name'
            },
            {
                header: 'Количество товара',
                idHeader: 'count'
            },
            {
                header: 'Цена продукта',
                idHeader: 'price'
            }

        ];
        $scope.ProductId;
        $scope.ProductName;
        $scope.Count;
        $scope.Price;
        $scope.products = [];
        $scope.butt;
        $http({ method: 'Get', url: '/api/values' })
            .then(function success(response) {
                $scope.products = response.data;
            });

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



        $scope.change = function (ProductId) {
            if ($scope.ProductId !== $scope.products[ProductId].ProductId) {
                $scope.butt = "Создать";
            }
        };

    })
    .controller('editProductController', function ($scope, $http) {
        var ProductId = $routeParams.ProductId;
        $http({ method: 'Get', url: '/api/values/' + ProductId })
            .then(function success(response) {
                $scope.ProductId = response.data.ProductId;
                $scope.ProductName = response.data.ProductName;
                $scope.Count = response.data.Count;
                $scope.Price = response.data.Price;
            });
        $scope.Save = function () {
            $http({ method: 'Post', data: { ProductId: $scope.ProductId, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName }, url: '/api/values' })
                .then(function success(response) {
                    $location.path('/');
                });
        };
    });