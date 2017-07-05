using System;
using System.Threading.Tasks;
using NDC.Build.Core.Services;
using Xunit;

namespace NDC.Build.Tests.Core.Services
{
    [Trait("Category", "Integration")]
    public class AuthenticationServiceTests
    {
        [Fact]
        public async Task AuthenticateCredentialsAsyncWithInvalidCredentialsFalse()
        {
            var authentication = new AuthenticationService();
            var success = await authentication.AuthenticateCredentialsAsync(new Credentials("sfsfsdfsdf", "sdfopsdf"));

            Assert.False(success);
        }

        [Fact]
        public async Task AuthenticateCredentialsAsyncWithValidCredentialsTrue()
        {
            var credentialsService = new EnvironmentVariableCredentialsService();
            var credentials = await credentialsService.GetCredentialsAsync();

            var authentication = new AuthenticationService();
            var success = await authentication.AuthenticateCredentialsAsync(credentials);

            Assert.True(success);
        }
    }
}
