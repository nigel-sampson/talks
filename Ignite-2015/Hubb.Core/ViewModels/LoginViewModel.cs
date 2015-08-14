using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hubb.Core.Services;
using PropertyChanged;
using static System.String;

namespace Hubb.Core.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IAppNavigationService navigation;
        private readonly IAuthenticationService authentication;

        public LoginViewModel(IAppNavigationService navigation, IAuthenticationService authentication)
        {
            this.navigation = navigation;
            this.authentication = authentication;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        [DependsOn(nameof(Username), nameof(Password))]
        public bool CanLogin => !IsNullOrWhiteSpace(Username) && !IsNullOrWhiteSpace(Password);

        public string Message { get; set; }

        public async Task Login()
        {
            var valid = await authentication.AreCredentialsValidAsync(Username, Password);

            if (!valid)
            {
                Message = "Could not log you in to GitHub.";

                return;
            }

            navigation.ToRepositorySearch();
        }
    }
}
