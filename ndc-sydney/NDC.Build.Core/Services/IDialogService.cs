using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NDC.Build.Core.Services
{
    public interface IDialogService
    {
        Task<T> ShowSelectionDialogAsync<T>(string title, string jeader, IEnumerable<T> options);
    }
}
