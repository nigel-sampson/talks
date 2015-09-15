using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Hubb.Forms.Core.Services;
using Hubb.Forms.Core.Views;
using Octokit;
using Xamarin.Forms;

namespace Hubb.Forms.Core
{
    public class Application : FormsApplication
    {
        private readonly SimpleContainer container;

        public Application(SimpleContainer container)
        {
            this.container = container;

            ConventionManager.AddElementConvention<SearchBar>(SearchBar.TextProperty, "Text", "SearchButtonPressed");

            ViewModelLocator.AddNamespaceMapping("Hubb.Forms.Core.Views", "Hubb.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Hubb.Core.ViewModels", "Hubb.Forms.Core.Views");

            Initialize();

            container
                .Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("hubb-forms", "1.0.0")));

            container
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IRepositoryService, RepositoryService>()
                .Singleton<IAppNavigationService, AppNavigationService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<RepositorySearchViewModel>();

            DisplayRootView<LoginView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}
