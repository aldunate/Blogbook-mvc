'use strict';

// Blogs controller
app.controller('BlogsController', ['$scope', '$stateParams', 'Blogs','Articles','$location',
	function ($scope, $stateParams, Blogs,Articles, $location) {


		// Find a list of Blogs
		$scope.findBlogs = function () {
		    var c = location.hash.split('/');
		    c = c[2];
		    c = c.substring(0, 1).toUpperCase() + c.substring(1);

		    switch (c) {
		        case "Nuevos":
		            $scope.blogs = Blogs.query({ ultimos: c }, function (result) {
		                $scope.blogs = result;
		            });
		            break;
		        case "MasVistos":
		            $scope.blogs = Blogs.query({ masVistos: c }, function (result) {
		                $scope.blogs = result;
		            });
		            break;
		        default:
		            $scope.blogs = Blogs.query({ Categories: c }, function (result) {
		                $scope.blogs = result;
		            });
		            break;
		    }

		   
		};      
		// Find existing Blog
		$scope.findOne = function () {

		    var c = location.hash.split('/');
		    c = c[2];

			$scope.blog = Blogs.get({
				blogId: c
			}, function (res) {
			    $scope.blog = res;
			    Articles.query({ BlogId: c }, function (r)
			    {
			        $scope.articlesBlog = r;
			    });

	    })};


	    // Update existing Blog
		$scope.update = function () {
		    /*var blog = $scope.blog;

			blog.$update(function () {
				$location.path('blogs/' + blog._id);
			}, function (errorResponse) {
				$scope.error = errorResponse.data.message;
			});*/
		};
        
	}
]);
