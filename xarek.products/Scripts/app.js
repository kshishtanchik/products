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
            .when('/delete/:ProductId', {
                controller: 'deleteProductController as delProduct',
                templateUrl: 'Home/List'
            })
                .otherwise({
                    redirectTo: '/'
                });
    })

    .controller('productsListController', function ($scope, $http) {
        $scope.Deleted = {};
        
        $scope.products = [];
        $scope.Reflesh = function () {
            $http({ method: 'Get', url: '/api/values' })
                .then(function success(response) {
                    $scope.products = response.data;
                });
            
        };
        $scope.ConfirmDelete = function (product) {
            $scope.Deleted = product;
        };
        $scope.Delete = function () {
            $http({ method: 'Delete', url: '/api/values/' + $scope.Deleted.ProductId })
                .then(function success(response) {
                    $scope.Reflesh();
                });
        };
        $scope.Reflesh();
    })

    .controller('editProductController', function ($scope, $http, $routeParams, $location) {
        var ProductId = $routeParams.ProductId;
        $scope.formName = 'Редактирование продукта';
        $scope.cont = 'Состав продукта';
        $scope.ProductName;
        $scope.Count;
        $scope.Price;
        $scope.Consists = [{ Content: '', countConsist: 0 }];
        $http({ method: 'Get', url: '/api/values/' + ProductId })
            .then(function success(response) {
                $scope.ProductName = response.data.ProductName;
                $scope.Count = response.data.Count;
                $scope.Price = response.data.Price;
                $scope.Consists = response.data.Consists;
            });
        $scope.addConsist = function () {
            $scope.Consists.push({ Content: '', countConsist: 0 });
        };
        $scope.delConist = function (item) {
            $scope.Consists.splice($scope.Consists.indexOf(item),1);
        }
        $scope.Save = function () {
            $http({ method: 'Post', data: { ProductId: ProductId, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName, Consists: $scope.Consists }, url: '/api/values' })
                .then(function success(response) {
                    $location.path('/');
                });
        };
        $scope.editCell = function () {
            $scope.ConistsLabel.show(blind);
            $scope.Consists.hide(blind);
        }
    })

    .controller('addProductController', function ($scope, $http, $routeParams, $location) {
        $scope.formName = 'Добавление продукта:';
        $scope.Consists = [{ Content: '', countConsist: 0 }];
        $scope.Save = function () {
            $http({ method: 'Post', data: { ProductId: 0, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName, Consists: $scope.Consists  }, url: '/api/values' })
                .then(function success(response) {
                    $location.path('/');
                });
        };

        $scope.addConsist = function () {
            $scope.Consists.push({ Content: '', countConsist: 0 });
        };

        $scope.delConist = function (item) {
            $scope.Consists.splice($scope.Consists.indexOf(item), 1);
        };
    })

    .controller('deleteProductController', function ($scope, $http, $routeParams, $location) {
        var ProductId = $routeParams.ProductId;
        $http({ method: 'Delete', url: '/api/values/'+ ProductId})
                .then(function success(response) {
                    $location.path('/');
            });
    });