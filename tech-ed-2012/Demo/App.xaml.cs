using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Demo.Views;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Demo
{
    public sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            base.Configure();

            _container = new WinRTContainer(RootFrame);
            _container.RegisterWinRTServices();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override Type GetDefaultView()
        {
            return typeof(MenuView);
        }

        protected override async void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            var dialog = new MessageDialog(e.Message, "Unhandled exception in Application!");

            await dialog.ShowAsync();
        }
    }
}
