'use strict';

// Blogs controller
app.controller('BlogsController', ['$scope', '$stateParams', 'Blogs','Articles','$location',
	function ($scope, $stateParams, Blogs,Articles, $location) {


    
		// Find existing Blog
	    $scope.findOne = function () {
	    };

		$scope.findNuevos = function () {
		    $scope.blogs = Blogs.query({});
		};
		$scope.findMasVistos = function(){
		    $scope.blogs = Blogs.query({});
		};

		$scope.findFollows = function () {
		    $scope.blogs = Blogs.query({});
		};

		$scope.goToBlog = function () {
		};





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
