define(["require", "exports", "Util/Storage"], function (require, exports, Util) {
    var Runs = (function () {
        function Runs() {
        }
        Runs.execute = function ($rootScope, $state, $http) {
            $rootScope.loggedUser = Util.Storage.getObject('authorizationData');
            $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
                if ($rootScope.loggedUser == null) {
                    if (toState.templateUrl.indexOf("login.html") > -1) {
                    }
                    else {
                        event.preventDefault();
                        $state.go("login");
                    }
                }
            });
        };
        Runs.$inject = ["$rootScope", "$state", "$http"];
        return Runs;
    })();
    exports.Runs = Runs;
});
//# sourceMappingURL=Runs.js.map