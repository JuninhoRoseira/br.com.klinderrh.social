define(["require", "exports", "Util/Storage"], function (require, exports, Util) {
    var Runs = (function () {
        function Runs() {
        }
        Runs.execute = function ($rootScope, $state, $http) {
            $rootScope.loggedUser = Util.Storage.getObject('authorizationData');
            // register listener to watch route changes
            $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
                if ($rootScope.loggedUser == null) {
                    // no logged user, we should be going to #login
                    if (toState.templateUrl.indexOf("login.html") > -1) {
                    }
                    else {
                        // not going to #login, we should redirect now
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