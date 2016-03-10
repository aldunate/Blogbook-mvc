'use strict';

// Blogs controller
app.controller('BlogsController', ['$scope', '$stateParams', 'Blogs','$location',
	function ($scope, $stateParams, Blogs, $location) {


		// Create new Blog
		$scope.create = function () {
			// Create new Blog object
			/*var blog = new Blogs({
				name: this.name
			});

			// Redirect after save
			blog.$save(function (response) {
				$location.path('blogs/' + response._id);

				// Clear form fields
				$scope.name = '';
			}, function (errorResponse) {
				$scope.error = errorResponse.data.message;
			});
            */
		};

		// Remove existing Blog
		$scope.remove = function (blog) {
			/*if (blog) {
				blog.$remove();

				for (var i in $scope.blogs) {
					if ($scope.blogs[i] === blog) {
						$scope.blogs.splice(i, 1);
					}
				}
			} else {
				$scope.blog.$remove(function () {
					$location.path('blogs');
				});
			}*/
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

		// Find a list of Blogs
		$scope.find = function () {
		    $scope.blogs = Blogs.query();
		    $scope.blogs.$promise.then(function (result) {
		        $scope.blogs = result;
		    });
		};

		// Find a list of follow Blogs
		$scope.findFollow = function () {
			$scope.blogs = Blogs.query();
		};

        /*
		// Find existing Blog
		$scope.findOne = function () {
			$scope.blog = Blogs.get({
				blogId: $stateParams.blogId
			}).$promise.then(function (data) {
				$scope.articlesBlog = Articles.query({
					userId: data.user._id
				});

			});

		};*/

	}
]);
