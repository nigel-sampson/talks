using Caliburn.Micro.Xamarin.Forms;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;

namespace Hubb.Forms.Core.Services
{
    public class AppNavigationService : IAppNavigationService
    {
        private readonly INavigationService navigation;

        public AppNavigationService(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        public void ToRepositorySearch()
        {
            navigation.For<RepositorySearchViewModel>().Navigate();
        }
    }
}
