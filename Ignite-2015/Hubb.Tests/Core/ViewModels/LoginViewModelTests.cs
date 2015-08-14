using System;
using System.Threading.Tasks;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Moq;
using Xunit;

namespace Hubb.Tests.Core.ViewModels
{
    public class LoginViewModelTests
    {
        private readonly Mock<IAppNavigationService> navigation;
        private readonly Mock<IAuthenticationService> authentication;
        private readonly LoginViewModel viewModel;

        public LoginViewModelTests()
        {
            navigation = new Mock<IAppNavigationService>();
            authentication = new Mock<IAuthenticationService>();

            viewModel = new LoginViewModel(navigation.Object, authentication.Object);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("username", "")]
        [InlineData("  ", "password")]
        public void CanLoginWithNullOrWhitespaceReturnsFalse(string username, string password)
        {
            viewModel.Username = username;
            viewModel.Password = password;

            Assert.False(viewModel.CanLogin);
        }

        [Fact]
        public async Task LoginOnSuccessNavigationsToSearch()
        {
            viewModel.Username = "username";
            viewModel.Password = "password";

            authentication.Setup(a => a.AreCredentialsValidAsync("username", "password")).ReturnsAsync(true);

            await viewModel.Login();

            navigation.Verify(n => n.ToRepositorySearch());
        }

        [Fact]
        public async Task LoginOnFailuresDoesNotNavigateToSearch()
        {
            viewModel.Username = "username";
            viewModel.Password = "password";

            authentication.Setup(a => a.AreCredentialsValidAsync("username", "password")).ReturnsAsync(false);

            await viewModel.Login();

            navigation.Verify(n => n.ToRepositorySearch(), Times.Never);
        }
    }
}
