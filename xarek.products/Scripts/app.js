
var productsListApp = angular.module('productsListApp', []);

productsListApp.controller('productsListController', function ($scope, $http) {
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
        $http({ method: 'Delete', url: '/api/values/'+DlProduct })
            .then(function success(response) {
                $scope.Reflesh();
            });
    };
    
    $scope.IAdd = function () {
        $http({ method: 'Post', data: { ProductId: $scope.ProductId, Count: $scope.Count, Price: $scope.Price, ProductName: $scope.ProductName }, url: '/api/values' })
            .then(function success(response) {
                $scope.Reflesh();
            });
    };
    //$scope.Edit = function (id, count, price, name, OldItem) {
    //    $http({ method: 'Put', data: { id: id, count: count, price: price, name: name, OldItem: OldItem }, url: '/api/values' })
    //        .then(function success(response) {
    //            $scope.Reflesh();
    //        });
    //};
}); 