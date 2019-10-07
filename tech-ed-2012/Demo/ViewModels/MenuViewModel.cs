using System;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace Demo.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.navigationService = navigationService;

            Samples = new BindableCollection<SampleViewModel>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Samples.Add(new SampleViewModel { Title = "Store Style Grid", Subtitle = "Using VariableSizedWrapGrid to build a Store style Grid.", ViewModelType = typeof(StoreViewModel) });
            Samples.Add(new SampleViewModel { Title = "Semantic Zoom", Subtitle = "Tips and tricks for the Semantic Zoom control.", ViewModelType = typeof(SemanticZoomViewModel) });
            Samples.Add(new SampleViewModel { Title = "Async Errors", Subtitle = "Strategies to handle errors in async.", ViewModelType = typeof(AsyncViewModel) });
            Samples.Add(new SampleViewModel { Title = "Themed Controls", Subtitle = "Overriding the default purple.", ViewModelType = typeof(ThemeViewModel) });
        }

        public void SampleSelected(ItemClickEventArgs eventArgs)
        {
            var sample = (SampleViewModel)eventArgs.ClickedItem;

            navigationService.NavigateToViewModel(sample.ViewModelType);
        }

        public BindableCollection<SampleViewModel> Samples
        {
            get;
            private set;
        }
    }
}
