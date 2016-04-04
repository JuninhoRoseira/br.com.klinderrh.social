
export interface IApplicationRootScope extends ng.IRootScopeService {
	loggedUser:any; 
}

export interface IAboutScope extends ng.IScope {
	authUser(user: any);
}

export interface ICargoController {
	listarTodos(): void;
	adicionar(): void;
	habilitarEdicao(cargo: any): void;
}

export interface IHomeScope extends ng.IScope {
	rows: Array<any>;
	habilitaEdicao(row: any);
	salvaEdicao($event: ng.IAngularEvent, row: any);
	cancelaEdicao($event: ng.IAngularEvent, row: any);
}