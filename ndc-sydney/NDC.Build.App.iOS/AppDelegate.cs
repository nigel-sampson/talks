using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using Caliburn.Micro;
using Foundation;
using NDC.Build.App.iOS.Services;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;
using UIKit;

namespace NDC.Build.App.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : CaliburnApplicationDelegate
    {
        private SimpleContainer container;

        public override UIWindow Window
        {
            get;
            set;
        }

        protected override void Configure()
        {
            ViewModelLocator.AddNamespaceMapping("NDC.Build.App.iOS", "NDC.Build.Core.ViewModels");

            container = new SimpleContainer();

            container.Instance(this);

            container
                .Singleton<ITeamServicesClient, TeamServicesClient>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IApplicationNavigationService, StoryboardNavigationService>()
                .Singleton<ICredentialsService, UserDefaultsCredentialsService>()
                .Singleton<IDialogService, ActionSheetDialogService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<ProjectsViewModel>()
                .PerRequest<BuildsViewModel>();
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof (LoginViewController).Assembly;
            yield return typeof (LoginViewModel).Assembly;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Initialize();

            return true;
        }
    }
}


