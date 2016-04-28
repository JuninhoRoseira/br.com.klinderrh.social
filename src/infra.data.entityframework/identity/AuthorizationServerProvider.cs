using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KlinderRH.Core.Seguranca;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;

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
			var header = context.OwinContext.Response.Headers.SingleOrDefault(h => h.Key == "Access-Control-Allow-Origin");

			if (header.Equals(default(KeyValuePair<string, string[]>)))
			{
				context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
			}

			try
			{
				var usuario = await _userManager.FindAsync(context.UserName, context.Password);

				if (usuario == null)
				{
					context.SetError("invalid_grant", $"Usuário {context.UserName} não encontrado. {context.Password}");
					context.Rejected();

					return;

				}

				// create identity
				var id = await _userManager.CreateIdentityAsync(usuario, context.Options.AuthenticationType);

				id.AddClaims(new List<Claim>
					{
						new Claim("sub", context.UserName),
						new Claim("role", "User")
					});

				// base64-encode this data.
				var protectedText = Criptografia.Encrypt(
					JsonConvert.SerializeObject(new
					{
						usuario.Id,
						usuario.Name,
						context.UserName,
						usuario.Email,
						Roles = id.Claims.Where(c => c.Type == ClaimTypes.Role).Select(r => r.Value)
					}),
					context.UserName);

				var props = new AuthenticationProperties(new Dictionary<string, string>
				{
					{"content", protectedText}
				});
				
				// User is found. Signal this by calling context.Validated
				context.Validated(new AuthenticationTicket(id, props));
				
			}
			catch (Exception ex)
			{
				// Could not retrieve the user.
				context.SetError("server_error", ex.Message);
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