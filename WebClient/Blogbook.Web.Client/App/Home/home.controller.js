

app.controller('HomeController',
	['$scope','Articles','Categories', '$location',
function ($scope, articles,categories) {
       
    $scope.authentication = false;
    $scope.user = "Adolfo Alduante";
    $scope.find = function () { 
        $scope.articles = articles.query({});
        $scope.categories = categories.get();
        $scope.categories.repeat = null;
        $scope.category = "Todas";
    };
    $scope.changeCategory = function () {
        $scope.articles = articles.query({
            category: this.category

        });
    }
  
        
}]);

