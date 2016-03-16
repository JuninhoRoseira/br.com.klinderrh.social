(function() {
	'use strict';

	angular
		.module("klinderrh.web.ui")
		.factory('authInterceptorService', ['$q', '$location', authInterceptorServiceFactory]);

	function authInterceptorServiceFactory($q, $location) {
		var serviceFactory = {
			request: request,
			responseError: responseError
		};

		return serviceFactory;

		function request(config) {
			config.headers = config.headers || {};

			var authData = storage.getObject('authorizationData');

			if (authData) {
				config.headers.Authorization = 'Bearer ' + authData.token;
			}

			return config;

		}

		function responseError(rejection) {
			if (rejection.status === 401) {
				$location.path('/login');
			}
			return $q.reject(rejection);
		}

	}

})();