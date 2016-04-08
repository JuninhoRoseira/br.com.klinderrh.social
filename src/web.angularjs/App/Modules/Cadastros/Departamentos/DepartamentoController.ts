import Interfaces = require("../../../interfaces/Interfaces");

export class DepartamentoController implements Interfaces.IDepartamentoController {
	'use strict';

	private http: ng.IHttpService;
	private uibModal: ng.ui.bootstrap.IModalService;

	private serviceUrl = "http://localhost:22149/api/departamentos/";

	listaDosDepartamentos: any;

	static $inject = ["$http", "$uibModal"];

	constructor($http: ng.IHttpService, $uibModal: ng.ui.bootstrap.IModalService) {
		this.http = $http;
		this.uibModal = $uibModal;

		this.listarTodos();

	}

	listarTodos(): void {
		this.http
			.get(this.serviceUrl)
			.success((response: any) => {
				this.listaDosDepartamentos = response;
			});
	}

	pesquisar(pesquisa): void {
		this.http
			.get(this.serviceUrl + "/" + pesquisa.texto)
			.success((response: any) => {
				this.listaDosDepartamentos = response;
			});
	}

	adicionar(): void {
		var modalInstance = this.uibModal.open({
			templateUrl: "/App/Modules/Cadastros/Departamentos/DepartamentoForm.html",
			controllerAs: "departamentoPopupCtrl",
			controller: PopupDepartamentoController,
			resolve: {
				title: () => "Novo Departamento",
				departamento: () => ({
					codigo: 0,
					nome: "",
					sigla: "",
					descricao: "",
					codigoDoDepartamentoPai: 0,
					departamentosFilho: []
				}),
				pais:() => this.listaDosDepartamentos
			}
		});

		modalInstance.result.then(departamento => {
			this.http
				.post(this.serviceUrl, departamento)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});
	}

	habilitarEdicao(departamento): void {

		var modalInstance = this.uibModal.open({
			templateUrl: "/App/Modules/Cadastros/Departamentos/DepartamentoForm.html",
			controllerAs: "departamentoPopupCtrl",
			controller: PopupDepartamentoController,
			resolve: {
				title: () => "Editar Departamento",
				departamento: () => ({
					codigo: departamento.codigo,
					nome: departamento.nome,
					sigla: departamento.sigla,
					descricao: departamento.descricao,
					codigoDoDepartamentoPai: departamento.codigoDoDepartamentoPai,
					departamentosFilho: departamento.departamentosFilho
				}),
				pais: () => this.listaDosDepartamentos
			}
		});

		modalInstance.result.then(departamento => {
			this.http
				.put(this.serviceUrl, departamento)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});

	}

	excluir($event, codigoDoDepartamento): void {
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

		modalInstance.result.then(() => {
			this.http
				.delete(this.serviceUrl + "/" + codigoDoDepartamento)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});

	}

}

export class PopupDepartamentoController {
	static $inject = ["$uibModalInstance", "title", "departamento", "pais"];

	private departamentosPais : Array<any>;

	constructor(
		private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
		private title: string,
		private departamento: any,
		private pais: any) {

		this.departamentosPais = [];

		pais.forEach((el, i) => {
			if (el.codigo !== departamento.codigo && el.codigoDoDepartamentoPai !== departamento.codigo) {
				this.departamentosPais.push(el);
			}
		});
		
	}

	cancel() {
		this.$uibModalInstance.dismiss("cancel");
	}

	ok() {
		this.$uibModalInstance.close(this.departamento);
	}

}

export class PopupDeleteDepartamentoController {
	static $inject = ["$uibModalInstance"];

	constructor(private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) { }

	cancel() {
		this.$uibModalInstance.dismiss("cancel");
	}

	ok() {
		this.$uibModalInstance.close();
	}

}