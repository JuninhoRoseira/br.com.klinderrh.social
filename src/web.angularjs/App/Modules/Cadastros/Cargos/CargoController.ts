import Interfaces = require("../../../interfaces/Interfaces");
import Enums = require("../../../enums/Enums");

export class CargoController implements Interfaces.ICargoController {
	'use strict';

	private http: ng.IHttpService;
	private uibModal: ng.ui.bootstrap.IModalService;

	private serviceUrl = "http://localhost:22149/api/cargos/";

	listaDeCargos: any;
	listaDeNiveisDosCargos: any;

	static $inject = ["$http", "$uibModal"];

	constructor(
		$http: ng.IHttpService,
		$uibModal: ng.ui.bootstrap.IModalService) {

		this.http = $http;
		this.uibModal = $uibModal;

		this.listarTodos();
		this.obterNiveisDosCargos();

	}

	listarTodos(): void {
		this.http
			.get(this.serviceUrl)
			.success((response: any) => {
				this.listaDeCargos = response;
			});
	}

	pesquisar(pesquisa): void {
		this.http
			.get(this.serviceUrl + "/" + pesquisa.texto)
			.success((response: any) => {
				this.listaDeCargos = response;
			});
	}

	obterNiveisDosCargos(): void {
		this.http
			.get(this.serviceUrl + "obterniveis")
			.success((response: any) => {
				this.listaDeNiveisDosCargos = response;
			});
	}

	obterNomeDoNivel(codigoDoNivel): string {
		return Enums.NivelDoCargo[codigoDoNivel];
	}

	adicionar(): void {
		var modalInstance = this.uibModal.open({
			templateUrl: "/App/Modules/Cadastros/Cargos/CargoForm.html",
			controllerAs: "cargoPopupCtrl",
			controller: PopupCargoController,
			resolve: {
				title: () => "Novo Cargo",
				cargo: () => ({
					codigo: 0,
					nome: "",
					sigla: "",
					descricao: "",
					nivel: 0
				}),
				niveis: () => this.listaDeNiveisDosCargos
			}
		});

		modalInstance.result.then(cargo => {
			this.http
				.post(this.serviceUrl, cargo)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});
	}

	habilitarEdicao(cargo): void {

		var modalInstance = this.uibModal.open({
			templateUrl: "/App/Modules/Cadastros/Cargos/CargoForm.html",
			controllerAs: "cargoPopupCtrl",
			controller: PopupCargoController,
			resolve: {
				title: () => "Editar Cargo",
				cargo: () => ({
					codigo: cargo.codigo,
					nome: cargo.nome,
					sigla: cargo.sigla,
					descricao: cargo.descricao,
					nivel: cargo.nivel
				}),
				niveis: () => this.listaDeNiveisDosCargos
			}
		});

		modalInstance.result.then(cargo => {
			this.http
				.put(this.serviceUrl, cargo)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});

	}

	excluir($event, codigoDoCargo): void {
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

		modalInstance.result.then(() => {
			this.http
				.delete(this.serviceUrl + "/" + codigoDoCargo)
				.success(() => {
					this.listarTodos();
				})
				.error((a, b, c) => {
					var d = a;
				});
		});

	}

}

export class PopupCargoController {
	static $inject = ["$uibModalInstance", "title", "cargo", "niveis"];

	constructor(
		private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
		private title: string,
		private cargo: any,
		private niveis: any) { }

	cancel() {
		this.$uibModalInstance.dismiss("cancel");
	}

	ok() {
		this.$uibModalInstance.close(this.cargo);
	}

}

export class PopupDeleteCargoController {
	static $inject = ["$uibModalInstance"];

	constructor(private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) { }

	cancel() {
		this.$uibModalInstance.dismiss("cancel");
	}

	ok() {
		this.$uibModalInstance.close();
	}

}