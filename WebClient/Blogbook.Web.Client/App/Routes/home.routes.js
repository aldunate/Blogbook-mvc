

// Homes route

app.config(['$routeProvider', function($routeProvider) {

    $routeProvider.when('/', {
            templateUrl: "App/Home/Views/home.html"
    });
    $routeProvider.otherwise({ redirectTo: "/" });
    }
]);