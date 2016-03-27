
// Article route

app.config(['$routeProvider', function ($routeProvider) {


    $routeProvider.when('/articles/nuevos', {
        templateUrl: 'App/Articles/Views/nuevos.article.html'
    });
    $routeProvider.when('/articles/follow', {
        templateUrl: 'App/Articles/Views/follow.article.html'
    });
    $routeProvider.when('/articles/vistos', {
        templateUrl: 'App/Articles/Views/masVistos.article.html'
    });

    $routeProvider.when('/articles/create', {
        templateUrl: 'App/Articles/Views/create.article.html'
    });
    $routeProvider.when('/articles/:articleId/edit', {
        templateUrl: 'App/Articles/Views/edit.article.html'
    });
    $routeProvider.when('/', {
        templateUrl: "App/Articles/Views/home.html"
    });
}


}
]);

