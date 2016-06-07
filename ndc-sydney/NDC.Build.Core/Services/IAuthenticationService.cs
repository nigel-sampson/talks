using System.Threading.Tasks;

namespace NDC.Build.Core.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateCredentialsAsync(Credentials credentials);
    }
}