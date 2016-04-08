using System;
using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using Spending.App.Android.Activities;
using Spending.App.Android.Services;
using Spending.Core.Services;
using Spending.Core.ViewModels;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace Spending.App.Android
{
    [Application(Label = "@string/ApplicationName", Icon = "@drawable/Icon")]
    public class Application : CaliburnApplication
    {
        private SimpleContainer container;

        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            Initialize();
        }

        protected override void Configure()
        {
            ViewModelLocator.AddNamespaceMapping("Spending.App.Android.Activities", "Spending.Core.ViewModels");

            container = new SimpleContainer();

            container
                .Instance<IMobileServiceClient>(new MobileServiceClient("https://spending.azurewebsites.net"))
                .Instance(this);

            container
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IApplicationNavigationService, ApplicationNavigationService>()
                .Singleton<IExpenseService, ExpenseService>()
                .Singleton<INotificationsService, NotificationsService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<CurrentExpensesViewModel>()
                .PerRequest<AddExpenseViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(LoginActivity).GetTypeInfo().Assembly;
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