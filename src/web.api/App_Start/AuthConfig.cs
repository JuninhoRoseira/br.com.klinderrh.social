using System;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Infra.IoC;
//using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace KlinderRH.Social.Web.Api
{

	/// <summary>
	/// Configura��o do m�todo de autentica��o do API.
	/// </summary>
	public static class AuthConfig
	{

		/// <summary>
		/// Configura��o do m�todo de autentica��o do API.
		/// </summary>
		/// <param name="appBuilder"></param>
		/// <param name="dependencyResolver"></param>
		public static void ConfigureAuth(this IAppBuilder appBuilder, NinjectResolver dependencyResolver)
		{
			//// Microsoft.Owin.Security.Cookies
			//// Microsoft.AspNet.Identity.Core
			//// We're enabling cookie authentication, but with a specific cookie name.
			//appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
			//{
			//	AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
			//	CookieHttpOnly = true,
			//	CookieName = "KlinderRH.Auth"
			//});

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