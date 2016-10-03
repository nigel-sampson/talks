using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Navigation;

namespace Ignite.Features.Views
{
    public sealed partial class MediaView
    {
        private MediaPlayer mediaPlayer;

        public MediaView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            mediaPlayer = new MediaPlayer();
            
            MediaElement.SetMediaPlayer(mediaPlayer);

            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///assets/big_buck_bunny.mp4"));
        }
    }
}
