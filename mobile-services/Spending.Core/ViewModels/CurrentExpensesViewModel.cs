using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class CurrentExpensesViewModel : Screen
    {
        private readonly IMobileServiceClient mobileService;
        private readonly IExpenseService expenses;
        private readonly IApplicationNavigationService applicationNavigation;

        public CurrentExpensesViewModel(
            IMobileServiceClient mobileService,
            IExpenseService expenses, 
            IApplicationNavigationService applicationNavigation)
        {
            this.mobileService = mobileService;
            this.expenses = expenses;
            this.applicationNavigation = applicationNavigation;

            ExpenseItems = new BindableCollection<ExpenseItemViewModel>();
        }

        protected override async void OnActivate()
        {
            if (!mobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localstore.db");

                store.DefineTable<ExpenseItem>();

                await mobileService.SyncContext.InitializeAsync(store);
            }

            await LoadExpensesAsync();
        }

        private async Task LoadExpensesAsync()
        {
            var expenseItems = await expenses.GetTodaysExpensesAsync();

            ExpenseItems.Clear();
            ExpenseItems.AddRange(expenseItems.Select(e => new ExpenseItemViewModel(e)));
        }

        public void Add()
        {
            applicationNavigation.ToAddExpense();
        }

        public async void Push()
        {
            await expenses.PushAsync();
        }

        public async void Pull()
        {
            await expenses.PullAsync();
            await LoadExpensesAsync();
        }

        public BindableCollection<ExpenseItemViewModel> ExpenseItems { get; }
    }
}
