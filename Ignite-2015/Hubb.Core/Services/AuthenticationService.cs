using System;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IGitHubClient gitHubClient;

        public AuthenticationService(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public async Task<bool> AreCredentialsValidAsync(string username, string password)
        {
            try
            {
                gitHubClient.Connection.Credentials = new Credentials(username, password);

                await gitHubClient.User.Current();

                return true;
            }
            catch(AuthorizationException)
            {
                return false;
            }
        }
    }
}
