using System;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;
using NDC.Build.Forms.Core.Services;
using NDC.Build.Forms.Core.Views;
using Xamarin.Forms;

namespace NDC.Build.Forms.Core
{
    public class Application : FormsApplication
    {
        private readonly SimpleContainer container;

        public Application(SimpleContainer container)
        {
            this.container = container;

            Initialize();

            ViewModelLocator.AddNamespaceMapping("NDC.Build.Forms.Core.Views", "NDC.Build.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("NDC.Build.Core.ViewModels", "NDC.Build.Forms.Core.Views");

            container
               .Singleton<ITeamServicesClient, TeamServicesClient>()
               .Singleton<IAuthenticationService, AuthenticationService>()
               .Singleton<IApplicationNavigationService, ApplicationNavigationService>();
               //.Singleton<ICredentialsService, SettingsCredentialsService>()
               //.Singleton<IDialogService, ContentDialogService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<ProjectsViewModel>()
                .PerRequest<BuildsViewModel>();

            DisplayRootView<LoginView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}
