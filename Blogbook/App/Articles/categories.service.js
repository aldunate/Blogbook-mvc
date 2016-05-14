'use strict';

//Articles service used for communicating with the articles REST endpoints
app.factory('Categories', ['$resource',
    function ($resource) {
        return $resource('api/categories/:categoriesId', {
            categoriesId: '@_id'
        }, {
            get: {
                method: 'GET',
                isArray: true
            }
        });
    }
]);
