using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Identity
{
	public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IAppUserStore
	{
		public ApplicationUserStore(Contexto contexto) : base(contexto)
		{

		}
	}
}