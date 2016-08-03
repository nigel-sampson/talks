using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Hubb.App.UWP.Views;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Octokit;

namespace Hubb.App.UWP
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
            ViewModelLocator.AddNamespaceMapping("Hubb.App.UWP.Views", "Hubb.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Hubb.Core.ViewModels", "Hubb.App.UWP.Views");

            MessageBinder.SpecialValues.Add("$clickedItem", c => ((ItemClickEventArgs)c.EventArgs).ClickedItem);

            container = new WinRTContainer();

            container.RegisterWinRTServices();

            container.Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("Hubb", "0.0.1")));
            container.Singleton<IHubbClient, OfflineHubbClient>();
            container.PerRequest<ShellViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(ShellView).GetTypeInfo().Assembly;
            yield return typeof(ShellViewModel).GetTypeInfo().Assembly;
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
