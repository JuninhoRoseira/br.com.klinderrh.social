define(["require", "exports"], function (require, exports) {
    var SideBarDirective = (function () {
        function SideBarDirective() {
        }
        SideBarDirective.create = function () {
            return {
                replace: true,
                restrict: "A",
                templateUrl: function (iElement, iAttrs) {
                    if (!iAttrs.appSidebar) {
                        throw new Error("app-sidebar: template url must be provided");
                    }
                    return iAttrs.appSidebar;
                }
            };
        };
        return SideBarDirective;
    })();
    exports.SideBarDirective = SideBarDirective;
});
//# sourceMappingURL=SideBarDirective.js.map