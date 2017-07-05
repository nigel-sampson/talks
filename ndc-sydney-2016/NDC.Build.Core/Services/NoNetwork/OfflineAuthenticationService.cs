using System;
using System.Threading.Tasks;

namespace NDC.Build.Core.Services.NoNetwork
{
	public class OfflineAuthenticationService : IAuthenticationService
	{
		public Task<bool> AuthenticateCredentialsAsync(Credentials credentials)
		{
			return Task.FromResult(credentials.Account == "caliburn-micro");
		}
	}
}
