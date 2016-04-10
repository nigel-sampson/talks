using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.OS;
using Android.Util;
using Spending.App.Android.Activities;

namespace Spending.App.Android.Services
{
    [Service(Exported = false)]
    [IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
    public class NotificationListenerService : GcmListenerService
    {
        public override void OnMessageReceived(string from, Bundle data)
        {
            var message = data.GetString("message");

            Log.Debug("MyGcmListenerService", "From:    " + from);
            Log.Debug("MyGcmListenerService", "Message: " + message);

            SendNotification(message);
        }

        private void SendNotification(string message)
        {
            var intent = new Intent(this, typeof(CurrentExpensesActivity));

            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(this)
                //.SetSmallIcon(Resource.Drawable.ic_)
                .SetContentTitle("GCM Message")
                .SetContentText(message)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}