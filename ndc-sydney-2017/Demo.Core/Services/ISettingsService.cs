using Octokit;

namespace Demo.Core.Services
{
    public interface ISettingsService
    {
        Credentials GetCredentials();
        void SetCredentials(Credentials credentials);
    }
}
