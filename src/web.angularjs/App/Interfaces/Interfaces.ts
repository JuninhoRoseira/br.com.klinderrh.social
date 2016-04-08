
export interface IApplicationRootScope extends ng.IRootScopeService {
	loggedUser:any; 
}

export interface IAboutScope extends ng.IScope {
	authUser(user: any);
}

export interface ICargoController {
	listarTodos(): void;
	pesquisar(pesquisa): void;
	adicionar(): void;
	habilitarEdicao(cargo: any): void;
	excluir($event, codigoDoCargo): void;
}

export interface IDepartamentoController {
	listarTodos(): void;
	pesquisar(pesquisa): void;
	adicionar(): void;
	habilitarEdicao(departamento: any): void;
	excluir($event, codigoDoDepartamento): void;
}

export interface IHomeScope extends ng.IScope {
	rows: Array<any>;
	habilitaEdicao(row: any);
	salvaEdicao($event: ng.IAngularEvent, row: any);
	cancelaEdicao($event: ng.IAngularEvent, row: any);
}