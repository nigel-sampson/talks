using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm.Iid;

namespace Spending.App.Android.Services
{
    [Service(Exported = false)]
    [IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" })]
    public class NotificationInstanceIdListenerService : InstanceIDListenerService
    {
        public override void OnTokenRefresh()
        {
            var intent = new Intent(this, typeof(NotificationIntentService));

            StartService(intent);
        }
    }
}