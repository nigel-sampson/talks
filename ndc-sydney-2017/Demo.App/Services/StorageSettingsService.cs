using Windows.Storage;
using Demo.Core.Services;
using Octokit;

namespace Demo.App.Services
{
    public class StorageSettingsService : ISettingsService
    {
        public Credentials GetCredentials()
        {
            var roamingValues = ApplicationData.Current.RoamingSettings.Values;

            if (!roamingValues.ContainsKey("login"))
                return Credentials.Anonymous;

            return new Credentials(roamingValues["login"].ToString(), roamingValues["password"].ToString());
        }

        public void SetCredentials(Credentials credentials)
        {
            var roamingValues = ApplicationData.Current.RoamingSettings.Values;

            roamingValues["login"] = credentials.Login;
            roamingValues["password"] = credentials.Password;
        }
    }
}
