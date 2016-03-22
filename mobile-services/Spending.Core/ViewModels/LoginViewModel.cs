using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IAuthenticationService authentication;
        private readonly IApplicationNavigationService applicationNavigation;

        public LoginViewModel(IAuthenticationService authentication, IApplicationNavigationService applicationNavigation)
        {
            this.authentication = authentication;
            this.applicationNavigation = applicationNavigation;
        }

        public async void LoginWithMicrosoftAccount() => await LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);

        public async void LoginWithActiveDirectory() => await LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
        
        private async Task LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            var user = await authentication.LoginAsync(provider);

            if (user == null)
            {

            }
            else
            {
                applicationNavigation.ToCurrentExpenses();
            }
        }
    }
}
