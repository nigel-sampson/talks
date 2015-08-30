using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hubb.Core.Services;

namespace Hubb.Core.ViewModels
{
    public class FodyLoginViewModel : Screen
    {
        private readonly IAppNavigationService navigation;
        private readonly IAuthenticationService authentication;

        private string username;
        private string password;
        private string message;

        public FodyLoginViewModel(IAppNavigationService navigation, IAuthenticationService authentication)
        {
            this.navigation = navigation;
            this.authentication = authentication;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => Password);
            }
        }

        public bool CanLogin
        {
            get { return !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password); }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyOfPropertyChange(nameof(Message));
            }
        }

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
