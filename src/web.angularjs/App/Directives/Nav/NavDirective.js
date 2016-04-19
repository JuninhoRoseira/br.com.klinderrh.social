define(["require", "exports"], function (require, exports) {
    "use strict";
    var NavDirective = (function () {
        function NavDirective() {
        }
        NavDirective.create = function () {
            return {
                replace: true,
                restrict: "A",
                templateUrl: function (iElement, iAttrs) {
                    if (!iAttrs.appNavigator) {
                        throw new Error("app-navigator: template url must be provided");
                    }
                    return iAttrs.appNavigator;
                }
            };
        };
        return NavDirective;
    }());
    exports.NavDirective = NavDirective;
});
//# sourceMappingURL=NavDirective.js.map