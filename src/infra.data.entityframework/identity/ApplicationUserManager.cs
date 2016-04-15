using System;
using Microsoft.AspNet.Identity;

namespace br.com.klinderrh.social.infra.data.entityframework.identity
{
	public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
	{
		public ApplicationUserManager(IAppUserStore store) : base(store)
		{
			PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true
			};

			// Configure user lockout defaults
			UserLockoutEnabledByDefault = false;
			DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			MaxFailedAccessAttemptsBeforeLockout = 5;

			//// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			//// You can write your own provider and plug it in here.
			////            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Neo4jUser>
			////            {
			////                MessageFormat = "Your security code is {0}"
			////            });
			////            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Neo4jUser>
			////            {
			////                Subject = "Security Code",
			////                BodyFormat = "Your security code is {0}"
			////            });
			////            manager.EmailService = new EmailService();
			////            manager.SmsService = new SmsService();
			//var dataProtectionProvider = options.DataProtectionProvider;
			//if (dataProtectionProvider != null)
			//{
			//	manager.UserTokenProvider =
			//		new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			//}
		}

	}

}