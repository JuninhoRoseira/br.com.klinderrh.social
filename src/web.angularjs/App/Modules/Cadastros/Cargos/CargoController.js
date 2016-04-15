define(["require", "exports", "../../../enums/Enums"], function (require, exports, Enums) {
    var CargoController = (function () {
        function CargoController($http, $uibModal) {
            this.serviceUrl = "http://localhost:22149/api/cargos/";
            this.http = $http;
            this.uibModal = $uibModal;
            this.listarTodos();
            this.obterNiveisDosCargos();
        }
        CargoController.prototype.listarTodos = function () {
            var _this = this;
            this.http
                .get(this.serviceUrl)
                .success(function (response) {
                _this.listaDeCargos = response;
            });
        };
        CargoController.prototype.pesquisar = function (pesquisa) {
            var _this = this;
            this.http
                .get(this.serviceUrl + "/" + pesquisa.texto)
                .success(function (response) {
                _this.listaDeCargos = response;
            }).error(function (a, b, c, d) {
                alert(a);
            });
        };
        CargoController.prototype.obterNiveisDosCargos = function () {
            var _this = this;
            this.http
                .get(this.serviceUrl + "obterniveis")
                .success(function (response) {
                _this.listaDeNiveisDosCargos = response;
            });
        };
        CargoController.prototype.obterNomeDoNivel = function (nivelId) {
            return Enums.NivelDoCargo[nivelId];
        };
        CargoController.prototype.adicionar = function () {
            var _this = this;
            var modalInstance = this.uibModal.open({
                templateUrl: "/App/Modules/Cadastros/Cargos/CargoForm.html",
                controllerAs: "cargoPopupCtrl",
                controller: PopupCargoController,
                resolve: {
                    title: function () { return "Novo Cargo"; },
                    cargo: function () { return ({
                        id: "",
                        nome: "",
                        sigla: "",
                        descricao: "",
                        nivel: ""
                    }); },
                    niveis: function () { return _this.listaDeNiveisDosCargos; }
                }
            });
            modalInstance.result.then(function (cargo) {
                _this.http
                    .post(_this.serviceUrl, cargo)
                    .success(function () {
                    _this.listarTodos();
                })
                    .error(function (a, b, c) {
                    var d = a;
                });
            });
        };
        CargoController.prototype.habilitarEdicao = function (cargo) {
            var _this = this;
            var modalInstance = this.uibModal.open({
                templateUrl: "/App/Modules/Cadastros/Cargos/CargoForm.html",
                controllerAs: "cargoPopupCtrl",
                controller: PopupCargoController,
                resolve: {
                    title: function () { return "Editar Cargo"; },
                    cargo: function () { return ({
                        id: cargo.id,
                        nome: cargo.nome,
                        sigla: cargo.sigla,
                        descricao: cargo.descricao,
                        nivel: cargo.nivel
                    }); },
                    niveis: function () { return _this.listaDeNiveisDosCargos; }
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
        CargoController.prototype.excluir = function ($event, cargoId) {
            var _this = this;
            $event.stopPropagation();
            var modalTemplate = "<div class='modal-header'><h3 class='modal-title'>Exclusão</h3></div>" +
                "<div class='modal-body'>Deseja excluir este cargo ?</div>" +
                "<div class='modal-footer'>" +
                "<button class='btn btn-warning' type='button' ng-click='cargoPopupCtrl.cancel()'>Cancelar</button>" +
                "<button class='btn btn-success' type='button' ng-click='cargoPopupCtrl.ok()'>Excluir</button></div>";
            var modalInstance = this.uibModal.open({
                template: modalTemplate,
                controllerAs: "cargoPopupCtrl",
                controller: PopupDeleteCargoController
            });
            modalInstance.result.then(function () {
                _this.http
                    .delete(_this.serviceUrl + "/" + cargoId)
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
        function PopupCargoController($uibModalInstance, title, cargo, niveis) {
            this.$uibModalInstance = $uibModalInstance;
            this.title = title;
            this.cargo = cargo;
            this.niveis = niveis;
        }
        PopupCargoController.prototype.cancel = function () {
            this.$uibModalInstance.dismiss("cancel");
        };
        PopupCargoController.prototype.ok = function () {
            this.$uibModalInstance.close(this.cargo);
        };
        PopupCargoController.$inject = ["$uibModalInstance", "title", "cargo", "niveis"];
        return PopupCargoController;
    })();
    exports.PopupCargoController = PopupCargoController;
    var PopupDeleteCargoController = (function () {
        function PopupDeleteCargoController($uibModalInstance) {
            this.$uibModalInstance = $uibModalInstance;
        }
        PopupDeleteCargoController.prototype.cancel = function () {
            this.$uibModalInstance.dismiss("cancel");
        };
        PopupDeleteCargoController.prototype.ok = function () {
            this.$uibModalInstance.close();
        };
        PopupDeleteCargoController.$inject = ["$uibModalInstance"];
        return PopupDeleteCargoController;
    })();
    exports.PopupDeleteCargoController = PopupDeleteCargoController;
});
//# sourceMappingURL=CargoController.js.map