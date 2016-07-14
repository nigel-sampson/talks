using System;
using Caliburn.Micro;
using NDC.Build.Core.Services;
using PropertyChanged;

namespace NDC.Build.Core.ViewModels
{
    public class LegacyLoginViewModel : Screen
    {
        private readonly ICredentialsService credentials;
        private readonly IAuthenticationService authentication;
        private readonly IApplicationNavigationService navigation;

        private string account;
        private string token;
        private string message;

        public LegacyLoginViewModel(ICredentialsService credentials, IAuthenticationService authentication, IApplicationNavigationService navigation)
        {
            this.credentials = credentials;
            this.authentication = authentication;
            this.navigation = navigation;
        }

        protected override async void OnInitialize()
        {
            var stored = await credentials.GetCredentialsAsync();

            if (stored == Credentials.None)
                return;

            Account = stored.Account;
            Token = stored.Token;
        }

        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                NotifyOfPropertyChange(() => Account);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Token
        {
            get { return token; }
            set
            {
                token = value;
                NotifyOfPropertyChange(() => Token);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Message
        {
            get { return message; }
            private set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public bool CanLogin
        {
            get { return !String.IsNullOrEmpty(Account) && !String.IsNullOrEmpty(Token); }
        }

        public async void Login()
        {
            var entered = new Credentials(Account, Token);
            var authenticated = await authentication.AuthenticateCredentialsAsync(entered);

            if (!authenticated)
            {
                Message = "Account / Token is incorrect";
            }
            else
            {
                await credentials.StoreAsync(entered);

                navigation.ToProjects();
            }
        }
    }
}
