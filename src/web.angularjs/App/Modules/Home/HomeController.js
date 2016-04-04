define(["require", "exports"], function (require, exports) {
    var HomeController = (function () {
        function HomeController($scope, $http) {
            this.serviceUrl = "http://localhost:22149/api/";
            $scope.rows = [];
            $scope.habilitaEdicao = function (row) {
                $scope.rows.forEach(function (el, i) {
                    el.editing = false;
                });
                row.editing = true;
            };
            $scope.salvaEdicao = function ($event, row) {
                $event.stopPropagation();
                row.editing = false;
            };
            $scope.cancelaEdicao = function ($event, row) {
                $event.stopPropagation();
                row.editing = false;
            };
            $http.
                get(this.serviceUrl + 'ObterEntradasPorMes?ano=2015&mes=1').
                success(function (response) {
                $scope.rows = (response);
            }).
                error(function (error) {
                console.log(error);
            });
        }
        HomeController.$inject = ["$scope", '$http'];
        return HomeController;
    })();
    exports.HomeController = HomeController;
});
//# sourceMappingURL=HomeController.js.map