using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using NDC.Build.Core.Services;

namespace NDC.Build.App.Droid.Services
{
    public class AlertDialogService : ActivityAwareService, IDialogService
    {
        public AlertDialogService(Application application)
            : base(application)
        {
            
        }

        public Task<T> ShowSelectionDialogAsync<T>(string title, string header, IEnumerable<T> options)
        {
            var taskSource = new TaskCompletionSource<T>();
            var optionsList = options.ToList();

            var builder = new AlertDialog.Builder(CurrentActivity)
                .SetCancelable(true)
                .SetTitle(title)
                .SetNegativeButton("Cancel", (s, e) => taskSource.SetResult(default(T)))
                .SetItems(optionsList.Select(o => o.ToString()).ToArray(), (s, e) => {  taskSource.SetResult(optionsList[e.Which]); });

            builder.Create().Show();

            return taskSource.Task;
        }
    }
}