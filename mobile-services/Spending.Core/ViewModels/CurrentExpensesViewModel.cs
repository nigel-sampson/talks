using System;
using System.Linq;
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

            ExpenseItems = new BindableCollection<ExpenseItemViewModel>();
        }

        protected override async void OnActivate()
        {
            var expenseItems = await expenses.GetTodaysExpensesAsync();

            ExpenseItems.Clear();
            ExpenseItems.AddRange(expenseItems.Select(e => new ExpenseItemViewModel(e)));
        }

        public void Add()
        {
            applicationNavigation.ToAddExpense();
        }

        public BindableCollection<ExpenseItemViewModel> ExpenseItems { get; }
    }
}
