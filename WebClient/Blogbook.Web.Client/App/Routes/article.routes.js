
// Article route

app.config(['$routeProvider', function ($routeProvider) {


    $routeProvider.when('/articles/follow', {
        templateUrl: 'App/Articles/Views/follow.article.html'
    });
    $routeProvider.when('/articles', {
        templateUrl: 'App/Articles/Views/list.articles.html'
    });
    $routeProvider.when('/articles/create', {
        templateUrl: 'App/Articles/Views/create.article.html'
    });
    $routeProvider.when('/articles/:articleId/edit', {
        templateUrl: 'App/Articles/Views/edit.article.html'
    });
}
]);

