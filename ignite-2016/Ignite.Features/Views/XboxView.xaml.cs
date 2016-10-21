using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Ignite.Features.Views
{
    public sealed partial class XboxView
    {
        public XboxView()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
        }
    }
}
