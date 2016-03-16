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
		private readonly IUnidadeDeTrabalhoFabrica _unidadeDeTrabalhoFabrica;
		private readonly IUsuarioAplicacao _usuarioAplicacao;
		private readonly IPessoaAplicacao _pessoaAplicacao;

		public FuncionarioAplicacao(IUnidadeDeTrabalhoFabrica unidadeDeTrabalhoFabrica, IUsuarioAplicacao usuarioAplicacao, IPessoaAplicacao pessoaAplicacao)
		{
			_unidadeDeTrabalhoFabrica = unidadeDeTrabalhoFabrica;
			_usuarioAplicacao = usuarioAplicacao;
			_pessoaAplicacao = pessoaAplicacao;
		}

		public Funcionario Adicionar(FuncionarioModelo funcionarioModelo)
		{
			var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar();
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = unidadeDeTrabalho.IniciarTransacao();

				const string senhaPadrao = "Klinder@RH123"; //TODO: Depois colocar no web.config

				var usuarioNovo = _usuarioAplicacao.Registrar(
					funcionarioModelo.Nome,
					funcionarioModelo.Email,
					senhaPadrao,
					senhaPadrao);
				
				var pessoaNova = _pessoaAplicacao.Adicionar(
					funcionarioModelo.Nome,
					funcionarioModelo.RG,
					funcionarioModelo.CPF,
					Convert.ToDateTime(funcionarioModelo.DataDeNascimento),
					usuarioNovo.Codigo);

				var funcionario = new Funcionario(
					funcionarioModelo.Matricula,
					pessoaNova.Codigo,
					int.Parse(funcionarioModelo.CodigoDaEmpresa),
					int.Parse(funcionarioModelo.CodigoDoDepartamento),
					int.Parse(funcionarioModelo.CodigoDoCargo));

				var repositorioDeFuncionarios = unidadeDeTrabalho.ObterRepositorio<Funcionario>();

				repositorioDeFuncionarios.Incluir(funcionario);

				unidadeDeTrabalho.Salvar();

				return funcionario;

			}
			catch (Exception ex)
			{
				unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este funcionário.");

			}
			finally
			{
				unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
				_unidadeDeTrabalhoFabrica.Destruir(transacaoAbertaAqui);
			}

		}

	}

}