using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Hubb.Native.App.UWP.Services;
using Hubb.Native.App.UWP.Views;
using Octokit;

namespace Hubb.Native.App.UWP
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
            ViewModelLocator.AddNamespaceMapping("Hubb.Native.App.UWP.Views", "Hubb.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Hubb.Core.ViewModels", "Hubb.Native.App.UWP.Views");

            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container.Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("hubb-uwp", "1.0.0")));

            container
                .Singleton<IAppNavigationService, AppNavigationService>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IRepositoryService, RepositoryService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<RepositorySearchViewModel>();

            Coroutine.Completed += (s, e) =>
            {
                if (e.Error == null)
                    return;

                Debug.Write(e.Error.Message);
            };
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<LoginView>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            var navigation = container.RegisterNavigationService(rootFrame);
            var navigationManager = SystemNavigationManager.GetForCurrentView();

            navigation.Navigated += (s, e) =>
            {
                navigationManager.AppViewBackButtonVisibility = navigation.CanGoBack
                    ? AppViewBackButtonVisibility.Visible
                    : AppViewBackButtonVisibility.Collapsed;
            };
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof (App).GetTypeInfo().Assembly;
            yield return typeof (LoginViewModel).GetTypeInfo().Assembly;
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
