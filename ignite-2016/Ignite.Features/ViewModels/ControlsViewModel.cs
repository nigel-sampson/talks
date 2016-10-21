using System;
using System.Linq;
using System.Reactive.Linq;
using Windows.UI.Popups;
using Caliburn.Micro;
using Humanizer;

namespace Ignite.Features.ViewModels
{
    public class ControlsViewModel : Screen
    {
        private IDisposable subscription;

        public ControlsViewModel()
        {
            Numbers = new BindableCollection<string>(
                Enumerable.Range(0, 30).Select(i => i.ToWords()));    
            SelectedNumbers = new BindableCollection<string>();
        }

        protected override void OnActivate()
        {
            subscription = Observable.Interval(TimeSpan.FromSeconds(3))
                .Subscribe(_ => SelectedNumbers.Add(Constants.GetLipsum()));
        }

        protected override void OnDeactivate(bool close)
        {
            subscription.Dispose();
        }

        public async void Open()
        {
            var dialog = new MessageDialog(Constants.Lipsum, "Opened");

            await dialog.ShowAsync();
        }

        public BindableCollection<string> Numbers { get; } 

        public BindableCollection<string> SelectedNumbers { get; }
    }
}
