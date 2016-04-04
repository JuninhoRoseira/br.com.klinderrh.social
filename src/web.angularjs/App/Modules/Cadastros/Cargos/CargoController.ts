import Interfaces = require("../../../interfaces/Interfaces");

export class CargoController implements Interfaces.ICargoController {
	'use strict';

	private http: ng.IHttpService;
	private uibModal: ng.ui.bootstrap.IModalService;

	private serviceUrl = "http://localhost:22149/api/cargos/";

	listaDeCargos: any;

	static $inject = ["$http", "$uibModal"];

	constructor(
		$http: ng.IHttpService,
		$uibModal: ng.ui.bootstrap.IModalService) {

		this.http = $http;
		this.uibModal = $uibModal;

		this.listarTodos();

	}

	listarTodos(): void {
		this.http
			.get(this.serviceUrl)
			.success((response: any) => {
				this.listaDeCargos = response;
			});
	}

	adicionar(): void {}

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
					descricao: cargo.descricao
				})
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

}

export class PopupCargoController {
	static $inject = ["$uibModalInstance", "title", "cargo"];


	constructor(
		private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
		private title: string,
		private cargo: any) {}

	cancel() {
		this.$uibModalInstance.dismiss("cancel");
	}

	ok() {
		this.$uibModalInstance.close(this.cargo);
	}

}