using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Caliburn.Micro;
using NDC.Build.App.UWP.Services;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;
using NDC.Build.Forms.App.UWP.Views;
using NDC.Build.Forms.Core.Views;

namespace NDC.Build.Forms.App.UWP
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
            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container
               .Singleton<ICredentialsService, SettingsCredentialsService>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Initialize();

            // Skip the whole DisplayRoot etc, it's not needed in XF

            Xamarin.Forms.Forms.Init(e);

            Window.Current.Content = new HostView();
            Window.Current.Activate();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(LoginView).GetTypeInfo().Assembly;
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
