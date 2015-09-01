using System.Threading.Tasks;

namespace Hubb.Core.Services
{
    public class NoNetworkAuthenticationService : IAuthenticationService
    {
        public Task<bool> AreCredentialsValidAsync(string username, string password)
        {
            return Task.FromResult(username == "hubb-demo");
        }
    }
}
