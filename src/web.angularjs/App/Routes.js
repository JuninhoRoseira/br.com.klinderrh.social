define(["require", "exports"], function (require, exports) {
    var Routes = (function () {
        function Routes() {
        }
        Routes.configureRoutes = function ($urlRouterProvider, $stateProvider, $httpProvider) {
            $urlRouterProvider.otherwise("/");
            $stateProvider
                .state("home", {
                url: "/",
                templateUrl: "app/modules/home/home.html",
                controller: "KlinderRH.Web.UI.Controllers.HomeController"
            })
                .state("login", {
                url: "/login",
                templateUrl: "app/modules/login/login.html",
                controller: "KlinderRH.Web.UI.Controllers.LoginController"
            })
                .state("cargos", {
                url: "/cargos",
                templateUrl: "app/modules/cadastros/cargos/cargolista.html",
                controller: "KlinderRH.Web.UI.Controllers.CargoController",
                controllerAs: "cargoCtrl"
            })
                .state("departamentos", {
                url: "/departamentos",
                templateUrl: "app/modules/cadastros/departamentos/departamentolista.html",
                controller: "KlinderRH.Web.UI.Controllers.DepartamentoController",
                controllerAs: "departamentoCtrl"
            })
                .state("about", {
                url: "/about",
                templateUrl: "app/modules/about/about.html",
                controller: "KlinderRH.Web.UI.Controllers.AboutController"
            });
            // initialize get if not there
            if (!$httpProvider.defaults.headers.get) {
                $httpProvider.defaults.headers.get = {};
            }
            // disable IE ajax request caching
            $httpProvider.defaults.headers.get["If-Modified-Since"] = "Mon, 26 Jul 1997 05:00:00 GMT";
            // extra
            $httpProvider.defaults.headers.get["Cache-Control"] = "no-cache";
            $httpProvider.defaults.headers.get["Pragma"] = "no-cache";
            $httpProvider.interceptors.push("KlinderRH.Web.UI.Services.AuthInterceptorService");
        };
        Routes.$inject = ["$urlRouterProvider", "$stateProvider", "$httpProvider"];
        return Routes;
    })();
    exports.Routes = Routes;
});
//# sourceMappingURL=Routes.js.map