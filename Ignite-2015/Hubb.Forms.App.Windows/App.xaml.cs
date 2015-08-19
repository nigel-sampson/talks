using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Hubb.Core.ViewModels;
using Hubb.Forms.App.Windows.Views;
using Hubb.Forms.Core.Views;

namespace Hubb.Forms.App.Windows
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
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Xamarin.Forms.Forms.Init(e);

            DisplayRootView<MainView>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(App).GetTypeInfo().Assembly;
            yield return typeof(LoginViewModel).GetTypeInfo().Assembly;
            yield return typeof(LoginView).GetTypeInfo().Assembly;
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