define(["require", "exports", "../Util/Storage"], function (require, exports, Util) {
    var AuthInterceptorService = (function () {
        function AuthInterceptorService() {
        }
        AuthInterceptorService.create = function ($q, $location) {
            return {
                request: function (config) {
                    config.headers = config.headers || {};
                    var authData = Util.Storage.getObject("authorizationData");
                    if (authData) {
                        config.headers.Authorization = "Bearer " + authData.token;
                    }
                    return config;
                },
                responseError: function (rejection) {
                    if (rejection.status === 401) {
                        $location.path("/login");
                    }
                    return $q.reject(rejection);
                }
            };
        };
        AuthInterceptorService.$inject = ["$q", "$location"];
        return AuthInterceptorService;
    })();
    exports.AuthInterceptorService = AuthInterceptorService;
});
//# sourceMappingURL=AuthInterceptorService.js.map