using System;
using System.Globalization;
using Caliburn.Micro;

namespace Spending.Core.ViewModels
{
    public class AddExpenseViewModel : Screen
    {
        public string Text { get; set; }

        public bool CanAdd
        {
            get
            {
                decimal output;

                return Decimal.TryParse(Text, NumberStyles.Any, CultureInfo.CurrentUICulture, out output);
            }
        }

        public void Add()
        {
            
        }
    }
}
