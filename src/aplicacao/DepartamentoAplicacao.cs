using System;
using System.Collections.Generic;
using System.Linq;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.interfaces.aplicacao;
using br.com.klinderrh.social.dominio.interfaces.dados;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.comunicacao;

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

				var departamentoNovo = new Departamento(
					departamento.Nome,
					departamento.Sigla,
					departamento.Descricao,
					departamento.UnidadeId.ToGuid(),
					departamento.DepartamentoPaiId.ToNulleableGuid());

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

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentoAlterado = repositorioDeDepartamentos.ObterPorId(departamento.Id.ToGuid());

				if (departamentoAlterado == null) return;

				departamentoAlterado.AlterarDados(
					departamento.Nome,
					departamento.Sigla,
					departamento.Descricao,
					departamento.UnidadeId.ToGuid(),
					departamento.DepartamentoPaiId.ToNulleableGuid());

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

		public void Excluir(Guid id)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamentoExcluido = repositorioDeDepartamentos.ObterPorId(id);

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

		public Departamento ObterPorId(Guid id)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeDepartamentos = _unidadeDeTrabalho.ObterRepositorio<Departamento>();
				var departamento = repositorioDeDepartamentos.ObterPor(c => c.Id == id).FirstOrDefault();

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