using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace br.com.klinderrh.social.infra.data.entityframework.identity
{
	public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IAppUserStore
	{
		public ApplicationUserStore(Contexto contexto) : base(contexto)
		{

		}
	}
}