define(["require", "exports", "Routes", "Runs", "Services/AuthInterceptorService", "Directives/Nav/NavDirective", "Directives/SideBar/SideBarDirective", "Directives/Popup/PopupDirective", "Modules/About/AboutController", "Modules/Login/LoginController", "Modules/Home/HomeController", "Modules/Cadastros/Cargos/CargoController"], function (require, exports, AppConfig, AppRuns, Services, NavDir, SideBarDir, PopupDir, AboutCtrl, LoginCtrl, HomeCtrl, CargoCtrl) {
    var KlinderRh = (function () {
        function KlinderRh() {
            var app = angular.module("KlinderRH.Web.UI", ["ui.bootstrap", "ngAnimate", "ui.router", "ngMessages"]);
            app.config(AppConfig.Routes.configureRoutes);
            app.run(AppRuns.Runs.execute);
            app.directive("appNavigator", NavDir.NavDirective.create);
            app.directive("appSidebar", SideBarDir.SideBarDirective.create);
            app.directive("appPopup", PopupDir.PopupDirective.create);
            app.factory("KlinderRH.Web.UI.Services.AuthInterceptorService", Services.AuthInterceptorService.create);
            app.controller("KlinderRH.Web.UI.Controllers.AboutController", AboutCtrl.AboutController);
            app.controller("KlinderRH.Web.UI.Controllers.LoginController", LoginCtrl.LoginController);
            app.controller("KlinderRH.Web.UI.Controllers.HomeController", HomeCtrl.HomeController);
            app.controller("KlinderRH.Web.UI.Controllers.CargoController", CargoCtrl.CargoController);
        }
        return KlinderRh;
    })();
    exports.KlinderRh = KlinderRh;
});
//# sourceMappingURL=Modules.js.map