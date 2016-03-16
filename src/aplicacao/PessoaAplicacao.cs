using System;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class PessoaAplicacao : IPessoaAplicacao
	{
		private readonly IUnidadeDeTrabalhoFabrica _unidadeDeTrabalhoFabrica;

		public PessoaAplicacao(IUnidadeDeTrabalhoFabrica unidadeDeTrabalhoFabrica)
		{
			_unidadeDeTrabalhoFabrica = unidadeDeTrabalhoFabrica;
		}

		public Pessoa Adicionar(string nome, string rg, string cpf, DateTime dataDeNascimento, int codigoDoUsuario)
		{
			var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar();
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeUsuario = unidadeDeTrabalho.ObterRepositorio<Usuario>();
				var usuario = repositorioDeUsuario.ObterPorCodigo(codigoDoUsuario);
				var pessoa = new Pessoa(
					nome,
					rg,
					cpf,
					dataDeNascimento);

				if (usuario != null)
				{
					pessoa.Usuario = usuario;
				}

				var repositorioDeFuncionario = unidadeDeTrabalho.ObterRepositorio<Pessoa>();

				repositorioDeFuncionario.Incluir(pessoa);

				unidadeDeTrabalho.Salvar();

				return pessoa;

			}
			catch (Exception ex)
			{
				unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar esta pessoa.");

			}
			finally
			{
				unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
				_unidadeDeTrabalhoFabrica.Destruir(transacaoAbertaAqui);
			}

		}

	}

}