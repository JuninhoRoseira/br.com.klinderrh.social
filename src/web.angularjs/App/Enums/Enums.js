define(["require", "exports"], function (require, exports) {
    "use strict";
    (function (NivelDoCargo) {
        NivelDoCargo[NivelDoCargo["Nenhum"] = 1] = "Nenhum";
        NivelDoCargo[NivelDoCargo["Estagiario"] = 2] = "Estagiario";
        NivelDoCargo[NivelDoCargo["Trainee"] = 3] = "Trainee";
        NivelDoCargo[NivelDoCargo["Junior"] = 4] = "Junior";
        NivelDoCargo[NivelDoCargo["Pleno"] = 5] = "Pleno";
        NivelDoCargo[NivelDoCargo["Senior"] = 6] = "Senior";
        NivelDoCargo[NivelDoCargo["CoordenadorChefe"] = 7] = "CoordenadorChefe";
        NivelDoCargo[NivelDoCargo["Gerente"] = 8] = "Gerente";
        NivelDoCargo[NivelDoCargo["Superintendente"] = 9] = "Superintendente";
        NivelDoCargo[NivelDoCargo["Diretor"] = 10] = "Diretor";
        NivelDoCargo[NivelDoCargo["Presidente"] = 11] = "Presidente";
    })(exports.NivelDoCargo || (exports.NivelDoCargo = {}));
    var NivelDoCargo = exports.NivelDoCargo;
    (function (TipoDeEndereco) {
        TipoDeEndereco[TipoDeEndereco["Residencial"] = 1] = "Residencial";
        TipoDeEndereco[TipoDeEndereco["Correspondencia"] = 2] = "Correspondencia";
        TipoDeEndereco[TipoDeEndereco["Entrega"] = 3] = "Entrega";
        TipoDeEndereco[TipoDeEndereco["Comercial"] = 4] = "Comercial";
        TipoDeEndereco[TipoDeEndereco["Outros"] = 5] = "Outros";
    })(exports.TipoDeEndereco || (exports.TipoDeEndereco = {}));
    var TipoDeEndereco = exports.TipoDeEndereco;
});
//# sourceMappingURL=Enums.js.map