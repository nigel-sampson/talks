using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.App.Windows.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMobileServiceClient mobileService;

        public AuthenticationService(IMobileServiceClient mobileService)
        {
            this.mobileService = mobileService;
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await mobileService.LoginAsync(provider);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
