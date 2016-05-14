'use strict';

//Articles service used for communicating with the articles REST endpoints
app.factory('Categories', ['$resource',
    function ($resource) {
        return $resource('http://blogbook/Blogbook.Api.Web/Api/Categories/:categoriesId', {
            categoriesId: '@_id'
        },
        {
            update: {
                method: 'PUT'
            }
        });
    }
]);
