using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Identity
{

	public class ApplicationUser : IdentityUser<Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<Guid>
	{

		public ApplicationUser() : this(Guid.NewGuid()) { }

		public ApplicationUser(Guid id)
		{
			Id = id;
		}

		public string Name { get; set; }
		
	}

	public class ApplicationUserLogin : IdentityUserLogin<Guid>
	{
		//public ApplicationUserLogin() : this(Guid.NewGuid()) { }

		//public ApplicationUserLogin(Guid id)
		//{
		//	Id = id;
		//}

	}

	public class ApplicationUserRole : IdentityUserRole<Guid> { }

	public class ApplicationRole : IdentityRole<Guid, ApplicationUserRole>
	{
		public ApplicationRole() : this(Guid.NewGuid()) { }

		public ApplicationRole(Guid id)
		{
			Id = id;
		}

	}

	public class ApplicationUserClaim : IdentityUserClaim<Guid>
	{
		//public ApplicationUserClaim() : this(Guid.NewGuid()) { }

		//public ApplicationUserClaim(Guid id)
		//{
		//	Id = id;
		//}

	}

}