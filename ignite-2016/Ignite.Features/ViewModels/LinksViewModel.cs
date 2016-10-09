using System;
using Windows.System;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class LinksViewModel : Screen
    {
        public async void Open()
        {
            var uri = new Uri("http://compiledexperience.com");

            await Launcher.LaunchUriAsync(uri);
        }
    }
}
