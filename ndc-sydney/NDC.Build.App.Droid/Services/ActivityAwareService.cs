using System;
using Android.App;
using Caliburn.Micro;

namespace NDC.Build.App.Droid.Services
{
    public abstract class ActivityAwareService
    {
        private readonly ActivityLifecycleCallbackHandler lifecycleHandler = new ActivityLifecycleCallbackHandler();

        protected ActivityAwareService(Application application)
        {
            lifecycleHandler.ActivityResumed += (s, e) => CurrentActivity = e.Activity;

            application.RegisterActivityLifecycleCallbacks(lifecycleHandler);
        }

        protected Activity CurrentActivity { get; private set; }
    }
}