

//Articles service used for communicating with the articles REST endpoints
app.factory('Blogs', ['$resource',
	function ($resource) {

	    return $resource('http://blogbook/Blogbook.Api.Web/Api/Blogs/:blogId', {

	        blogId: '@_id'
	    }, {
	        update: {
	            method: 'PUT'
	        }
	    });

	}]);