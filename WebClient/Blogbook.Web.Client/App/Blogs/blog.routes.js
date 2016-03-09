'use strict';

//Setting up route
app.config(['$routeProvider',
	function ($routeProvider) {
	    // Blogs state routing
	    $routeProvider.when('/blogs',{
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/followBlogs', {
	        templateUrl: 'App/Blogs/Views/listFollow.blog.html'
	    });
	    $routeProvider.when('/blog/:blogId', {
	        templateUrl: 'App/Blogs/Views/view.blog.html'
	    });
	    $routeProvider.when('/blogs/:blogId/edit', {
	        templateUrl: 'App/Blogs/Views/edit.blog.html'
	    });

	}
]);
