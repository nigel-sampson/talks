using Caliburn.Micro;
using Demo.Core.Services;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class SettingsViewModel : Screen
    {
        private readonly ISettingsService settings;

        public SettingsViewModel(ISettingsService settings)
        {
            this.settings = settings;
        }

        protected override void OnInitialize()
        {
            var credentials = settings.GetCredentials();

            Login = credentials.Login;
            Password = credentials.Password;
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public void Save()
        {
            settings.SetCredentials(new Credentials(Login, Password));
        }
    }
}
