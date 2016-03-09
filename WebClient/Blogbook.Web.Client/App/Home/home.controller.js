

app.controller('HomeController',
	['$scope','Articles', '$location',
function ($scope, Articles) {

        $scope.saludo = " Funcina Angular Se encuentra en Home";

        $scope.authentication = true;


        $scope.find = function () {
            
            $scope.articles = Articles.query();
            $scope.articles.$promise.then(function (result) {
                $scope.articles = result;
            });
            $scope.saludo = " Funcina Angular Se encuentra en Home";
        };

}]);

