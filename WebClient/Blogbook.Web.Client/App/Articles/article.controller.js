

app.controller('ArticlesController',
	['$scope', 'Articles', 'BlogAnalyzer', 'Categories', '$stateParams', '$location',
function ($scope, Articles, BlogAnalyzer, Categories, $stateParams, $location) {

   

    $scope.initCreate = function () {
        // Caraga selector de categorias
        Categories.get().$promise.then(function (resp) {
            $scope.categories = resp;
            $scope.categories.repeat = null;
            $scope.category = "Todas";
        });
    }

    $scope.find = function () {
        Categories.get().$promise.then(function (resp) {
            $scope.categories = resp;
            $scope.categories.repeat = null;
            $scope.category = "Todas";
        });
        $scope.articles = Articles.query({});
    };
    $scope.changeCategory = function () {
        $scope.articles = Articles.query({
            category: this.category
        });
    }
    $scope.goPost = function (data) {
        Articles.get({
            id: data.Id,
            modo: "view"
        });
        data.KViews++;
    }

    $scope.focusArticulo = function () {

    };


    $scope.findFollow = function () {
        $scope.articles = Articles.query({
            followToken:sessionStorage.token
        });
    };


    //Enviar URL, a blogAnalyzer
    $scope.sendURL = function () {

        /*
        var timerId;
        var analyzer = new BlogAnalyzer({
            blogUrl: this.contentUrl
        });
        $scope.mostrarFormulario = false;
        analyzer.$save()
        .then(function (response) {
            timerId = $interval(function () {
                BlogAnalyzer.get({
                    blog_analyzerId: response.id
                }).$promise.then(function (data) {
                    if (data.state === 'Error') {
                        $interval.cancel(timerId);
                        $scope.blogAnalyzer = 'error';
                        $scope.sliderPosition = null;
                    }
                    if (data.state === 'Ok') {
                        $interval.cancel(timerId);
                        $scope.blogAnalyzer = data;
                        $scope.sliderPosition = data.imageUrls[0];
                        $scope.sliderShow = true;
                    }
                });

                // Tiempo de espera antes de llamar a la funcion y Kintentos
            }, 1500, 10);
        });

        */
    };
    //Show Images

    var sliderIndex = 0;

    $scope.sliderInit = function () {
        $scope.sliderShow = false;
        // Aqui se podria poner alguna alternativa de visualizacion
        // a la imagen
    };

    $scope.sliderRight = function () {
        if (sliderIndex === $scope.blogAnalyzer.imageUrls.length - 1) {
            sliderIndex = 0;
        } else {
            sliderIndex++;
        }
        $scope.sliderPosition = $scope.blogAnalyzer.imageUrls[sliderIndex];
    };
    $scope.sliderLeft = function () {
        if (sliderIndex === 0) {
            sliderIndex = $scope.blogAnalyzer.imageUrls.length - 1;
        } else {
            sliderIndex--;
        }
        $scope.sliderPosition = $scope.blogAnalyzer.imageUrls[sliderIndex];
    };

    //Mostrar formulario
    $scope.mostrarFormulario = false;

    // For tags List
    $scope.tempTagList = [];

    $scope.tagEvent = function (event) {
        if (event.charCode === 3) {
            $scope.addTag();
        }
    };

    // ERROR -- NO PUEDE SUBIR DOS IGUALES -- restriccion
    $scope.addTag = function () {
        if ($scope.tag !== null && $scope.tag !== "") {
            if ($scope.tempTagList.indexOf($scope.tag) === -1) {
                $scope.tempTagList.push($scope.tag);
                $scope.tag = null;
            } else {
                $scope.error = 'Tag repetido';
            }
        }
    };
    $scope.deleteTag = function () {
        $scope.tempTagList.splice(this.$index, 1);
    };
  

    $scope.create = function () {
        var article = new Articles({
            title: this.title,
            content: this.content,
            contentUrl: this.contentUrl,
            imageUrl: this.imageUrl,
            tags: this.tempTagList,
            categories: this.tempCategories,
            kViews: 0,
            kLikes: 0,
            kShared: 0,
            country: 'Spain',
            BlogId: sessionStorage.IdBlog
        });
        article.$save({Token: sessionStorage.token},function (response) {
            $location.path('/');
            $scope.title = '';
            $scope.contentUrl = '';
            // falta borrar los otros por seguridad
        }, function (errorResponse) {
            $scope.error = errorResponse.data.message;
        });
    };

    $scope.remove = function (article) {
        if (article) {
            article.$remove();
            for (var i in $scope.articles) {
                if ($scope.articles[i] === article) {
                    $scope.articles.splice(i, 1);
                }
            }
        } else {
            $scope.article.$remove(function () {
                $location.path('articles');
            });
        }
    };

}]);
