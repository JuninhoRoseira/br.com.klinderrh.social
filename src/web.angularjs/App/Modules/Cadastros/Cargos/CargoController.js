define(["require", "exports"], function (require, exports) {
    var CargoController = (function () {
        function CargoController($http, $uibModal) {
            this.serviceUrl = "http://localhost:22149/api/cargos/";
            this.http = $http;
            this.uibModal = $uibModal;
            this.listarTodos();
        }
        CargoController.prototype.listarTodos = function () {
            var _this = this;
            this.http
                .get(this.serviceUrl)
                .success(function (response) {
                _this.listaDeCargos = response;
            });
        };
        CargoController.prototype.adicionar = function () { };
        CargoController.prototype.habilitarEdicao = function (cargo) {
            var _this = this;
            var modalInstance = this.uibModal.open({
                templateUrl: "/App/Modules/Cadastros/Cargos/CargoForm.html",
                controllerAs: "cargoPopupCtrl",
                controller: PopupCargoController,
                resolve: {
                    title: function () { return "Editar Cargo"; },
                    cargo: function () { return ({
                        codigo: cargo.codigo,
                        nome: cargo.nome,
                        sigla: cargo.sigla,
                        descricao: cargo.descricao
                    }); }
                }
            });
            modalInstance.result.then(function (cargo) {
                _this.http
                    .put(_this.serviceUrl, cargo)
                    .success(function () {
                    _this.listarTodos();
                })
                    .error(function (a, b, c) {
                    var d = a;
                });
            });
        };
        CargoController.$inject = ["$http", "$uibModal"];
        return CargoController;
    })();
    exports.CargoController = CargoController;
    var PopupCargoController = (function () {
        function PopupCargoController($uibModalInstance, title, cargo) {
            this.$uibModalInstance = $uibModalInstance;
            this.title = title;
            this.cargo = cargo;
        }
        PopupCargoController.prototype.cancel = function () {
            this.$uibModalInstance.dismiss("cancel");
        };
        PopupCargoController.prototype.ok = function () {
            this.$uibModalInstance.close(this.cargo);
        };
        PopupCargoController.$inject = ["$uibModalInstance", "title", "cargo"];
        return PopupCargoController;
    })();
    exports.PopupCargoController = PopupCargoController;
});
//# sourceMappingURL=CargoController.js.map