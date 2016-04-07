using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.App.Android.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ActivityLifecycleCallbackHandler lifecycleHandler = new ActivityLifecycleCallbackHandler();
        private readonly IMobileServiceClient mobileService;
        private Activity currentActivity;

        public AuthenticationService(IMobileServiceClient mobileService, Application application)
        {
            this.mobileService = mobileService;

            application.RegisterActivityLifecycleCallbacks(lifecycleHandler);

            lifecycleHandler.ActivityResumed += (s, e) => currentActivity = e.Activity;
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await mobileService.LoginAsync(currentActivity, provider);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}