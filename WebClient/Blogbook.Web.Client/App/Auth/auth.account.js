app.factory('Account', function($http) {
    return {
      getProfile: function() {
          return $http.get('/http://blogbook/Blogbook.Api.Web/Api/Auth');
      },
      updateProfile: function(profileData) {
          return $http.put('http://blogbook/Blogbook.Api.Web/Api/Auth', profileData);
      }
    };
  });