import Interfaces = require("../interfaces/Interfaces");
import Util = require("../Util/Storage");

export class AuthInterceptorService {
	"use strict";

	q: ng.IQService;
	location: ng.ILocationService;

	static $inject = ["$q", "$location"];

	static create($q: ng.IQService, $location: ng.ILocationService) {
		return {
			request: config => {
				config.headers = config.headers || {};

				var authData = Util.Storage.getObject("authorizationData");

				if (authData) {
					config.headers.Authorization = `Bearer ${authData.token}`;
				}

				return config;

			},
			responseError: rejection => {
				if (rejection.status === 401) {
					$location.path("/login");
				}

				return $q.reject(rejection);

			}
		}
	}

}