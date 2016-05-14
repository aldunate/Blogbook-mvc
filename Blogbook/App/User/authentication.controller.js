

app.controller('AuthenticationController', ['$scope', '$uibModal', '$log','Authentication',
    function ($scope, $uibModal, $log, Authentication) {

        $scope.signin = function () {
            $scope.authentication = Authentication;
        };
        $scope.signup = function () {

        };
        $scope.exit = function () {

        };
        // MODAL AREA 
        $scope.openModalSignin = function (size) {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'user.signin.html',
                controller: 'loginController',
                size: size
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                // AL cerrar que hace -- la linea de abajo es inutil
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.openModalSignup = function (size) {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'user.signup.html',
                controller: 'loginController',
                size: size
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                // AL cerrar que hace -- la linea de abajo es inutil
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

    }]);


app.controller('loginController', function ($scope, $uibModalInstance) {

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});