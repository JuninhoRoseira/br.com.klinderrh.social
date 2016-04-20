define(["require", "exports", "../../Util/Storage"], function (require, exports, Util) {
    "use strict";
    var LoginController = (function () {
        function LoginController($scope, $http, $rootScope, $location) {
            var _this = this;
            this.serviceUrl = "http://localhost:22149/api/";
            $scope.authUser = function (user) {
                $rootScope.loggedUser = null;
                var data = "grant_type=password&username=" + user.nome + "&password=" + user.senha;
                var headers = { headers: { 'Content-Type': "application/x-www-form-urlencoded" } };
                $http
                    .post(_this.serviceUrl + "auth", data, headers)
                    .success(function (response) {
                    Util.Storage.setObject("authorizationData", {
                        token: response.access_token,
                        userName: user.nome
                    });
                    $rootScope.loggedUser = Util.Storage.getObject("authorizationData");
                    $location.path("/");
                })
                    .error(function (errorResponse) {
                    console.log(errorResponse);
                });
            };
        }
        //private serviceUrl = "http://localhost/KlinderRHSocial/api/";
        LoginController.$inject = ["$scope", "$http", "$rootScope", "$location"];
        return LoginController;
    }());
    exports.LoginController = LoginController;
});
//# sourceMappingURL=LoginController.js.map