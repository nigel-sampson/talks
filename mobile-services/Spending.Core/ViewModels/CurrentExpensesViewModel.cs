using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class CurrentExpensesViewModel : Screen
    {
        private readonly IExpenseService expenses;
        private readonly IApplicationNavigationService applicationNavigation;
        private readonly INotificationsService notifications;

        public CurrentExpensesViewModel(
            IExpenseService expenses, 
            IApplicationNavigationService applicationNavigation,
            INotificationsService notifications)
        {
            this.expenses = expenses;
            this.applicationNavigation = applicationNavigation;
            this.notifications = notifications;

            ExpenseItems = new BindableCollection<ExpenseItemViewModel>();
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            await notifications.InitaliseAsync();
        }

        protected override async void OnActivate()
        {
            await expenses.InitaliseAsync();

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
