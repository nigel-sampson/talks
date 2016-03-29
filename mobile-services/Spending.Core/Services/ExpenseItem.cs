using System;

namespace Spending.Core.Services
{
    public class ExpenseItem
    {
        public string Id { get; set; }

        public DateTimeOffset Occurred { get; set; }

        public decimal Amount { get; set; }
    }
}
