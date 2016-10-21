using System;
using Windows.System;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class LinksViewModel : Screen
    {
        public async void OpenCompiledExperience()
        {
            var uri = new Uri("http://compiledexperience.com");

            await Launcher.LaunchUriAsync(uri);
        }

        public async void OpenGoogle()
        {
            var uri = new Uri("http://google.com");

            await Launcher.LaunchUriAsync(uri);
        }
    }
}
