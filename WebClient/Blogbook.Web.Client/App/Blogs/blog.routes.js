'use strict';

//Setting up route
app.config(['$routeProvider',
	function ($routeProvider) {


	    // Blogs state routing
	    $routeProvider.when('/blogs/masVistos',{
	        templateUrl: 'App/Blogs/Views/masVistos.blog.html'
	    });
	    $routeProvider.when('/blogs/nuevos', {
	        templateUrl: 'App/Blogs/Views/nuevos.blog.html'
	    });
	
	    $routeProvider.when('blogs/iFollow', {
	        templateUrl: 'App/Blogs/Views/listFollow.blog.html'
	    });
	    $routeProvider.when('/blogs/:blogId', {
	        templateUrl: 'App/Blogs/Views/view.blog.html'
	    });
	    $routeProvider.when('/blogs/:blogId/edit', {
	        templateUrl: 'App/Blogs/Views/edit.blog.html'
	    });

	}
]);

