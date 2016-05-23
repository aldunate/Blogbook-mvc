

app.controller('AuthenticationController', ['$scope', '$log', 'Login', 'Register',
    function ($scope, $log, Login, Register) {

        if (sessionStorage.valido === undefined) $scope.authentication = false;
        else $scope.authentication = true;

        var refreshAuth = function (valid) {
            $scope.authentication = valid;
        }
        //Scope Declaration
        $scope.userName = "";
        $scope.userRegistrationName = "";
        $scope.userRegistrationPassword = "";
        $scope.userRegistrationConfirmPassword = "";
        $scope.userLoginName = "";
        $scope.userLoginPassword = "";    

        //Function to register user
        $scope.registerUser = function () {
            // REGISTER QUERY
            Register.save({
                Name: $scope.userRegistrationName,
                Password: $scope.userRegistrationPassword
            }).$promise.then(function (data) {
                if (data.Validado === true) {
                    sessionStorage.token = data.Token;
                    sessionStorage.valido = true;
                    sessionStorage.IdBlog = data.IdBlog;
                    refreshAuth(true);
                    $scope.errorRegister = "";
                } else {
                    delete sessionStorage.token;
                    delete sessionStorage.valido;
                    delete sessionStorage.IdBlog;
                    refreshAuth(false);
                    $scope.errorRegister = "El usuario ya existe";
                }
            });
        };
       
        //FUNCTION LOGIN 
        $scope.login = function () {
            Login.get({
                    Name: $scope.userLoginName,
                    Password: $scope.userLoginPassword
                }).
                $promise.then(function(data) {
                    if (data.Validado === true) {
                        sessionStorage.token = data.Token;
                        sessionStorage.valido = true;
                        sessionStorage.IdBlog = data.IdBlog;
                        refreshAuth(true);
                        $scope.errorLogin = "";
                    } else {
                        delete sessionStorage.token;
                        delete sessionStorage.valido;
                        delete sessionStorage.IdBlog;
                        refreshAuth(false);
                        $scope.errorLogin = "Usuario o contraseña incorrecta";
                    }
                });
        };

        //FUNCTION LOGOUT 
        $scope.logout = function() {
            Login.query({
                Token: sessionStorage.token,
                Modo: "borrar"
        });
            delete sessionStorage.token;
            delete sessionStorage.valido;
            delete sessionStorage.IdBlog;
            refreshAuth(false);
        }

        $scope.GetUserBlogId = function() {
            $scope.userBlogId = sessionStorage.IdBlog;
        }

        // REFRESH TOKEN
        $scope.refreshToken = function() {
            Login.get({
                Token: sessionStorage.token
        }).
            $promise.then(function (resp) {
                sessionStorage.token = data.Token;
                sessionStorage.valido = data.Validado;
                $scope.authentication = data.Validado;
            }, function (err) {
                
            });
        }

    }]);


