using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using NDC.Build.App.UWP.Services;
using NDC.Build.App.UWP.Views;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.UWP
{
    public sealed partial class App
    {
        private WinRTContainer container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            ViewModelLocator.AddNamespaceMapping("NDC.Build.App.UWP.Views", "NDC.Build.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("NDC.Build.Core.ViewModels", "NDC.Build.App.UWP.Views");

            container = new WinRTContainer();

            container.RegisterWinRTServices();

            container
                .Singleton<ITeamServicesClient, TeamServicesClient>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IApplicationNavigationService, ApplicationNavigationService>()
                .Singleton<ICredentialsService, SettingsCredentialsService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<ProjectsViewModel>()
                .PerRequest<BuildsViewModel>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<LoginView>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(App).GetTypeInfo().Assembly;
            yield return typeof(LoginViewModel).GetTypeInfo().Assembly;
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
