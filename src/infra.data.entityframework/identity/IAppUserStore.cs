using System;
using Microsoft.AspNet.Identity;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Identity
{
	public interface IAppUserStore : IUserStore<ApplicationUser, Guid> { }
}