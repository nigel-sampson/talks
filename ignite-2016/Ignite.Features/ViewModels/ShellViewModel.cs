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
                new FeatureViewModel("Feature Detection", "Detecting features & contracts", typeof(DetectionViewModel)),
                new FeatureViewModel("Media", "Animated gifs & Media Player", typeof(MediaViewModel)),
                new FeatureViewModel("Controls", "Command Bar, ComboBox", typeof(ControlsViewModel)),
                new FeatureViewModel("Background Tasks", "Single process background tasks", typeof(BackgroundTaskViewModel)),
                new FeatureViewModel("Web to app links", "Links to your website redirect to your app", typeof(LinksViewModel)),
                new FeatureViewModel("Binding & Tooling", "Compiled bindings & tooling updates", typeof(BindingViewModel)),
                new FeatureViewModel("Inking", "Ink Canvas & Toolbar", typeof(InkingViewModel)),
                new FeatureViewModel("Implict Animations", "Animatng layout changes implicitly", typeof(ImplicitAnimationsViewModel)),
                new FeatureViewModel("Connected Animations", "Batch a group of related animations", typeof(DetectionViewModel)),
                new FeatureViewModel("Effects", "Composition effects, shading & lighting", typeof(EffectsViewModel)),
                new FeatureViewModel("Xbox", "Xbox specific app features", typeof(XboxViewModel)),
                new FeatureViewModel("HoloLens", "HoloLens specific app features", typeof(HoloLensViewModel))
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
