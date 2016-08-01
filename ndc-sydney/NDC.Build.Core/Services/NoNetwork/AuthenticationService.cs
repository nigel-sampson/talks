using System;
using System.Threading.Tasks;

namespace NDC.Build.Core.Services.NoNetwork
{
	public class AuthenticationService : IAuthenticationService
	{
		public Task<bool> AuthenticateCredentialsAsync(Credentials credentials)
		{
			return Task.FromResult(credentials.Account == "caliburn-micro");
		}
	}
}
