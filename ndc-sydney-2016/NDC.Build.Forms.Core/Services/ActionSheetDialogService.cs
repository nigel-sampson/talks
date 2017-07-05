using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro.Xamarin.Forms;
using NDC.Build.Core.Services;

namespace NDC.Build.Forms.Core.Services
{
    public class ActionSheetDialogService : IDialogService
    {
        private readonly FormsApplication application;

        public ActionSheetDialogService(FormsApplication application)
        {
            this.application = application;
        }

        public async Task<T> ShowSelectionDialogAsync<T>(string title, string header, IEnumerable<T> options)
        {
            var optionLabels = options.ToDictionary(o => o.ToString(), o => o);

            var selectedLabel = await application.MainPage.DisplayActionSheet(title, "Cancel", null, optionLabels.Select(o => o.Key).ToArray());

            return optionLabels.ContainsKey(selectedLabel) ? optionLabels[selectedLabel] : default(T);
        }
    }
}
