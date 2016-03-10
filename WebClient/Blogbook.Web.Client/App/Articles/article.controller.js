

app.controller('ArticlesController',
	['$scope','Articles','Categories','BlogAnalyzer','$stateParams','$location',
function ($scope, Articles, Categories, BlogAnalyzer,$stateParams,$location) {

        $scope.authentication = true;


        $scope.create = function() {
            var article = new Articles({
                title: this.title,
                content: this.content,
                contentUrl: this.contentUrl,
                imageUrl: this.imageUrl,
                tags: this.tempTagList,
                categories:this.tempCategories,
                kViews: 0,
                kLikes: 0,
                kShared: 0,
                country: 'Spain',
                userLogin:"aldunate"
                
            });
            article.$save(function(response) {
                $location.path('/');
                $scope.title = '';
                $scope.contentUrl = '';
                // falta borrar los otros por seguridad
            }, function(errorResponse) {
                $scope.error = errorResponse.data.message;
            });
        };

        $scope.remove = function(article) {
            if (article) {
                article.$remove();
                for (var i in $scope.articles) {
                    if ($scope.articles[i] === article) {
                        $scope.articles.splice(i, 1);
                    }
                }
            } else {
                $scope.article.$remove(function() {
                    $location.path('articles');
                });
            }
        };

        $scope.update = function() {
            var article = $scope.article;

            article.$update(function() {
                // Creo que no hace falta -->$location.path('articles/' + article._id);
            }, function(errorResponse) {
                $scope.error = errorResponse.data.message;
            });
        };

        $scope.find = function () {
            $scope.articles = Articles.query();
            $scope.articles.$promise.then(function (result) {
                $scope.articles = result;
            });
        };

        $scope.findFollow = function () {
            //Original
            //$scope.articles = Articles.query();
 
        };

        $scope.findOne = function() {
            $scope.article = Articles.get({
                articleId: $stateParams.articleId
            });
        };

        //Enviar URL, a blogAnalyzer
        $scope.sendURL = function(){
            var timerId;
            var analyzer = new BlogAnalyzer({
                blogUrl: this.contentUrl
            });
            $scope.mostrarFormulario = false;
            analyzer.$save()
            .then(function(response){
                timerId = $interval(function(){
                    BlogAnalyzer.get({
                        blog_analyzerId: response.id
                    }).$promise.then(function(data){
                        if( data.state === 'Error'){
                            $interval.cancel(timerId);
                            $scope.blogAnalyzer = 'error';
                            $scope.sliderPosition = null;
                        }
                        if(data.state === 'Ok'){
                            $interval.cancel(timerId);
                            $scope.blogAnalyzer = data;
                            $scope.sliderPosition = data.imageUrls[0];
                            $scope.sliderShow = true;
                        }
                    });

                    // Tiempo de espera antes de llamar a la funcion y Kintentos
                }, 1500, 10);
            });
        };
        //Show Images

        var sliderIndex = 0;

        $scope.sliderInit = function(){
            $scope.sliderShow = false;
            // Aqui se podria poner alguna alternativa de visualizacion
            // a la imagen
        };

        $scope.sliderRight = function (){
            if ( sliderIndex === $scope.blogAnalyzer.imageUrls.length - 1){
                sliderIndex = 0;
            }else{
                sliderIndex++;
            }
            $scope.sliderPosition = $scope.blogAnalyzer.imageUrls[sliderIndex];
        };
        $scope.sliderLeft = function (){
            if ( sliderIndex === 0){
                sliderIndex = $scope.blogAnalyzer.imageUrls.length - 1;
            }else{
                sliderIndex--;
            }
            $scope.sliderPosition = $scope.blogAnalyzer.imageUrls[sliderIndex];
        };

        //Mostrar formulario
        $scope.mostrarFormulario = false;

        // For tags List
        $scope.tempTagList = [];

        $scope.tagEvent = function (event){
            if(event.charCode === 3 ){
                $scope.addTag();
            }
        };

        // ERROR -- NO PUEDE SUBIR DOS IGUALES -- restriccion
        $scope.addTag = function(){

            if($scope.tag !== null) {
                if ($scope.tempTagList.indexOf($scope.tag) === -1) {
                    $scope.tempTagList.push($scope.tag);
                    $scope.tag = null;
                } else {
                    $scope.error = 'Tag repetido';
                }
            }
        };
        $scope.deleteTag = function(){
            $scope.tempTagList.splice(this.$index,1);
        };
        // For Categories
        $scope.tempCategories = [];

        $scope.pullCategories = function () {

            $scope.categories = [
                {
                    id:"Deportes",
                    name: "Deportes",
                    state:false
                },
                {
                    id: "Politica",
                    name: "Politica",
                    state: false
                },
                {
                    id: "Ciencia",
                    name: "Ciencia",
                    state: false
                },
                {
                    id: "Moda",
                    name: "Moda",
                    state: false
                },
                {
                    id: "Cine",
                    name: "Cine",
                    state: false
                },
                {
                    id: "Tecnología",
                    name: "Tecnología",
                    state: false
                }
            ];

            /*
            $scope.categories = [];
            Categories.get().$promise.then(function(data){
                for (var i = 0; i < data.length; i++) {
                    var newCat = {
                        id: data[i].id,
                        name: data[i].spa,
                        state: false
                    };
                    $scope.categories.push(newCat);
                }
            });*/
        };
        $scope.selectCategory = function(){
            if( this.category.state === true ) {
                var element = $scope.tempCategories.indexOf(this.category.id);
                $scope.tempCategories.splice(element,1);

            }
            if( this.category.state === false){
                $scope.tempCategories.push(this.category.id);
            }
        };

        $scope.lorem = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In rutrum congue arcu quis egestas. Duis sed lectus quis velit viverra semper sed id urna. Duis maximus feugiat tortor, interdum accumsan turpis mattis id. In quis lacus varius, cursus tortor quis, fermentum orci. Nunc dolor ex, aliquet ut venenatis vel, hendrerit non sapien. In tincidunt hendrerit turpis nec consequat. Sed non metus neque. Ut nec egestas ipsum. Aenean non blandit nisl, at dignissim lectus. Aenean et volutpat urna. Maecenas vitae tempus nulla. Aenean aliquam nunc at elit finibus, eget fermentum justo mollis. Sed congue leo lorem, eu sollicitudin risus posuere quis. Maecenas fermentum purus a bibendum vulputate. Mauris sed justo eu ex semper venenatis. In non efficitur sapien.Pellentesque tempus imperdiet neque in volutpat. Etiam lobortis feugiat odio, id lobortis tellus tincidunt sed. Aenean et enim quis quam eleifend maximus vel sed nisi. Sed pretium ornare nunc et elementum. Proin tristique nulla vitae sapien egestas, a pharetra purus elementum. Morbi fringilla lorem sit amet convallis tempus. Curabitur tempus arcu vitae pellentesque commodo. Praesent fermentum vel elit tempor molestie. Vivamus eget aliquam lectus. Sed nec pharetra ligula. Donec tempor in massa accumsan ullamcorper. Pellentesque tempus in risus nec scelerisque. Proin in vestibulum nulla. Maecenas a libero turpis.	Cras condimentum nisl fermentum, elementum est non, suscipit augue. Nulla placerat ante facilisis tellus elementum, sed interdum purus sollicitudin. Mauris finibus neque massa, fermentum imperdiet leo posuere vel. Integer sed nunc dapibus, condimentum neque et, tempus nulla. Nulla scelerisque pretium elit ac auctor. Vivamus sed libero leo. Nunc rutrum blandit quam, sit amet vulputate ante consequat et. Duis in egestas elit, vitae aliquet magna.	Morbi dignissim non nibh eu rutrum. Aliquam porta pharetra risus, quis luctus elit mattis a. Integer volutpat porta mauris, sed eleifend erat. Donec nibh magna, convallis non dolor a, facilisis tristique sem. Aliquam in consequat elit, ut congue urna. Maecenas ut eros at nulla dictum venenatis et quis tellus. Praesent tempus augue felis, ac gravida dui volutpat ut. Phasellus fringilla lorem in ligula dignissim, id sollicitudin ante interdum. Suspendisse egestas libero eu tempus consectetur. Sed vel lectus vitae sem blandit venenatis efficitur at est. Nulla pellentesque leo vel metus iaculis rhoncus. Proin efficitur urna rhoncus, pharetra ligula ut, fermentum libero. Vestibulum nec nulla sollicitudin, vestibulum ex ut, congue lorem. In finibus risus sit amet blandit luctus.';

        // Controlador de vista list GROUP

        $scope.goPost = function(){
            this.article.kViews++;

            this.article.$update(function() {

            }, function(errorResponse) {
                $scope.error = errorResponse.data.message;
            });
        };

    }

]);
