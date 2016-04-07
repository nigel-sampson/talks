using System;
using System.Threading.Tasks;
using Spending.Core.Services;

namespace Spending.App.Android.Services
{
    public class NotificationsService : INotificationsService
    {
        public Task InitaliseAsync()
        {
            return Task.FromResult(true);
        }
    }
}