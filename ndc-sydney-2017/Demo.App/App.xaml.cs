using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Demo.Core.ViewModels;
using Octokit;

namespace Demo.App
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
            ViewModelLocator.AddNamespaceMapping("Demo.App.Views", "Demo.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Demo.Core.ViewModels", "Demo.App.Views");

            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container.Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("DemoApp")));
            container.PerRequest<ShellViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootViewFor<ShellViewModel>();
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
