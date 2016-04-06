using System;
using Microsoft.WindowsAzure.MobileServices;
using Moq;
using Spending.Core.Services;
using Spending.Core.ViewModels;
using Xunit;

namespace Spending.Tests.Core.ViewModels
{
    public class LoginViewModelTests
    {
        private readonly Mock<IAuthenticationService> authentication;
        private readonly Mock<IApplicationNavigationService> applicationNavigation;
        private readonly LoginViewModel viewModel;

        public LoginViewModelTests()
        {
            authentication = new Mock<IAuthenticationService>();
            applicationNavigation = new Mock<IApplicationNavigationService>();

            viewModel = new LoginViewModel(authentication.Object, applicationNavigation.Object);
        }

        [Fact]
        public void LoginSuccessNavigatesCurrentExpenses()
        {
            authentication
                .Setup(a => a.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount))
                .ReturnsAsync(new MobileServiceUser("42"));

            viewModel.LoginWithMicrosoftAccount();

            applicationNavigation.Verify(n => n.ToCurrentExpenses());
        }
    }
}
