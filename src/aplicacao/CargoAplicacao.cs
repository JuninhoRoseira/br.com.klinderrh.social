using System;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class CargoAplicacao : ICargoAplicacao
	{

		private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

		public CargoAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho)
		{
			_unidadeDeTrabalho = unidadeDeTrabalho;
		}

		public Cargo Adicionar(CargoModelo cargo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var cargoNovo = new Cargo(
					cargo.Nome,
					cargo.Sigla,
					cargo.Descricao);

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();

				repositorioDeCargos.Incluir(cargoNovo);

				_unidadeDeTrabalho.Salvar();

				return cargoNovo;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

	}

}