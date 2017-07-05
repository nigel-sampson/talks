using System;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using NDC.Build.Core.Services;
using NDC.Build.Core.Services.NoNetwork;
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

            MessageBinder.SpecialValues.Add("$tappedItem", GetTappedItem);

            container.Instance<FormsApplication>(this);

            container
               .Singleton<ITeamServicesClient, OfflineTeamServicesClient>()
               .Singleton<IAuthenticationService, OfflineAuthenticationService>()
               .Singleton<IApplicationNavigationService, ApplicationNavigationService>()
               .Singleton<IDialogService, ActionSheetDialogService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<ProjectsViewModel>()
                .PerRequest<BuildsViewModel>();

            DisplayRootView<LoginView>();
        }

        private object GetTappedItem(ActionExecutionContext c)
        {
            var listView = (ListView) c.Source;

            var selectedItem = listView.SelectedItem;

            listView.SelectedItem = null;

            return selectedItem;
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}
