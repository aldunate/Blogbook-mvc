'use strict';

//Blogs service used to communicate Blogs REST endpoints
app.factory('Blogs', ['$resource',
	function ($resource) {
	    return $resource('http://blogbook/Blogbook.Api.Web/Api/Blog/:blogId', {
	        blogId: '@_id'
	    }, {
	        update: {
	            method: 'PUT'
	        }
	    });
	}
]);