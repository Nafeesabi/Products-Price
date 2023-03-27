var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) 
    
    { 
    $http.get("/api/WebItems")
        .then(function (response) {
            $scope.myData = response.data;
        });
    $scope.Savechanges = function () {
        $http({
            method: 'POST',
            url: "/api/WebItems",
            data: $scope.save

        }).then(function (response) {
            $scope.ResponseText = "Saved";
            $scope.save = null;

        });


    }
    $http.get("/api/WebItems")
        .then(function (response) {
            $scope.products = response.data;
        });



    $scope.getData = function () {
        $http.get('/api/WebItems/' + $scope.ProductId).then(function (response) {
            $scope.price = response.data;
        })

    }
    $scope.DeleteData = function (id) {
        $http.delete("/api/WebItems/DeleteWebItems/" + id)
            .then(function (response) {
                alert('Successfully Deleted, Refresh The Page For Update');
            }, function (error) {
                alert('Already Deleted');
            });

    };
    
})


