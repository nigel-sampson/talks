using System;
using Android.App;
using Caliburn.Micro;
using Hubb.App.Android.Activities;
using Hubb.Core.Services;

namespace Hubb.App.Android.Services
{
    public class AppNavigationService : IAppNavigationService
    {
        private Activity currentActivity;
        private readonly ActivityLifecycleCallbackHandler lifecycleHandler = new ActivityLifecycleCallbackHandler();

        public AppNavigationService(Application application)
        {
            application.RegisterActivityLifecycleCallbacks(lifecycleHandler);

            lifecycleHandler.ActivityResumed += (s, e) => currentActivity = e.Activity;
        }

        public void ToRepositorySearch()
        {
            currentActivity.StartActivity(typeof (RepositorySearchActivity));
        }
    }
}