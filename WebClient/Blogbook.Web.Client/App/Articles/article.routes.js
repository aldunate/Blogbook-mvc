
// Article route

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/articles', {
        templateUrl: 'App/Articles/Views/list.article.html'
    });
    $routeProvider.when('/articles/create', {
        templateUrl: 'App/Articles/Views/create.article.html'
    });
    $routeProvider.when('/articles/:articleId/edit', {
        templateUrl: 'App/Articles/Views/edit.article.html'
    });


}
]);

