using Caliburn.Micro;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;

namespace Hubb.App.UWP.Services
{
    public class AppNavigationService : IAppNavigationService
    {
        private readonly INavigationService navigationService;

        public AppNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void ToRepositorySearch()
        {
            navigationService.For<RepositorySearchViewModel>().Navigate();
        }
    }
}
