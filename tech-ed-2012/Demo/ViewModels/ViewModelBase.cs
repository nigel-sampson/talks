using System;
using Caliburn.Micro;

namespace Demo.ViewModels
{
    public abstract class ViewModelBase : Screen
    {
        private readonly INavigationService _navigationService;

        protected ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

        public bool CanGoBack
        {
            get
            {
                return _navigationService.CanGoBack;
            }
        }
    }
}
