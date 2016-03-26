//use 'strict';

var app = angular.module('app', ['ngRoute', 'ngResource','ngAnimate', 'ui.bootstrap', 'ui.router']);

app.config(['$resourceProvider', function ($resourceProvider) {
    // Don't strip trailing slashes from calculated URLs
    $resourceProvider.defaults.stripTrailingSlashes = false;
}]);

