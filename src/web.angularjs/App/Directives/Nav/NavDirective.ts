export class NavDirective implements ng.IDirective {
    'use strict';

	static create() {
		return {
            replace: true,
            restrict: "A",
            templateUrl: (iElement, iAttrs) => {
	            if (!iAttrs.appNavigator) {
		            throw new Error("app-navigator: template url must be provided");
	            }

	            return iAttrs.appNavigator;

            }

        };

	}

}