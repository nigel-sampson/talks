using System;
using Caliburn.Micro;

namespace Demo.ViewModels
{
    public class AsyncViewModel : ViewModelBase
    {
        public AsyncViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
