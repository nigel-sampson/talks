using System;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class ConnectedAnimationsViewModel : Screen
    {
        private readonly INavigationService navigationService;

        public ConnectedAnimationsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void GoToTarget()
        {
            navigationService
                .For<AnimationsTargetViewModel>()
                .Navigate();
        }
    }
}
