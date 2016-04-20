using Microsoft.Owin.Cors;
using Owin;

namespace KlinderRH.Social.Web.Api
{
	/// <summary>
	/// Configurações gerais do API.
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
			var config = DependencyResolverConfig.Register(appBuilder);
			
			WebApiConfig.Register(config);
			SwaggerConfig.Register(config);

			appBuilder.UseCors(CorsOptions.AllowAll);
			appBuilder.UseWebApi(config);

		}

	}

}