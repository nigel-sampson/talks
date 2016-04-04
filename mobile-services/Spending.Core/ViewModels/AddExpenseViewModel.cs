using System;
using System.Globalization;
using Caliburn.Micro;
using PropertyChanged;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class AddExpenseViewModel : Screen
    {
        private readonly IExpenseService expenses;
        private readonly IApplicationNavigationService applicationNavigation;

        public AddExpenseViewModel(IExpenseService expenses, IApplicationNavigationService applicationNavigation)
        {
            this.expenses = expenses;
            this.applicationNavigation = applicationNavigation;
        }

        public string Text { get; set; }

        [DependsOn(nameof(Text))]
        public bool CanSave
        {
            get
            {
                decimal output;

                return Decimal.TryParse(Text, NumberStyles.Any, CultureInfo.CurrentUICulture, out output);
            }
        }

        public async void Save()
        {
            decimal amount;

            if (!Decimal.TryParse(Text, NumberStyles.Any, CultureInfo.CurrentUICulture, out amount))
                return;

            await expenses.CreateAsync(amount);

            applicationNavigation.Back();
        }
    }
}
