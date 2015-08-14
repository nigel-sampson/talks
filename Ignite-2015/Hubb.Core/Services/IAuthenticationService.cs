using System.Threading.Tasks;

namespace Hubb.Core.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AreCredentialsValidAsync(string username, string password);
    }
}