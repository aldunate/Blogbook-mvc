'use strict';

//Setting up route
app.config(['$routeProvider',
	function ($routeProvider) {
	    // Blogs state routing
	    $routeProvider.when('/blogs/masVistos',{
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/nuevos', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/deportes', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/moda', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/cine', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/politica', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/tecnologia', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
	    });
	    $routeProvider.when('/blogs/ciencia', {
	        templateUrl: 'App/Blogs/Views/list.blog.html'
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

