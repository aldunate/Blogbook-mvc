

app.controller('HomeController',
	['$scope','Articles', '$location',
function ($scope, Articles) {
       
        $scope.authentication = true;

        $scope.user = "Adolfo Alduante"
        $scope.find = function () {            
            $scope.articles = Articles.query({});

           
        };
        
}]);

