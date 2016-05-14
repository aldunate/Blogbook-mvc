

//Articles service used for communicating with the articles REST endpoints
app.factory('Articles', ['$resource',
	function ($resource) {
	    return $resource('http://blogbook/Blogbook.Api.Web/Api/Article/:articleId', {
	        articleId: '@_id'
	    },
        {
            update: {
                method: 'PUT'
            }
        });

	}]);