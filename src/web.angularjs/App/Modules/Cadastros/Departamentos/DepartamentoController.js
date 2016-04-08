define(["require", "exports"], function (require, exports) {
    var DepartamentoController = (function () {
        function DepartamentoController($http, $uibModal) {
            this.serviceUrl = "http://localhost:22149/api/departamentos/";
            this.http = $http;
            this.uibModal = $uibModal;
            this.listarTodos();
        }
        DepartamentoController.prototype.listarTodos = function () {
            var _this = this;
            this.http
                .get(this.serviceUrl)
                .success(function (response) {
                _this.listaDosDepartamentos = response;
            });
        };
        DepartamentoController.prototype.pesquisar = function (pesquisa) {
            var _this = this;
            this.http
                .get(this.serviceUrl + "/" + pesquisa.texto)
                .success(function (response) {
                _this.listaDosDepartamentos = response;
            });
        };
        DepartamentoController.prototype.adicionar = function () {
            var _this = this;
            var modalInstance = this.uibModal.open({
                templateUrl: "/App/Modules/Cadastros/Departamentos/DepartamentoForm.html",
                controllerAs: "departamentoPopupCtrl",
                controller: PopupDepartamentoController,
                resolve: {
                    title: function () { return "Novo Departamento"; },
                    departamento: function () { return ({
                        codigo: 0,
                        nome: "",
                        sigla: "",
                        descricao: "",
                        codigoDoDepartamentoPai: 0,
                        departamentosFilho: []
                    }); },
                    pais: function () { return _this.listaDosDepartamentos; }
                }
            });
            modalInstance.result.then(function (departamento) {
                _this.http
                    .post(_this.serviceUrl, departamento)
                    .success(function () {
                    _this.listarTodos();
                })
                    .error(function (a, b, c) {
                    var d = a;
                });
            });
        };
        DepartamentoController.prototype.habilitarEdicao = function (departamento) {
            var _this = this;
            var modalInstance = this.uibModal.open({
                templateUrl: "/App/Modules/Cadastros/Departamentos/DepartamentoForm.html",
                controllerAs: "departamentoPopupCtrl",
                controller: PopupDepartamentoController,
                resolve: {
                    title: function () { return "Editar Departamento"; },
                    departamento: function () { return ({
                        codigo: departamento.codigo,
                        nome: departamento.nome,
                        sigla: departamento.sigla,
                        descricao: departamento.descricao,
                        codigoDoDepartamentoPai: departamento.codigoDoDepartamentoPai,
                        departamentosFilho: departamento.departamentosFilho
                    }); },
                    pais: function () { return _this.listaDosDepartamentos; }
                }
            });
            modalInstance.result.then(function (departamento) {
                _this.http
                    .put(_this.serviceUrl, departamento)
                    .success(function () {
                    _this.listarTodos();
                })
                    .error(function (a, b, c) {
                    var d = a;
                });
            });
        };
        DepartamentoController.prototype.excluir = function ($event, codigoDoDepartamento) {
            var _this = this;
            $event.stopPropagation();
            var modalTemplate = "<div class='modal-header'><h3 class='modal-title'>Exclusão</h3></div>" +
                "<div class='modal-body'>Deseja excluir este departamento ?</div>" +
                "<div class='modal-footer'>" +
                "<button class='btn btn-warning' type='button' ng-click='departamentoPopupCtrl.cancel()'>Cancelar</button>" +
                "<button class='btn btn-success' type='button' ng-click='departamentoPopupCtrl.ok()'>Excluir</button></div>";
            var modalInstance = this.uibModal.open({
                template: modalTemplate,
                controllerAs: "departamentoPopupCtrl",
                controller: PopupDeleteDepartamentoController
            });
            modalInstance.result.then(function () {
                _this.http
                    .delete(_this.serviceUrl + "/" + codigoDoDepartamento)
                    .success(function () {
                    _this.listarTodos();
                })
                    .error(function (a, b, c) {
                    var d = a;
                });
            });
        };
        DepartamentoController.$inject = ["$http", "$uibModal"];
        return DepartamentoController;
    })();
    exports.DepartamentoController = DepartamentoController;
    var PopupDepartamentoController = (function () {
        function PopupDepartamentoController($uibModalInstance, title, departamento, pais) {
            var _this = this;
            this.$uibModalInstance = $uibModalInstance;
            this.title = title;
            this.departamento = departamento;
            this.pais = pais;
            this.departamentosPais = [];
            pais.forEach(function (el, i) {
                if (el.codigo !== departamento.codigo && el.codigoDoDepartamentoPai !== departamento.codigo) {
                    _this.departamentosPais.push(el);
                }
            });
        }
        PopupDepartamentoController.prototype.cancel = function () {
            this.$uibModalInstance.dismiss("cancel");
        };
        PopupDepartamentoController.prototype.ok = function () {
            this.$uibModalInstance.close(this.departamento);
        };
        PopupDepartamentoController.$inject = ["$uibModalInstance", "title", "departamento", "pais"];
        return PopupDepartamentoController;
    })();
    exports.PopupDepartamentoController = PopupDepartamentoController;
    var PopupDeleteDepartamentoController = (function () {
        function PopupDeleteDepartamentoController($uibModalInstance) {
            this.$uibModalInstance = $uibModalInstance;
        }
        PopupDeleteDepartamentoController.prototype.cancel = function () {
            this.$uibModalInstance.dismiss("cancel");
        };
        PopupDeleteDepartamentoController.prototype.ok = function () {
            this.$uibModalInstance.close();
        };
        PopupDeleteDepartamentoController.$inject = ["$uibModalInstance"];
        return PopupDeleteDepartamentoController;
    })();
    exports.PopupDeleteDepartamentoController = PopupDeleteDepartamentoController;
});
//# sourceMappingURL=DepartamentoController.js.map