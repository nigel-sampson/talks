using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
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

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        public Task DeleteExpenseItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}