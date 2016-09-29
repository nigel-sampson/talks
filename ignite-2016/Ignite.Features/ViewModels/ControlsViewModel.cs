using System;
using System.Linq;
using Windows.UI.Popups;
using Caliburn.Micro;
using Humanizer;

namespace Ignite.Features.ViewModels
{
    public class ControlsViewModel : Screen
    {
        public ControlsViewModel()
        {
            Numbers = new BindableCollection<string>(
                Enumerable.Range(0, 30).Select(i => i.ToWords()));    
        }

        public async void Open()
        {
            var dialog = new MessageDialog("File opened.", "Opened");

            await dialog.ShowAsync();
        }

        public BindableCollection<string> Numbers { get; } 
    }
}
