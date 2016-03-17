using System;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class PessoaAplicacao : IPessoaAplicacao
	{
		private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
		private readonly IUsuarioAplicacao _usuarioAplicacao;

		public PessoaAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho, IUsuarioAplicacao usuarioAplicacao)
		{
			_unidadeDeTrabalho = unidadeDeTrabalho;
			_usuarioAplicacao = usuarioAplicacao;
		}

		public Pessoa Adicionar(PessoaModelo pessoa)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				const string senhaPadrao = "Klinder@RH123"; //TODO: Depois colocar no web.config

				var novoUsuario = _usuarioAplicacao.Registrar(new UsuarioModelo
				{
					Nome = pessoa.Nome,
					Email = pessoa.Email,
					Senha = senhaPadrao,
					ConfirmacaoDaSenha = senhaPadrao
				});
				
				DateTime dataDeNascimento;

				DateTime.TryParse(pessoa.DataDeNascimento, out dataDeNascimento);

				var novaPessoa = new Pessoa(
					pessoa.Nome,
					pessoa.RG,
					pessoa.CPF,
					dataDeNascimento)
				{
					Usuario = novoUsuario
				};
				
				var repositorioDePessoa = _unidadeDeTrabalho.ObterRepositorio<Pessoa>();

				repositorioDePessoa.Incluir(novaPessoa);

				_unidadeDeTrabalho.Salvar();

				return novaPessoa;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar esta pessoa.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

	}

}