using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace br.com.klinderrh.social.web.api
{
	/// <summary>
	/// 
	/// </summary>
	public class CentralizedPrefixProvider : DefaultDirectRouteProvider
	{
		private readonly string _centralizedPrefix;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="centralizedPrefix"></param>
		public CentralizedPrefixProvider(string centralizedPrefix)
		{
			_centralizedPrefix = centralizedPrefix;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="controllerDescriptor"></param>
		/// <returns></returns>
		protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
		{
			var existingPrefix = base.GetRoutePrefix(controllerDescriptor);

			return existingPrefix == null 
				? _centralizedPrefix 
				: $"{_centralizedPrefix}/{existingPrefix}";

		}

	}

}