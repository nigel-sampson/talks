using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Gcm.Iid;
using Android.Util;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;

namespace Spending.App.Android.Services
{
    [Service(Exported = false)]
    public class NotificationIntentService : IntentService
    {
        public NotificationIntentService()
            : base("NotificationIntentService")
        {

        }

        protected override async void OnHandleIntent(Intent intent)
        {
            try
            {
                var mobileService = IoC.Get<IMobileServiceClient>();

                Log.Info("NotificationIntentService", "Calling InstanceID.GetToken");

                var instanceId = InstanceID.GetInstance(this);

                var token = instanceId.GetToken("170537756983", GoogleCloudMessaging.InstanceIdScope, null);

                Log.Info("NotificationIntentService", "GCM Registration Token: " + token);

                await mobileService.GetPush().RegisterAsync(token);

                Subscribe(token);

            }
            catch (Exception e)
            {
                Log.Debug("NotificationIntentService", "Failed to get a registration token");
            }
        }


        private void Subscribe(string token)
        {
            var pubSub = GcmPubSub.GetInstance(this);

            pubSub.Subscribe(token, "/topics/global", null);
        }
    }
}