using System;
using System.Threading.Tasks;
using Windows.Networking.PushNotifications;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.App.Windows.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly IMobileServiceClient mobileService;

        public NotificationsService(IMobileServiceClient mobileService)
        {
            this.mobileService = mobileService;
        }

        public async Task InitaliseAsync()
        {
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            await mobileService.GetPush().RegisterAsync(channel.Uri);
        }
    }
}
