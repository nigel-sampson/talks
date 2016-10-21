using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Ignite.Features.ViewModels;

namespace Ignite.Features.Views
{
    public sealed partial class ConnectedAnimationsView
    {
        public ConnectedAnimationsView()
        {
            InitializeComponent();
        }

        private ConnectedAnimationsViewModel ViewModel => (ConnectedAnimationsViewModel) DataContext;

        private void OnNavigate(object sender, RoutedEventArgs e)
        {
            var service = ConnectedAnimationService.GetForCurrentView();

            service.PrepareToAnimate("Wallpaper", Wallpaper);
            service.PrepareToAnimate("Title", Title);

            ViewModel.GoToTarget();
        }
    }
}
