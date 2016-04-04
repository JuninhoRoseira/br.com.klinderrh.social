/// <reference path="../scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts"/>

requirejs.config({
	baseUrl: "app",
	paths: {
		"jquery": "../scripts/jquery-2.2.2.min",
		"bootstrap": "../scripts/bootstrap",
		"prototype": "../scripts/prototype",
		"storage": "../scripts/storage",
		"app": "./Modules",
		"angular": "../scripts/angular",
		"ngRoute": "../scripts/angular-ui-router.min",
		"ngMessages": "../scripts/angular-messages.min",
		"ngAnimate": "../scripts/angular-animate.min",
		"ui.bootstrap": "../scripts/angular-ui/ui-bootstrap-tpls"
	},
	shim: {
		"ngRoute": ["angular"],
		"ngMessages": ["angular"],
		"ngAnimate": ["angular"],
		"ui.bootstrap": ["angular"],
		"bootstrap": ["jquery"]
	}
});

requirejs(
["app", "bootstrap", "angular", "prototype", "storage", "ngRoute", "ngMessages", "ngAnimate", "ui.bootstrap"],
(app) => {
	var klinderRh = new app.KlinderRh();

	angular.element(document).ready(() => {
		angular.bootstrap(document, ["KlinderRH.Web.UI"]);
	});

});