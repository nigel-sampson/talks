using System;
using System.Threading.Tasks;
using NDC.Build.Core.Services;

namespace NDC.Build.Tests.Core.Services
{
    public class EnvironmentVariableCredentialsService : ICredentialsService
    {
        public Task<Credentials> GetCredentialsAsync()
        {
            var account = Environment.GetEnvironmentVariable("NDC.Build.Account");
            var token = Environment.GetEnvironmentVariable("NDC.Build.Token");

            if (String.IsNullOrEmpty(account))
                throw new InvalidOperationException("Missing account name in environment variable NDC.Build.Account");

            if (String.IsNullOrEmpty(token))
                throw new InvalidOperationException("Missing PAT token in environment variable NDC.Build.Token");

            return Task.FromResult(new Credentials(account, token));
        }

        public Task StoreAsync(Credentials credentials)
        {
            throw new NotSupportedException();
        }
    }
}
