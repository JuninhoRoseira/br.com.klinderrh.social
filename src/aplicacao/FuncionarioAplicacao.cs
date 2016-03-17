using System;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class FuncionarioAplicacao : IFuncionarioAplicacao
	{
		private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
		private readonly IPessoaAplicacao _pessoaAplicacao;

		public FuncionarioAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho, IPessoaAplicacao pessoaAplicacao)
		{
			_unidadeDeTrabalho = unidadeDeTrabalho;
			_pessoaAplicacao = pessoaAplicacao;
		}

		public Funcionario Adicionar(FuncionarioModelo funcionarioModelo)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var pessoaNova = _pessoaAplicacao.Adicionar(new PessoaModelo
				{
					Nome = funcionarioModelo.Nome,
					Email = funcionarioModelo.Email,
					RG = funcionarioModelo.RG,
					CPF = funcionarioModelo.CPF,
					DataDeNascimento = funcionarioModelo.DataDeNascimento
				});

				int codigoDaEmpresa, codigoDoDepartamento, codigoDoCargo;

				int.TryParse(funcionarioModelo.CodigoDaEmpresa, out codigoDaEmpresa);
				int.TryParse(funcionarioModelo.CodigoDoDepartamento, out codigoDoDepartamento);
				int.TryParse(funcionarioModelo.CodigoDoCargo, out codigoDoCargo);

				var funcionario = new Funcionario(
					funcionarioModelo.Matricula,
					pessoaNova.Codigo,
					codigoDaEmpresa,
					codigoDoDepartamento,
					codigoDoCargo);

				var repositorioDeFuncionarios = _unidadeDeTrabalho.ObterRepositorio<Funcionario>();

				repositorioDeFuncionarios.Incluir(funcionario);

				_unidadeDeTrabalho.Salvar();

				return funcionario;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este funcionário.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

	}

}