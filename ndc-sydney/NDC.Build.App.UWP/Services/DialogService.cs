using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using NDC.Build.App.UWP.ViewModels;
using NDC.Build.Core.Services;

namespace NDC.Build.App.UWP.Services
{
    public class DialogService : IDialogService
    {
        public async Task<T> ShowSelectionDialogAsync<T>(string title, string jeader, IEnumerable<T> options)
        {
            var viewModel = new SelectionDialogViewModel<T>(jeader, options);
            var view = ViewLocator.LocateForModel(viewModel, null, null);

            ViewModelBinder.Bind(viewModel, view, null);

            var dialog = new ContentDialog
            {
                Content = view,
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "Ok",
                IsSecondaryButtonEnabled = true,
                SecondaryButtonText = "Cancel",
                Title = title
            };

            var result = await dialog.ShowAsync();

            return result == ContentDialogResult.Primary ? viewModel.SelectedOption : default(T);
        }
    }
}
