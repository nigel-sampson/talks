using System;

namespace Spending.Core.Services
{
    public interface IApplicationNavigationService
    {
        void ToCurrentExpenses();
        void ToAddExpense();
        void Back();
    }
}
