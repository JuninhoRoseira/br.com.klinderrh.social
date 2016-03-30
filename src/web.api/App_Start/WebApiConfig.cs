using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace br.com.klinderrh.social.web.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			// PARA TRABALHAR COM REST JSON
			var formatters = config.Formatters;
			var jsonFormatter = formatters.OfType<JsonMediaTypeFormatter>().First();

			jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

			config.Formatters.Remove(config.Formatters.XmlFormatter);

			var settings = jsonFormatter.SerializerSettings;

			settings.Formatting = Formatting.Indented;
			settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // Para que não dê problema com LazyLoading
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Serialize with camelCase formatter for JSON.
			
			// Web API routes
			config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api"));

			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			config.EnableCors();

		}

	}

	public class CentralizedPrefixProvider : DefaultDirectRouteProvider
	{
		private readonly string _centralizedPrefix;

		public CentralizedPrefixProvider(string centralizedPrefix)
		{
			_centralizedPrefix = centralizedPrefix;
		}

		protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
		{
			var existingPrefix = base.GetRoutePrefix(controllerDescriptor);

			return existingPrefix == null 
				? _centralizedPrefix 
				: $"{_centralizedPrefix}/{existingPrefix}";

		}

	}

}