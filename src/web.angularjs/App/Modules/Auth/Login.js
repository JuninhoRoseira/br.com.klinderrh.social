(function() {
	'use strict';

	var serviceUrl = "http://localhost:22149/api/";

	angular
		.module("klinderrh.web.ui")
		.controller('LoginCtrl', ['$scope', '$http', '$rootScope', '$location', LoginCtrl]);

	function LoginCtrl($scope, $http, $rootScope, $location) {
		$scope.authUser = function(user) {
			$rootScope.loggedUser = null;

			var data = "grant_type=password&username=" + user.nome + "&password=" + user.senha;
			var headers = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

			$http
				.post(serviceUrl + 'auth', data, headers)
				.success(function(response) {
					storage.setObject('authorizationData',
					{
						token: response.access_token,
						userName: user.nome
					});

					$rootScope.loggedUser = storage.getObject('authorizationData');

					$location.path("/");

				})
				.error(function(error) {
					console.log(error);

				});

		}


	}

})();