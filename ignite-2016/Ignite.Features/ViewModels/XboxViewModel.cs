using System;
using Windows.UI.Xaml;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class XboxViewModel : Screen
    {
        private bool enableSounds;

        public XboxViewModel()
        {
            enableSounds = ElementSoundPlayer.State == ElementSoundPlayerState.On;
        }

        public bool EnableSounds
        {
            get { return enableSounds; }
            set
            {
                enableSounds = value;
                NotifyOfPropertyChange();

                ElementSoundPlayer.State = value
                    ? ElementSoundPlayerState.On
                    : ElementSoundPlayerState.Off;
            }
        }
    }
}
