using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace br.com.klinderrh.social.aplicacao
{
	public class AuthorizationServerProvider : OAuthAuthorizationServerProvider, IAuthorizationServerProvider
	{
		private readonly IUsuarioAplicacao _usuarioAplicacao;

		public AuthorizationServerProvider(IUsuarioAplicacao usuarioAplicacao)
		{
			_usuarioAplicacao = usuarioAplicacao;
		}

		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{

			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			Usuario user;

			try
			{
				//user = await userManager.FindAsync(context.UserName, context.Password);
				user = _usuarioAplicacao.Autenticar(new UsuarioModelo
				{
					Email = context.UserName,
					Senha = context.Password
				});
			}
			catch
			{
				// Could not retrieve the user.
				context.SetError("server_error");
				context.Rejected();

				// Return here so that we don't process further. Not ideal but needed to be done here.
				return;
			}

			if (user != null)
			{
				try
				{
					// User is found. Signal this by calling context.Validated
					// create identity


					var claims = new List<Claim>
					{
						new Claim("sub", context.UserName),
						new Claim("role", "user")
					};

					var id = new ClaimsIdentity(context.Options.AuthenticationType);

					id.AddClaims(claims);

					var props = new AuthenticationProperties(new Dictionary<string, string>
					{
						{"codigo", user.Codigo.ToString()},
						{"nome", user.Nome},
						{"dataDeCadastro", user.DataDeCadastro.ToString("dd-MM-yyyy HH:ss")},
						{"ativo", user.Ativo.ToString().ToLower()},
						{"email", user.Email}
					});

					var ticket = new AuthenticationTicket(id, props);

					context.Validated(ticket);

				}
				catch
				{
					// The ClaimsIdentity could not be created by the UserManager.
					context.SetError("server_error");
					context.Rejected();
				}
			}
			else
			{
				// The resource owner credentials are invalid or resource owner does not exist.
				context.SetError(
					"access_denied",
					"The resource owner credentials are invalid or resource owner does not exist.");

				context.Rejected();
			}

		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);

		}

	}
}