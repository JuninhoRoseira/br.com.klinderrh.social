using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Identity
{


	public class ApplicationRoleStore : RoleStore<ApplicationRole, Guid, ApplicationUserRole>
	{
		public ApplicationRoleStore(Contexto context) : base(context)
		{
		}
	}


	public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IAppUserStore
	{
		public ApplicationUserStore(Contexto contexto) : base(contexto)
		{

		}
	}


}