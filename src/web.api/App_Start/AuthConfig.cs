using System;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Infra.IoC;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace KlinderRH.Social.Web.Api
{

	/// <summary>
	/// Configuração do método de autenticação do API.
	/// </summary>
	public static class AuthConfig
	{

		/// <summary>
		/// Configuração do método de autenticação do API.
		/// </summary>
		/// <param name="appBuilder"></param>
		/// <param name="dependencyResolver"></param>
		public static void ConfigureAuth(this IAppBuilder appBuilder, NinjectResolver dependencyResolver)
		{
			appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString("/api/auth"),
				Provider = (IOAuthAuthorizationServerProvider)dependencyResolver.Get<IAuthorizationServerProvider>(),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				ApplicationCanDisplayErrors = true,
				AllowInsecureHttp = true
			});

			appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
			{
				AuthenticationMode = AuthenticationMode.Active,
				AuthenticationType = "Bearer"
			});

		}

	}

}