var app = angular.module("klinderrh.web.ui", ['ui.bootstrap', 'ngAnimate', "ui.router", "ngMessages"]);

function appRun($rootScope, $state, $http) {
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

        } else {
            $http.defaults.headers.common['Authorization'] = 'bearer ' + $rootScope.loggedUser.access_token;
            //$http.defaults.headers.common['Accept'] = 'application/json;odata=verbose';

        }

    });

}

function appRouteConfig($urlRouterProvider, $stateProvider) {
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

}

app
    .config(["$urlRouterProvider", "$stateProvider", appRouteConfig])
    .run(["$rootScope", "$state", "$http", appRun]);
