

//Articles service used for communicating with the articles REST endpoints
app.factory('Home', ['$resource',
	function ($resource) {

	    return $resource('article/:articleId', {
            
            articleId: '@_id'
        }, {
            update: {
                method: 'PUT'
            }
        });

	}]);