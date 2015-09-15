using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Caliburn.Micro;
using UniversalStudio.ViewModels;

namespace UniversalStudio
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

            container.PerRequest<ShellViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key) => container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type service) => container.GetAllInstances(service);

        protected override void BuildUp(object instance) => container.BuildUp(instance);
    }
}
