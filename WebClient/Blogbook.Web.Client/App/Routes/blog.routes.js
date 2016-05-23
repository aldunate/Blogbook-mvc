'use strict';

//Setting up route
app.config(['$routeProvider',
	function ($routeProvider) {

	    $routeProvider.when('/blogs', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/follow', {
	        templateUrl: 'App/Blogs/Views/follow.blog.html'
	    });
	    $routeProvider.when('/blogs/:blogId', {
	        templateUrl: 'App/Blogs/Views/view.blog.html'
	    });
	    $routeProvider.when('/blogs/edit/:blogId', {
	        templateUrl: 'App/Blogs/Views/edit.blog.html'
	    });

	}

]);

