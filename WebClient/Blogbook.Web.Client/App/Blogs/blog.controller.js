'use strict';

// Blogs controller
app.controller('BlogsController', ['$scope', '$stateParams', 'Blogs', 'Articles','$location',
	function ($scope, $stateParams, $location, Blogs, Articles) {


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
			//$scope.blogs = Blogs.query();

			$scope.blogs =[
                {
                	"Created": "19/08/1999",
                	"Name": "Los Ojos de Osiris",
                	"User": "User",
                	"OriginalUrl": "http://www.publico.es/",
                	"ImageBlog": "http://www.publico.es/files/article_main//files/crop/uploads/2016/02/17/56c497228904b.r_1455726188032.0-93-700-454.jpg",
                	"KViews": 8232184,
                	"KFollowers": 746,
                	"Description": "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry s<br> standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using Content here, content here, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for lorem ipsum will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                	"Categories": ["Politica", "Conspiracion"]

                }];

		};

		// Find a list of follow Blogs
		$scope.findFollow = function () {
			//$scope.blogs = Blogs.query();

			$scope.blogs = [
                {
                	"Created": "19/08/1999",
                	"Name": "Los Ojos de Osiris",
                	"User": "User",
                	"OriginalUrl": "http://www.publico.es/",
                	"ImageBlog": "http://www.publico.es/files/article_main//files/crop/uploads/2016/02/17/56c497228904b.r_1455726188032.0-93-700-454.jpg",
                	"KViews": 8232184,
                	"KFollowers": 746,
                	"Description": "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry s<br> standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using Content here, content here, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for lorem ipsum will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                	"Categories": ["Politica", "Conspiracion"]

                }];

		};


		// Find existing Blog
		$scope.findOne = function () {
			/*$scope.blog = Blogs.get({
				blogId: $stateParams.blogId
			}).$promise.then(function (data) {
				$scope.articlesBlog = Articles.query({
					userId: data.user._id
				});

			});*/

			$scope.blog = {
				"Created": "19/08/1999",
				"Name": "Los Ojos de Osiris",
				"User": "User",
				"OriginalUrl": "http://www.publico.es/",
				"ImageBlog": "http://www.publico.es/files/article_main//files/crop/uploads/2016/02/17/56c497228904b.r_1455726188032.0-93-700-454.jpg",
				"KViews": 8232184,
				"KFollowers": 746,
				"Description": "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry s<br> standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using Content here, content here, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for lorem ipsum will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
				"Categories": ["Politica", "Conspiracion"]

			};
		};

	}
]);
