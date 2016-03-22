using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Spending.Core.Services
{
    public interface IAuthenticationService
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);
    }
}
