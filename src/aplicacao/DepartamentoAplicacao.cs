using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class DepartamentoAplicacao : IDepartamentoAplicacao
	{

		private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

		public DepartamentoAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho)
		{
			_unidadeDeTrabalho = unidadeDeTrabalho;
		}

		public Departamento Adicionar(DepartamentoModelo departamento)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				int? codigoDoDepartamentoPai = null;

				if (!string.IsNullOrWhiteSpace(departamento.CodigoDoDepartamentoPai))
				{
					codigoDoDepartamentoPai = int.Parse(departamento.CodigoDoDepartamentoPai);
				}

				int codigoDaUnidade;

				int.TryParse(departamento.CodigoDaUnidade, out codigoDaUnidade);

				var departamentoNovo = new Departamento(
					departamento.Nome,
					departamento.Sigla,
					departamento.Descricao,
					codigoDaUnidade,
					codigoDoDepartamentoPai);

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();

				repositorioDeDepartamentos.Incluir(departamentoNovo);

				_unidadeDeTrabalho.Salvar();

				return departamentoNovo;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

		public void Modificar(DepartamentoModelo departamento)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				int codigo;

				int.TryParse(departamento.Codigo, out codigo);

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentoAlterado = repositorioDeDepartamentos.ObterPorCodigo(codigo);

				if (departamentoAlterado == null) return;

				int? codigoDoDepartamentoPai = null;

				if (!string.IsNullOrWhiteSpace(departamento.CodigoDoDepartamentoPai))
				{
					codigoDoDepartamentoPai = int.Parse(departamento.CodigoDoDepartamentoPai);
				}

				int codigoDaUnidade;

				int.TryParse(departamento.CodigoDaUnidade, out codigoDaUnidade);

				departamentoAlterado.AlterarDados(
					departamento.Nome,
					departamento.Sigla,
					departamento.Descricao,
					codigoDaUnidade,
					codigoDoDepartamentoPai);

				_unidadeDeTrabalho.Salvar();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este Departamento.");

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

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentoExcluido = repositorioDeDepartamentos.ObterPorCodigo(codigo);

				if (departamentoExcluido == null) return;

				departamentoExcluido.Ativo = false;

				_unidadeDeTrabalho.Salvar();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar excluir este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

		public List<Departamento> ObterTodosOsAtivos()
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();

				var departamentosAtivos = repositorioDeDepartamentos.ObterPor(
					d => d.Ativo,
					dp => dp.DepartamentoPai,
					df => df.DepartamentosFilho,
					du => du.Unidade);

				return departamentosAtivos.ToList();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public List<Departamento> ObterTodos()
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentosAtivos = repositorioDeDepartamentos.ObterPor();

				return departamentosAtivos.ToList();

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public Departamento ObterPorCodigo(int codigo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamento = repositorioDeDepartamentos.ObterPor(c => c.Codigo == codigo).FirstOrDefault();

				return departamento;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

		public List<Departamento> ProcurarDepartamentosPorTexto(string textoDaBusca)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentosAtivos = repositorioDeDepartamentos.ObterPor
					(c =>
						c.Ativo &&
						(
							c.Nome.ToLower().Contains(textoDaBusca.ToLower()) ||
							c.Descricao.ToLower().Contains(textoDaBusca.ToLower()) ||
							c.Sigla.ToLower().Contains(textoDaBusca.ToLower())
						),
						dp => dp.DepartamentoPai,
						df => df.DepartamentosFilho,
						du => du.Unidade
					);

				return new List<Departamento>(departamentosAtivos);

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar modificar este Departamento.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}
		}

	}

}