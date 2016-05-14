

app.controller('HomeController',
	['$scope','Articles','Categories', '$location',
function ($scope, Articles,Categories) {
       
    $scope.authentication = false;
    $scope.user = "Adolfo Alduante";
    $scope.find = function () { 
        $scope.articles = Articles.query({});
        $scope.categories = Categories.get();
        $scope.categories.repeat = null;
        $scope.category = "Todas";
    };
    $scope.changeCategory = function () {
        $scope.articles = Articles.query({
            category: this.category

        });
    }
  
        
}]);

