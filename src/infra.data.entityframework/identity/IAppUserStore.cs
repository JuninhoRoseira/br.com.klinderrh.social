using System;
using Microsoft.AspNet.Identity;

namespace br.com.klinderrh.social.infra.data.entityframework.identity
{
	public interface IAppUserStore : IUserStore<ApplicationUser, Guid> { }
}