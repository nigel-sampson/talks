using System;
using System.Globalization;
using Caliburn.Micro;
using Spending.Core.Services;

namespace Spending.Core.ViewModels
{
    public class ExpenseItemViewModel : PropertyChangedBase
    {
        public ExpenseItemViewModel(ExpenseItem expense)
        {
            Amount = expense.Amount.ToString("C");
            Occurred = expense.Occurred.ToLocalTime().ToString("f");
        }

        public string Amount { get; }
        public string Occurred { get; }
    }
}
