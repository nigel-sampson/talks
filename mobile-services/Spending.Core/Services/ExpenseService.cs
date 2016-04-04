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
            var midnight = new DateTimeOffset(DateTime.Today, DateTimeOffset.Now.Offset);

            var expenses = await table.Where(e => e.Occurred >= midnight).ToListAsync();

            return expenses.ToArray();
        }

        public async Task<ExpenseItem> CreateAsync(decimal amount)
        {
            var expenseItem = new ExpenseItem
            {
                Amount = amount,
                Occurred = DateTimeOffset.UtcNow
            };

            await table.InsertAsync(expenseItem);

            return expenseItem;
        }
    }
}
