'use strict';

// Blogs controller
app.controller('BlogsController', ['$scope', '$stateParams', 'Blogs','Articles','Categories','$routeParams', '$location',
	function ($scope, $stateParams, blogs, Articles, Categories,$routeParams, $location) {
    
	    $scope.btnFollow = false;
		// Find existing Blog
	    $scope.findOne = function () {
	        var idParam = $routeParams.blogId;
	        blogs.get({ blogId: idParam, token: sessionStorage.token })
                .$promise.then(function (resp) {
                    $scope.blog = resp;
                    if (resp.AuxFollow === true) $scope.btnFollow = false; // No ver si ya lo sigue
                    else $scope.btnFollow = true;
                    if ($scope.blog.ImageBlog != undefined) $scope.imgExiste = true;
                    else $scope.imgExiste = false;
                    $scope.articles = Articles.query({
                        blogId: idParam
                    });
	            });  
	    };

	    $scope.findOneEdit = function () {
	        var idParam = $routeParams.blogId;
	        blogs.get({ blogId: idParam })
                .$promise.then(function (response) {
                    $scope.blog = response;
                    if ($scope.blog.ImageBlog != undefined) $scope.imgExiste = true;
                    else $scope.imgExiste = false;
                    Categories.get().$promise.then(function (resp) {
                        $scope.categories = resp;
                        $scope.categories.repeat = null;
                        $scope.category = $scope.blog.categories;
                    });
                });
	    };
	   
		$scope.findBlogs = function () {
		    $scope.blogs = blogs.query({
		    });
		};

		$scope.findFollow = function () {
		    $scope.blogs = blogs.query({
		        follow : sessionStorage.token
		    });
		    
		};

		$scope.goToBlog = function () {
		};

		$scope.addFollow = function (id) {
		    $scope.btnFollow = false;
            blogs.get({
                tokenString: sessionStorage.token,
                blog: id
            });
        }



	    // Update existing Blog
		$scope.update = function () {
		    var blog = $scope.blog;
		    blog.IdString = blog.Id.toString();
		    blog.$save({Token: sessionStorage.token},function (response) {
			    $location.path('blogs/' + $routeParams.blogId);
			}, function (errorResponse) {
				$scope.error = errorResponse.data.message;
			});
		};
        
	}
]);
