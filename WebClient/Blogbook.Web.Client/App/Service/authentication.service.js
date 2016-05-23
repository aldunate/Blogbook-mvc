'use strict';
/* // Authentication service for user variables
app.service('authentication', function ($http) {
    this.register = function (userInfo) {
        var resp = $http({
            url: "/api/Account/Register",
            method: "POST",
            data: userInfo
        });
        return resp;
    };
    this.login = function (userlogin) {
        var resp = $http({
            url: "/TOKEN",
            method: "POST",
            data: $.param({ grant_type: 'password', username: userlogin.username, password: userlogin.password }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });
        return resp;
    };
});*/

app.factory('Login', ['$resource',
	function ($resource) {
	    return $resource('http://blogbook/Blogbook.Api.Web/Api/User',
            {
	        update: {
	            method: 'PUT'
	        }
	    });
}]);
app.factory('Register', ['$resource',
	function ($resource) {
	    return $resource('http://blogbook/Blogbook.Api.Web/Api/User',
            {
                update: {
                    method: 'PUT'
                }
            });
}]);    