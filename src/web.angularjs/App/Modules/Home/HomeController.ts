import Interfaces = require("../../interfaces/Interfaces");

export class HomeController {
	'use strict';

	private serviceUrl = "http://localhost:22149/api/";

	static $inject = ["$scope", '$http'];

	constructor(
		$scope: Interfaces.IHomeScope,
		$http: ng.IHttpService) {

		$scope.rows = [];

        $scope.habilitaEdicao = row => {
	        $scope.rows.forEach((el, i) => {
		        el.editing = false;
	        });

	        row.editing = true;

        };

        $scope.salvaEdicao = ($event, row) => {
	        $event.stopPropagation();

	        row.editing = false;

        };

        $scope.cancelaEdicao = ($event, row) => {
	        $event.stopPropagation();

	        row.editing = false;

        };

        $http.
			get(this.serviceUrl + 'ObterEntradasPorMes?ano=2015&mes=1').
			success(response => {
		        $scope.rows = <any[]>(response);

	        }).
			error(error => {
		        console.log(error);
	        });
	}

}