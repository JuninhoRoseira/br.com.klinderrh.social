import AppConfig = require("Routes");
import AppRuns = require("Runs");
import Services = require("Services/AuthInterceptorService");
import NavDir = require("Directives/Nav/NavDirective");
import SideBarDir = require("Directives/SideBar/SideBarDirective");
//import PopupDir = require("Directives/Popup/PopupDirective");
import AboutCtrl = require("Modules/About/AboutController");
import LoginCtrl = require("Modules/Login/LoginController");
import HomeCtrl = require("Modules/Home/HomeController");
import CargoCtrl = require("Modules/Cadastros/Cargos/CargoController");
import DepartamentoCtrl = require("Modules/Cadastros/Departamentos/DepartamentoController");

export class KlinderRh {
	"use strict";

	constructor() {
		var app = angular.module("KlinderRH.Web.UI", ["ui.bootstrap", "ngAnimate", "ui.router", "ngMessages"]);

		app.config(AppConfig.Routes.configureRoutes);
		app.run(AppRuns.Runs.execute);

		app.directive("appNavigator", NavDir.NavDirective.create);
		app.directive("appSidebar", SideBarDir.SideBarDirective.create);
		//app.directive("appPopup", PopupDir.PopupDirective.create);

		app.factory("KlinderRH.Web.UI.Services.AuthInterceptorService", Services.AuthInterceptorService.create);
		
		app.controller("KlinderRH.Web.UI.Controllers.AboutController", AboutCtrl.AboutController);
		app.controller("KlinderRH.Web.UI.Controllers.LoginController", LoginCtrl.LoginController);
		app.controller("KlinderRH.Web.UI.Controllers.HomeController", HomeCtrl.HomeController);
		app.controller("KlinderRH.Web.UI.Controllers.CargoController", CargoCtrl.CargoController);
		app.controller("KlinderRH.Web.UI.Controllers.DepartamentoController", DepartamentoCtrl.DepartamentoController);
		
	}

}