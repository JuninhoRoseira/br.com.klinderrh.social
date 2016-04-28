using System;
using System.Linq;
using KlinderRH.Core.Comunicacao;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Dominio.ObjetosDeTransporte;

namespace KlinderRH.Social.Aplicacao
{
	public class UsuarioAplicacao : IUsuarioAplicacao
	{
		private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

		public UsuarioAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho)
		{
			_unidadeDeTrabalho = unidadeDeTrabalho;
		}

		public Usuario Registrar(UsuarioModelo usuario)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var usuarioNovo = new Usuario(usuario.Nome, usuario.Email);

				usuarioNovo.AtribuirSenha(usuario.Senha, usuario.ConfirmacaoDaSenha);
				usuarioNovo.Validar();

				usuarioNovo.Valido = false; // Todos os usuários precisam confirmar seu cadastro para poderem acessar o sistema.

				var repositorioDeUsuario = _unidadeDeTrabalho.ObterRepositorio<Usuario>();

				repositorioDeUsuario.Incluir(usuarioNovo);

				_unidadeDeTrabalho.Salvar();

				return usuarioNovo;

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar registrar este usuário.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

		}

		public Usuario Autenticar(UsuarioModelo usuario)
		{
			var transacaoAbertaAqui = false;

			try
			{
				transacaoAbertaAqui = _unidadeDeTrabalho.IniciarTransacao();

				var repositorioDeUsuario = _unidadeDeTrabalho.ObterRepositorio<Usuario>();

				var usuarioAutenticado = repositorioDeUsuario.ObterPor(u => u.Email == usuario.Email).FirstOrDefault();

				if (usuarioAutenticado != null)
				{
					usuarioAutenticado.VerificarSenha(usuario.Senha);

					return usuarioAutenticado;

				}

			}
			catch (Exception ex)
			{
				_unidadeDeTrabalho.DescartarTransacao(transacaoAbertaAqui);

				EmailHelper.EnviarEmail("juninhoroseira@gmail.com", "Erro", ex.GetBaseException().ToString());

				throw new Exception("Erro ao tentar autenticar este usuário.");

			}
			finally
			{
				_unidadeDeTrabalho.EfetivarTransacao(transacaoAbertaAqui);
			}

			return null;

		}

	}

}