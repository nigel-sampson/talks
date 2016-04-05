using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spending.Core.Services
{
    public interface IExpenseService
    {
        Task<IReadOnlyCollection<ExpenseItem>> GetTodaysExpensesAsync();
        Task<ExpenseItem> CreateAsync(decimal amount);

        Task PushAsync();
        Task PullAsync();
    }
}