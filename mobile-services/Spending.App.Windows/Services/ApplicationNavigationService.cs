using System;
using Caliburn.Micro;
using Spending.Core.Services;
using Spending.Core.ViewModels;

namespace Spending.App.Windows.Services
{
    public class ApplicationNavigationService : IApplicationNavigationService
    {
        private readonly INavigationService navigation;

        public ApplicationNavigationService(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        public void ToCurrentExpenses()
        {
            navigation.For<CurrentExpensesViewModel>().Navigate();
        }

        public void ToAddExpense()
        {
            navigation.For<AddExpenseViewModel>().Navigate();
        }

        public void Back()
        {
            navigation.GoBack();
        }
    }
}
