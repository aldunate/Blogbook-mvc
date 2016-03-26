

app.controller('HomeController',
	['$scope','Articles', '$location',
function ($scope, Articles) {
       
        $scope.authentication = true;
        $scope.user = "tomas";

        $scope.find = function () {            
            $scope.articles = Articles.query();
            $scope.articles.$promise.then(function (result) {
                $scope.articles = result;
            });
           
        };
        
}]);

