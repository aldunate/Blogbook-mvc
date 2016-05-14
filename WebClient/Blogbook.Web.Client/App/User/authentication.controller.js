

app.controller('AuthenticationController', ['$scope', '$uibModal', '$log', 'authentication',
    function ($scope, $uibModal, $log, authentication) {
        
        // MODAL AREA 
        $scope.openModalSignin = function (size) {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'user.signin.html',
                controller: 'AuthenticationController',
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
                controller: 'AuthenticationController',
                size: size
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                // AL cerrar que hace -- la linea de abajo es inutil
                $log.info('Modal dismissed at: ' + new Date());
            });
        };
        $scope.cancel = function () {
            this.$dismiss('cancel');
        };


       // function ($scope, authentication, $uibModalInstance) { 

        //Scope Declaration
        $scope.responseData = "";
        $scope.userName = "";
        $scope.userRegistrationEmail = "";
        $scope.userRegistrationPassword = "";
        $scope.userRegistrationConfirmPassword = "";
        $scope.userLoginEmail = "";
        $scope.userLoginPassword = "";
        $scope.accessToken = "";
        $scope.refreshToken = "";
        //Ends Here


        //Function to register user
        $scope.registerUser = function () {

            $scope.responseData = "";

            //The User Registration Information
            var userRegistrationInfo = {
                Email: $scope.userRegistrationEmail,
                Password: $scope.userRegistrationPassword,
                ConfirmPassword: $scope.userRegistrationConfirmPassword
            };

            var promiseregister = authentication.register(userRegistrationInfo);

            promiseregister.then(function (resp) {
                $scope.responseData = "User is Successfully";
                $scope.userRegistrationEmail = "";
                $scope.userRegistrationPassword = "";
                $scope.userRegistrationConfirmPassword = "";
            }, function (err) {
                $scope.responseData = "Error " + err.status;
            });
        };


        $scope.redirect = function () {
            window.location.href = '/Employee/Index';
        };

        //Function to Login. This will generate Token 
        $scope.login = function () {
            //This is the information to pass for token based authentication
            var userLogin = {
                grant_type: 'password',
                username: $scope.userLoginEmail,
                password: $scope.userLoginPassword
            };

            var promiselogin = authentication.login(userLogin);

            promiselogin.then(function (resp) {

                $scope.userName = resp.data.userName;
                //Store the token information in the SessionStorage
                //So that it can be accessed for other views
                sessionStorage.setItem('userName', resp.data.userName);
                sessionStorage.setItem('accessToken', resp.data.access_token);
                sessionStorage.setItem('refreshToken', resp.data.refresh_token);
                window.location.href = '/';
            }, function (err) {

                $scope.responseData = "Error " + err.status;
            });

        };


}]);


