import Interfaces = require("../../interfaces/Interfaces");
import Util = require("../../Util/Storage");

export class LoginController {
	'use strict';

	//private serviceUrl = "http://localhost:22149/api/";
	private serviceUrl = "http://localhost/KlinderRHSocial/api/";
	
	static $inject = ["$scope", "$http", "$rootScope", "$location"];

	constructor(
		$scope: Interfaces.IAboutScope,
		$http: ng.IHttpService,
		$rootScope: Interfaces.IApplicationRootScope,
		$location: ng.ILocationService) {

		$scope.authUser = user => {
			$rootScope.loggedUser = null;

			var data = "grant_type=password&username=" + user.nome + "&password=" + user.senha;
			var headers = { headers: { 'Content-Type': "application/x-www-form-urlencoded" } };

			$http
				.post(this.serviceUrl + "auth", data, headers)
				.success((response: any) => {
					Util.Storage.setObject("authorizationData",
					{
						token: response.access_token,
						userName: user.nome
					});

					$rootScope.loggedUser = Util.Storage.getObject("authorizationData");

					$location.path("/");

				})
				.error(errorResponse => {
					console.log(errorResponse);

				});

		}

	}

}