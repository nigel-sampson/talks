using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Spending.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMobileServiceClient mobileService;
        private readonly IMobileServiceSyncTable<ExpenseItem> table;

        public ExpenseService(IMobileServiceClient mobileService)
        {
            this.mobileService = mobileService;
            table = mobileService.GetSyncTable<ExpenseItem>();
        }

        public async Task InitaliseAsync()
        {
            if (mobileService.SyncContext.IsInitialized)
                return;
            
            var store = new MobileServiceSQLiteStore("localstore.db");

            store.DefineTable<ExpenseItem>();

            await mobileService.SyncContext.InitializeAsync(store);
        }

        public async Task<IReadOnlyCollection<ExpenseItem>> GetTodaysExpensesAsync()
        {
            var limit = DateTimeOffset.UtcNow.AddHours(-24);

            var expenses = await table
                .Where(e => e.Occurred >= limit)
                .OrderByDescending(e => e.Occurred)
                .ToListAsync();

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

        public Task PushAsync()
        {
            return mobileService.SyncContext.PushAsync();
        }

        public Task PullAsync()
        {
            return table.PullAsync("expenses", table.CreateQuery());
        }
    }
}
