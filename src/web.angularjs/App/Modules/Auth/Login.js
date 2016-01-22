(function() {
    'use strict';

    var serviceUrl = "http://localhost:22149/api/";

    app.controller('LoginCtrl', ['$scope', '$http', '$rootScope', '$location', LoginCtrl]);

    function LoginCtrl($scope, $http, $rootScope, $location) {
        $rootScope.loggedUser = null;

        $scope.authUser = function(user) {
            var data = "grant_type=password&username=" + user.nome + "&password=" + user.senha;
            //var deferred = $q.defer();
            var headers = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

            $http.
                post(serviceUrl + 'auth', data, headers).
                success(function(response) {
                    $rootScope.loggedUser = response;

                    $location.path("/");

                }).
                error(function(error) {
                    console.log(error);
                });

        }


    }

})();