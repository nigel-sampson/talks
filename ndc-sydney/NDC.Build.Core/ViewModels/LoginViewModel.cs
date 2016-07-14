using System;
using Caliburn.Micro;
using NDC.Build.Core.Services;
using PropertyChanged;
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
            {
                Account = "caliburn-micro";
                Token = "hk46cpx6i7brnyixjptrz3w77z7dke3vetexcxcqsq6h6ugthuxa";

                return;
            }
                

            Account = stored.Account;
            Token = stored.Token;
        }

        public string Account { get; set; }

        public string Token { get; set; }

        public string Message { get; private set; }

        [DependsOn(nameof(Account), nameof(Token))]
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
