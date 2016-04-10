using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Common;
using Spending.Core.Services;

namespace Spending.App.Android.Services
{
    public class NotificationsService : INotificationsService
    {
        public Task InitaliseAsync()
        {
            var context = global::Android.App.Application.Context;

            var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);

            if (resultCode != ConnectionResult.Success)
                return Task.FromResult(false);

            var intent = new Intent(context, typeof(NotificationIntentService));

            context.StartService(intent);

            return Task.FromResult(true);
        }
    }
}