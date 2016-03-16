using System;
using System.Linq;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.comunicacao;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.aplicacao
{
	public class UsuarioAplicacao : IUsuarioAplicacao
	{
		private readonly IUnidadeDeTrabalhoFabrica _unidadeDeTrabalhoFabrica;

		public UsuarioAplicacao(IUnidadeDeTrabalhoFabrica unidadeDeTrabalhoFabrica)
		{
			_unidadeDeTrabalhoFabrica = unidadeDeTrabalhoFabrica;
		}

		public Usuario Registrar(string nome, string email, string senha, string confirmacaoDaSenha)
		{
			var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar();
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = unidadeDeTrabalho.IniciarTransacao();

				var usuario = new Usuario(nome, email);

				usuario.AtribuirSenha(senha, confirmacaoDaSenha);
				usuario.Validar();

				usuario.Valido = false; // Todos os usuários precisam confirmar seu cadastro para poderem acessar o sistema.

				var repositorioDeUsuario = unidadeDeTrabalho.ObterRepositorio<Usuario>();

				repositorioDeUsuario.Incluir(usuario);

				unidadeDeTrabalho.Salvar();

				return usuario;

			}
			catch (Exception ex)
			{
				unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este usuário.");

			}
			finally
			{
				unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
				_unidadeDeTrabalhoFabrica.Destruir(transacaoAbertaAqui);
			}

		}

		public Usuario Autenticar(string email, string senha)
		{
			var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar();
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeUsuario = unidadeDeTrabalho.ObterRepositorio<Usuario>();

				var usuario = repositorioDeUsuario.ObterPor(u => u.Email == email).FirstOrDefault();

				if (usuario != null)
				{
					usuario.VerificarSenha(senha);

					return usuario;

				}

			}
			catch (Exception ex)
			{
				unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar autenticar este usuário.");

			}
			finally
			{
				unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
				_unidadeDeTrabalhoFabrica.Destruir(transacaoAbertaAqui);
			}

			return null;

		}

	}

}