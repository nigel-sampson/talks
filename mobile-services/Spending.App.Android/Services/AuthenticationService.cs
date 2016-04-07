using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.App.Android.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}