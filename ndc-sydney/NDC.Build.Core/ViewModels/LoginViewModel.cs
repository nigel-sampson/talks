using System;
using Caliburn.Micro;
using NDC.Build.Core.Services;
using static System.String;

namespace NDC.Build.Core.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly ICredentialsService credentials;
        private readonly IAuthenticationService authentication;
        private readonly IApplicationNavigationService navigation;

        public LoginViewModel(ICredentialsService credentials, IAuthenticationService authentication, IApplicationNavigationService navigation)
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

        public string Account { get; set; }

        public string Token { get; set; }

        public string Message { get; private set; }

        public bool CanLogin => !IsNullOrEmpty(Account) && !IsNullOrEmpty(Token);

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
