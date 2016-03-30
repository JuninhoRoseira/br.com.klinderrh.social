using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Modificar(CargoModelo cargo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				int codigo;

				int.TryParse(cargo.Codigo, out codigo);

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargoAlterado = repositorioDeCargos.ObterPorCodigo(codigo);

				if (cargoAlterado == null) return;

				cargoAlterado.AlterarDados(cargo.Nome, cargo.Sigla, cargo.Descricao);

				_unidadeDeTrabalho.Salvar();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

		public void Excluir(int codigo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargoexcluido = repositorioDeCargos.ObterPorCodigo(codigo);

				if (cargoexcluido == null) return;

				cargoexcluido.Ativo = false;

				_unidadeDeTrabalho.Salvar();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar excluir este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

		public List<Cargo> ObterTodosOsAtivos()
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargosAtivos = repositorioDeCargos.ObterPor(c=>c.Ativo);

				return new List<Cargo>(cargosAtivos);

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public List<Cargo> ObterTodos()
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargosAtivos = repositorioDeCargos.ObterPor();

				return new List<Cargo>(cargosAtivos);

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public Cargo ObterPorCodigo(int codigo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargo = repositorioDeCargos.ObterPor(c => c.Codigo == codigo).FirstOrDefault();

				return cargo;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public List<Cargo> ProcurarCargosPorTexto(string textoDaBusca)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargosAtivos = repositorioDeCargos.ObterPor
					(c =>
						c.Ativo &&
						(
							c.Nome.ToLower().Contains(textoDaBusca.ToLower()) ||
							c.Descricao.ToLower().Contains(textoDaBusca.ToLower()) ||
							c.Sigla.ToLower().Contains(textoDaBusca.ToLower())
						)
					);

				return new List<Cargo>(cargosAtivos);

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este cargo.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

	}

}