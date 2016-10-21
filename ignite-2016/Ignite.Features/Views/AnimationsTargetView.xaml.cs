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
            Wallpaper.Opacity = 1.0f;

            var service = ConnectedAnimationService.GetForCurrentView();

            var titleAnim = service.GetAnimation("Title");
            var imageAnim = service.GetAnimation("Wallpaper");

            titleAnim?.TryStart(Title);
            imageAnim?.TryStart(Wallpaper);
        }
    }
}
