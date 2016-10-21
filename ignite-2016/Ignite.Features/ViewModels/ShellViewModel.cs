using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Caliburn.Micro;
using Ignite.Features.Messages;

namespace Ignite.Features.ViewModels
{
    public class ShellViewModel : Screen, IHandle<ProtocolMessage>
    {
        private readonly WinRTContainer container;
        private INavigationService navigationService;

        public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;

            eventAggregator.Subscribe(this);
            
            Features = new BindableCollection<FeatureViewModel>
            {
                new FeatureViewModel("Feature Detection", "Detecting features & contracts", typeof(DetectionViewModel)),
                new FeatureViewModel("Media", "Animated gifs & Media Player", typeof(MediaViewModel)),
                new FeatureViewModel("Controls", "Command Bar, ComboBox", typeof(ControlsViewModel)),
                new FeatureViewModel("Background Tasks", "Single process background tasks", typeof(BackgroundTaskViewModel)),
                new FeatureViewModel("Web to app links", "Links to your website redirect to your app", typeof(LinksViewModel)),
                new FeatureViewModel("Binding & Tooling", "Compiled bindings & tooling updates", typeof(BindingViewModel)),
                new FeatureViewModel("Inking", "Ink Canvas & Toolbar", typeof(InkingViewModel)),
                new FeatureViewModel("Connected Animations", "Batch a group of related animations", typeof(ConnectedAnimationsViewModel)),
                new FeatureViewModel("Effects", "Composition effects, shading & lighting", typeof(EffectsViewModel)),
                new FeatureViewModel("Implict Animations", "Animatng layout changes implicitly", typeof(ImplicitAnimationsViewModel)),
                new FeatureViewModel("Xbox", "Additionss to UWP to make Xbox One apps easier", typeof(XboxViewModel)),
                new FeatureViewModel("HoloLens", "Building 2D apps on HoloLens", typeof(HoloLensViewModel))
            };
        }

        public void SetupNavigationService(Frame frame)
        {
            navigationService = container.RegisterNavigationService(frame);
            navigationService.Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            var navView = SystemNavigationManager.GetForCurrentView();

            navView.AppViewBackButtonVisibility = navigationService.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }

        public void FeatureSelected(FeatureViewModel feature)
        {
            navigationService.NavigateToViewModel(feature.ViewModel);
        }

        public BindableCollection<FeatureViewModel> Features { get; }

        public void Handle(ProtocolMessage message)
        {
            navigationService.For<WebsiteViewModel>().Navigate();
        }
    }
}
