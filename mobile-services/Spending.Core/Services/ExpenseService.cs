using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Spending.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMobileServiceTable<ExpenseItem> table;

        public ExpenseService(IMobileServiceClient mobileService)
        {
            table = mobileService.GetTable<ExpenseItem>();
        }

        public async Task<IReadOnlyCollection<ExpenseItem>> GetTodaysExpensesAsync()
        {
            var limit = DateTimeOffset.Now.AddHours(-24);

            var expenses = await table.Where(e => e.Occurred >= limit).ToListAsync();

            return expenses.ToArray();
        }
    }
}
