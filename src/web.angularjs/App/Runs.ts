import Interfaces = require("Interfaces/Interfaces");
import Util = require("Util/Storage");

export class Runs {
	"use strict";

	static $inject = ["$rootScope", "$state", "$http"];

	static execute(
		$rootScope: Interfaces.IApplicationRootScope,
		$state: ng.ui.IStateService,
		$http: ng.IHttpProvider) {

		$rootScope.loggedUser = Util.Storage.getObject('authorizationData');

		// register listener to watch route changes
		$rootScope.$on('$stateChangeStart', (event, toState, toParams, fromState, fromParams) => {
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

}