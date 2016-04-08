define(["require", "exports"], function (require, exports) {
    var PopupDirective = (function () {
        function PopupDirective() {
        }
        PopupDirective.create = function () {
            return {
                restrict: "EA",
                templateUrl: "/App/Directives/Popup/Alert.html"
            };
        };
        return PopupDirective;
    })();
    exports.PopupDirective = PopupDirective;
});
//# sourceMappingURL=PopupDirective.js.map