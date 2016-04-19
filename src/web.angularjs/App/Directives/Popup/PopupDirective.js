define(["require", "exports"], function (require, exports) {
    "use strict";
    var PopupDirective = (function () {
        function PopupDirective() {
        }
        PopupDirective.create = function () {
            return {
                //replace: true,
                restrict: "EA",
                templateUrl: "/App/Directives/Popup/Alert.html"
            };
        };
        return PopupDirective;
    }());
    exports.PopupDirective = PopupDirective;
});
//# sourceMappingURL=PopupDirective.js.map