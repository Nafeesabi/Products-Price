//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
//app.controller('myCtrl', function ($scope, $http) {
//    // Define your data source variables
//    $scope.pName = [];
//    $scope.price = [];

//    // Define a function to retrieve countries from the API
//    $scope.myData = function () {
//        $http.get('/api/WebItems')
//            .then(function (response) {
//                $scope.pName = response.data;
//            });
//    };

//    // Define a function to retrieve cities from the API based on the selected country
//    $scope.myData = function () {
//        $http.get('/api/WebItems?Id=' + $scope.save.pname.id)
//            .then(function (response) {
//                $scope.price = response.data;
//            });
//    };
//});

//app.controller('priceCtrl', function ($scope, $http) {
//    $http.get("/api/WebItems")
//        .then(function (response) {
//            $scope.products = response.data;
//        });



//    $scope.getData = function () {
//        $http.get('/api/WebItems/' + $scope.ProductId).then(function (response) {
//            $scope.price = response.data;
//        })

//    }

//});