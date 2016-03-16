(function () {
    'use strict';

    var serviceUrl = "http://localhost:64449/api/apontamentos/";

    angular
		.module("klinderrh.web.ui")
		.controller('HomeCtrl', ['$scope', '$http', HomeCtrl]);

    function HomeCtrl($scope, $http) {
        $scope.rows = [];

        $scope.habilitaEdicao = function (row) {
            $scope.rows.forEach(function(el, i) {
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
               get(serviceUrl + 'ObterEntradasPorMes?ano=2015&mes=1').
               success(function (response) {
                $scope.rows = response;

            }).
               error(function (error) {
                   console.log(error);
               });

    }

})();