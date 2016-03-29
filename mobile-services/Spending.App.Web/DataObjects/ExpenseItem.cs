using System;
using Microsoft.Azure.Mobile.Server;

namespace Spending.App.Web.DataObjects
{
    public class ExpenseItem : EntityData
    {
        public DateTimeOffset Occurred { get; set; }

        public decimal Amount { get; set; }
    }
}