using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Identity
{
	public class AuthorizationServerProvider : OAuthAuthorizationServerProvider, IAuthorizationServerProvider
	{

		private readonly ApplicationUserManager _userManager;

		public AuthorizationServerProvider(ApplicationUserManager userManager)
		{
			_userManager = userManager;
		}

		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();

			await Task.FromResult<object>(null);

		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{

			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			ApplicationUser usuario;

			try
			{
				usuario = await _userManager.FindAsync(context.UserName, context.Password);
			}
			catch
			{
				// Could not retrieve the user.
				context.SetError("server_error");
				context.Rejected();

				// Return here so that we don't process further. Not ideal but needed to be done here.
				return;
			}

			if (usuario != null)
			{
				try
				{
					// User is found. Signal this by calling context.Validated
					
					// create identity
					var claims = new List<Claim>
					{
						new Claim("sub", context.UserName),
						new Claim("role", "user")
					};

					var id = new ClaimsIdentity(context.Options.AuthenticationType);

					id.AddClaims(claims);

					var props = new AuthenticationProperties(new Dictionary<string, string>
					{
						{"id", usuario.Id.ToString()},
						{"nome", usuario.Name},
						{"email", usuario.Email}
					});

					var ticket = new AuthenticationTicket(id, props);

					context.Validated(ticket);

				}
				catch
				{
					// The ClaimsIdentity could not be created by the UserManager.
					context.SetError("server_error");
					context.Rejected();
				}
			}
			else
			{
				// The resource owner credentials are invalid or resource owner does not exist.
				context.SetError("access_denied", "The resource owner credentials are invalid or resource owner does not exist.");
				context.Rejected();
			}

		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (var property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);

		}

	}

}