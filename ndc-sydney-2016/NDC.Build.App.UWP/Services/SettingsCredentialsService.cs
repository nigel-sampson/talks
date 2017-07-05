using System;
using System.Threading.Tasks;
using Windows.Storage;
using NDC.Build.Core.Services;

namespace NDC.Build.App.UWP.Services
{
    public class SettingsCredentialsService : ICredentialsService
    {
        public Task<Credentials> GetCredentialsAsync()
        {
            var roaming = ApplicationData.Current.RoamingSettings;
            var container = roaming.CreateContainer("credentials", ApplicationDataCreateDisposition.Always);

            var account = container.Values["account"];
            var token = container.Values["token"];

            if (account == null || token == null)
                return Task.FromResult(Credentials.None);

            return Task.FromResult(new Credentials(account.ToString(), token.ToString()));
        }

        public Task StoreAsync(Credentials credentials)
        {
            var roaming = ApplicationData.Current.RoamingSettings;
            var container = roaming.CreateContainer("credentials", ApplicationDataCreateDisposition.Always);

            container.Values["account"] = credentials.Account;
            container.Values["token"] = credentials.Token;

            return Task.FromResult(true);
        }
    }
}
