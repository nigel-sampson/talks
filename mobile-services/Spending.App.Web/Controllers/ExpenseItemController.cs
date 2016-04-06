using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.NotificationHubs;
using Spending.App.Web.DataObjects;
using Spending.App.Web.Models;

namespace Spending.App.Web.Controllers
{
    public class ExpenseItemController : TableController<ExpenseItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            var context = new MobileServiceContext();

            DomainManager = new EntityDomainManager<ExpenseItem>(context, Request);
        }
        public IQueryable<ExpenseItem> GetAllExpenseItems()
        {
            return Query();
        }

        public SingleResult<ExpenseItem> GetExpenseItem(string id)
        {
            return Lookup(id);
        }

        public Task<ExpenseItem> PatchExpenseItem(string id, Delta<ExpenseItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        public async Task<IHttpActionResult> PostExpenseItem(ExpenseItem item)
        {
            var current = await InsertAsync(item);

            if (item.Amount > 100.0m)
                await SendBigSpenderNotificationAsync();

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        public Task DeleteExpenseItem(string id)
        {
            return DeleteAsync(id);
        }


        private async Task SendBigSpenderNotificationAsync()
        {
            var settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            var hubName = settings.NotificationHubName;
            var hubConnection = settings.Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;

            var hub = NotificationHubClient.CreateClientFromConnectionString(hubConnection, hubName);

            var windowsToastPayload = @"<toast><visual><binding template=""ToastText01""><text id=""1"">We've got a big spender here!</text></binding></visual></toast>";

            try
            {
                var result = await hub.SendWindowsNativeNotificationAsync(windowsToastPayload);

                Configuration.Services.GetTraceWriter().Info(result.State.ToString());
            }
            catch (Exception ex)
            {
                Configuration.Services.GetTraceWriter().Error(ex.Message);
            }
        }
    }
}