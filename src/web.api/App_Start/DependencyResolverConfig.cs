using System.Reflection;
using System.Web.Http;
using KlinderRH.Social.Infra.IoC;
using Owin;

namespace KlinderRH.Social.Web.Api
{
	/// <summary>
	/// Cria o gerenciador de injeção de dependências do API.
	/// </summary>
	public class DependencyResolverConfig
	{
		/// <summary>
		/// Registra o container de IoC do API.
		/// </summary>
		/// <param name="appBuilder"></param>
		public static HttpConfiguration Register(IAppBuilder appBuilder)
		{
			var dependencyResolver = new NinjectResolver(new IoC().Kernel);

			dependencyResolver.Load(Assembly.GetExecutingAssembly());

			appBuilder.ConfigureAuth(dependencyResolver);
			
			return new HttpConfiguration()
			{
				DependencyResolver = dependencyResolver
			};

		}

	}

}