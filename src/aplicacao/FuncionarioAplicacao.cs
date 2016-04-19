using System;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Dominio.ObjetosDeTransporte;
using KlinderRH.Social.Infra.Comum;
using KlinderRH.Social.Infra.Comunicacao;

namespace KlinderRH.Social.Aplicacao
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

				var repositorioDeFuncionarios = _unidadeDeTrabalho.ObterRepositorio<Funcionario>();

				var funcionario = new Funcionario(
					funcionarioModelo.Matricula,
					pessoaNova.Id,
					funcionarioModelo.EmpresaId.ToGuid(),
					funcionarioModelo.DepartamentoId.ToGuid(),
					funcionarioModelo.CargoId.ToGuid());

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