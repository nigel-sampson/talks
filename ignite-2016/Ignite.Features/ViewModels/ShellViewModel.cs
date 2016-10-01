using System;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly WinRTContainer container;
        private INavigationService navigationService;

        public ShellViewModel(WinRTContainer container)
        {
            this.container = container;
            Features = new BindableCollection<FeatureViewModel>
            {
                // Feature detection
                new FeatureViewModel("Media", "Animated gifs & Media Player", typeof(MediaViewModel)),
                new FeatureViewModel("Controls", "Command Bar, ComboBox & Tree View", typeof(ControlsViewModel))
                // Single process task
                // Web to app linking
                // Binding // Tooling
                // Inking
                // Implicit animations
                // Connected animations
                // Effects
                // Connected Apps ?
                // Xbox
                // HoloLens
            };
        }

        public void SetupNavigationService(Frame frame)
        {
            navigationService = container.RegisterNavigationService(frame);
        }

        public void FeatureSelected(FeatureViewModel feature)
        {
            navigationService.NavigateToViewModel(feature.ViewModel);
        }

        public BindableCollection<FeatureViewModel> Features { get; } 
    }
}
