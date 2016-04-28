using System;
using System.Collections.Generic;
using System.Linq;
using KlinderRH.Core.Comum;
using KlinderRH.Core.Comunicacao;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Dominio.ObjetosDeTransporte;
using KlinderRH.Social.Dominio.ObjetosDeValor;

namespace KlinderRH.Social.Aplicacao
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

				var nivelDoCargo = (NivelDoCargo) cargo.Nivel;

				var cargoNovo = new Cargo(
					cargo.Nome,
					cargo.Sigla,
					cargo.Descricao,
					nivelDoCargo);

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

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargoAlterado = repositorioDeCargos.ObterPorId(cargo.Id.ToGuid());

				if (cargoAlterado == null) return;

				var nivelDoCargo = (NivelDoCargo)cargo.Nivel;

				cargoAlterado.AlterarDados(cargo.Nome, cargo.Sigla, cargo.Descricao, nivelDoCargo);

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

		public void Excluir(Guid id)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargoexcluido = repositorioDeCargos.ObterPorId(id);

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

		public Cargo ObterPorId(Guid id)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorio<Cargo>();
				var cargo = repositorioDeCargos.ObterPor(c => c.Id == id).FirstOrDefault();

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

		public List<NivelDoCargoEnum> ObterNiveis()
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeCargos = _unidadeDeTrabalho.ObterRepositorioDeEnums<NivelDoCargoEnum>();
				var niveis = repositorioDeCargos.ObterPor();

				return new List<NivelDoCargoEnum>(niveis);

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar obter a lista de níveis dos cargos.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		} 

	}

}