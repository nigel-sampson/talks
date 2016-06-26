using System;
using System.Threading.Tasks;
using Android.App;
using Android.Preferences;
using NDC.Build.Core.Services;

namespace NDC.Build.App.Droid.Services
{
    public class PreferencesCredentialsService : ICredentialsService
    {
        public Task<Credentials> GetCredentialsAsync()
        {
            using (var preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                var account = preferences.GetString("account", null);
                var token = preferences.GetString("token", null);

                if (account == null || token == null)
                    return Task.FromResult(Credentials.None);

                return Task.FromResult(new Credentials(account, token));
            }
        }

        public Task StoreAsync(Credentials credentials)
        {
            using (var preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            using (var editor = preferences.Edit())
            {
                editor.PutString("account", credentials.Account);
                editor.PutString("token", credentials.Token);

                editor.Commit();
            }

            return Task.FromResult(true);
        }
    }
}