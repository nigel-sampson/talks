using System;
using Caliburn.Micro;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class CurrentExpensesViewModel : Screen
    {
        private readonly IExpenseService expenses;
        private readonly IApplicationNavigationService applicationNavigation;

        public CurrentExpensesViewModel(IExpenseService expenses, IApplicationNavigationService applicationNavigation)
        {
            this.expenses = expenses;
            this.applicationNavigation = applicationNavigation;

            ExpenseItems = new BindableCollection<ExpenseItem>();
        }

        protected async override void OnInitialize()
        {
            var expenseItems = await expenses.GetTodaysExpensesAsync();

            ExpenseItems.AddRange(expenseItems);
        }

        public void Add()
        {
            applicationNavigation.ToAddExpense();
        }

        public BindableCollection<ExpenseItem> ExpenseItems { get; }
    }
}
