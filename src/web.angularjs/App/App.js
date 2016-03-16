(function() {
	'use strict';

	angular
		.module("klinderrh.web.ui", ['ui.bootstrap', 'ngAnimate', "ui.router", "ngMessages"])
		.config(["$urlRouterProvider", "$stateProvider", "$httpProvider", appRouteConfig])
		.run(["$rootScope", "$state", "$http", appRun]);

	function appRouteConfig($urlRouterProvider, $stateProvider, $httpProvider) {
		$urlRouterProvider.otherwise("/");

		$stateProvider
			.state('home',
			{
				url: "/",
				templateUrl: 'app/modules/home/home.html',
				controller: 'HomeCtrl'
			})
			.state('login',
			{
				url: "/login",
				templateUrl: 'app/modules/auth/login.html',
				controller: 'LoginCtrl'
			})
			.state('about',
			{
				url: "/about",
				templateUrl: 'app/modules/about/about.html',
				controller: 'AboutCtrl'
			});

		//initialize get if not there
		if (!$httpProvider.defaults.headers.get) {
			$httpProvider.defaults.headers.get = {};
		}

		// disable IE ajax request caching
		$httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
		// extra
		$httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
		$httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

		$httpProvider.interceptors.push('authInterceptorService');

	}

	function appRun($rootScope, $state, $http) {
		$rootScope.loggedUser = storage.getObject('authorizationData');

		// register listener to watch route changes
		$rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
			if ($rootScope.loggedUser == null) {
				// no logged user, we should be going to #login
				if (toState.templateUrl.indexOf("login.html") > -1) {
					// already going to #login, no redirect needed
				} else {
					// not going to #login, we should redirect now
					event.preventDefault();

					$state.go("login");

				}

			}

		});

	}

})();