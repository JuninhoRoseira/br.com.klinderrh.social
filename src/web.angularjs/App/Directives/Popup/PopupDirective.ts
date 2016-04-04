export class PopupDirective implements ng.IDirective {
    'use strict';

	static create() {
		return {
            //replace: true,
            restrict: "EA",
            templateUrl: "/App/Directives/Popup/Alert.html"
        };

	}

}