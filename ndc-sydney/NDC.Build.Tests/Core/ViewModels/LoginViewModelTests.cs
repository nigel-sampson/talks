using System;
using Caliburn.Micro;
using Moq;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;
using Xunit;

namespace NDC.Build.Tests.Core.ViewModels
{
    public class LoginViewModelTests
    {
        private readonly Mock<ICredentialsService> credentials;
        private readonly Mock<IAuthenticationService> authentication;
        private readonly Mock<IApplicationNavigationService> navigation;

        private LoginViewModel loginViewModel;

        public LoginViewModelTests()
        {
            credentials = new Mock<ICredentialsService>();
            authentication = new Mock<IAuthenticationService>();
            navigation = new Mock<IApplicationNavigationService>();

            loginViewModel = new LoginViewModel(credentials.Object, authentication.Object, navigation.Object);
        }

        [Theory]
        [InlineData(null, null, false)]
        [InlineData("", "", false)]
        [InlineData("account", "", false)]
        [InlineData("", "token", false)]
        [InlineData("account", "token", true)]
        public void CanLoginTheory(string account, string token, bool expected)
        {
            loginViewModel.Account = account;
            loginViewModel.Token = token;

            Assert.Equal(expected, loginViewModel.CanLogin);
        }

        [Fact]
        public void OnInitializeLoadsCredentials()
        {
            credentials.Setup(c => c.GetCredentialsAsync()).ReturnsAsync(new Credentials("acc", "tok"));

            ScreenExtensions.TryActivate(loginViewModel);

            Assert.Equal("acc", loginViewModel.Account);
            Assert.Equal("tok", loginViewModel.Token);
        }

        [Fact]
        public void LoginWithSuccessfulAuthenticationNavigatesToProjects()
        {
            authentication.Setup(a => a.AuthenticateCredentialsAsync(It.IsAny<Credentials>())).ReturnsAsync(true);

            loginViewModel.Login();

            navigation.Verify(n => n.ToProjects());
        }

        [Fact]
        public void LoginWithAuthenticationFailureDoesNotNavigateToProjects()
        {
            authentication.Setup(a => a.AuthenticateCredentialsAsync(It.IsAny<Credentials>())).ReturnsAsync(false);

            loginViewModel.Login();

            navigation.Verify(n => n.ToProjects(), Times.Never);
        }
    }
}
