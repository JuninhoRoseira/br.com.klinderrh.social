using System;
using System.Reflection;
using System.Web.Http;
using br.com.klinderrh.social.infra.interfaces;
using br.com.klinderrh.social.infra.ioc;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace br.com.klinderrh.social.web.api
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup
	{

		/// <summary>
		/// This code configures Web API. The Startup class is specified as a type 
		/// parameter in the WebApp.Start method.
		/// </summary>
		/// <param name="appBuilder"></param>
		public void Configuration(IAppBuilder appBuilder)
		{
			appBuilder.UseCors(CorsOptions.AllowAll);

			var dependencyResolver = new NinjectResolver(new IoC().Kernel);

			dependencyResolver.Load(Assembly.GetExecutingAssembly());

			// Configure Web API for self-host. 
			var config = new HttpConfiguration
			{
				DependencyResolver = dependencyResolver
			};

			WebApiConfig.Register(config);

			appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString("/api/auth"),
				Provider = (IOAuthAuthorizationServerProvider)dependencyResolver.Get<IAuthorizationServerProvider>(), 
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				AllowInsecureHttp = true
			});
			appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			SwaggerConfig.Register(config);
			
			appBuilder.UseWebApi(config);

		}

	}

}