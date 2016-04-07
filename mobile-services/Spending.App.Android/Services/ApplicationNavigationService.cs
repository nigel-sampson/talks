using System;
using Android.App;
using Caliburn.Micro;
using Spending.App.Android.Activities;
using Spending.Core.Services;

namespace Spending.App.Android.Services
{
    public class ApplicationNavigationService : IApplicationNavigationService
    {
        private readonly ActivityLifecycleCallbackHandler lifecycleHandler = new ActivityLifecycleCallbackHandler();
        private Activity currentActivity;

        public ApplicationNavigationService(Application application)
        {
            application.RegisterActivityLifecycleCallbacks(lifecycleHandler);

            lifecycleHandler.ActivityResumed += (s, e) => currentActivity = e.Activity;
        }

        public void ToCurrentExpenses()
        {
            currentActivity.StartActivity(typeof(CurrentExpensesActivity));
        }

        public void ToAddExpense()
        {
            currentActivity.StartActivity(typeof(AddExpenseActvity));
        }

        public void Back()
        {
            currentActivity.Finish();
        }
    }
}