(function() {
    'use strict';

    angular
		.module("klinderrh.web.ui")
		.directive('appNavigator', function () {
        return {
            replace: true,
            restrict: 'A',
            templateUrl: function(iElement, iAttrs) {
                if (!iAttrs.appNavigator) {
                    throw new Error("app-navigator: template url must be provided");
                }

                return iAttrs.appNavigator;

            }

        };

    });

})();