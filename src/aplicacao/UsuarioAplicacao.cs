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
			using (var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar())
			{
				try
				{
					unidadeDeTrabalho.IniciarTransacao();

					var usuario = new Usuario(nome, email);

					usuario.AtribuirSenha(senha, confirmacaoDaSenha);
					usuario.Validar();

					var repositorioDeUsuario = unidadeDeTrabalho.ObterRepositorio<Usuario>();

					repositorioDeUsuario.Incluir(usuario);

					return usuario;

				}
				catch (Exception ex)
				{
					unidadeDeTrabalho.DescartarTransacao();

					EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

					throw new Exception("Erro ao tentar registrar este usuário.");

				}
				finally
				{
					unidadeDeTrabalho.Salvar();
				}

			}

		}

		public Usuario Autenticar(string email, string senha)
		{
			using (var unidadeDeTrabalho = _unidadeDeTrabalhoFabrica.Criar())
			{
				try
				{
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
					EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

					throw new Exception("Erro ao tentar autenticar este usuário.");
				}

				return null;

			}

		}

	}

}