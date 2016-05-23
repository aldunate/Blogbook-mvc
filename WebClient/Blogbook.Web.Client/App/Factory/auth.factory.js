
app.factory('$auth', function (valido) {
    return {
        valido: valido
    };
});
/*
batchModule.factory('routeTemplateMonitor', ['$route', 'batchLog', '$rootScope',
  function ($route, batchLog, $rootScope) {
      return {
          startMonitoring: function () {
              $rootScope.$on('$routeChangeSuccess', function () {
                  batchLog($route.current ? $route.current.template : null);
              });
          }
      };
  }]);*/


app.factory('$token', function (token) {
    return {
        token: token
    };
});