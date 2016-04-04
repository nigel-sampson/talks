using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Spending.App.Windows.Services;
using Spending.App.Windows.Views;
using Spending.Core.Services;
using Spending.Core.ViewModels;

namespace Spending.App.Windows
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
            ViewModelLocator.AddNamespaceMapping("Spending.App.Windows.Views", "Spending.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Spending.Core.ViewModels", "Spending.App.Windows.Views");

            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container
                .Instance<IMobileServiceClient>(new MobileServiceClient("https://spending.azurewebsites.net"));

            container
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IApplicationNavigationService, ApplicationNavigationService>()
                .Singleton<IExpenseService, ExpenseService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<CurrentExpensesViewModel>()
                .PerRequest<AddExpenseViewModel>();
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
            yield return typeof (LoginView).GetTypeInfo().Assembly;
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
