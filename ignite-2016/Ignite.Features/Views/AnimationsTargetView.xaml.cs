using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Ignite.Features.Views
{
    public sealed partial class AnimationsTargetView
    {
        public AnimationsTargetView()
        {
            InitializeComponent();
        }

        private void OnImageOpened(object sender, RoutedEventArgs e)
        {
            var service = ConnectedAnimationService.GetForCurrentView();

            var anim = service.GetAnimation("Anim");
            Wallpaper.Opacity = 1.0f;
            anim?.TryStart(Wallpaper);
        }
    }
}
