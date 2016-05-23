

app.controller('HomeController',
	['$scope','Articles','Categories', '$location',
function ($scope, Articles, Categories) {

    $scope.find = function () {
        $scope.articles = Articles.query({});
    };

    $scope.goPost = function (data) {
        Articles.get({
            id: data.Id,
            modo: "view"
        });
        data.KViews++;
    }
  
        
}]);

