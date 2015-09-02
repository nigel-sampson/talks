using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using Hubb.App.Android.Services;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Octokit;

namespace Hubb.App.Android
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
            ViewModelLocator.AddNamespaceMapping("Hubb.App.Android.Activities", "Hubb.Core.ViewModels");

            container = new SimpleContainer();

            container
                .Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("hubb-android", "1.0.0")))
                .Instance<IAppNavigationService>(new AppNavigationService(this));

            container
                .Singleton<IAuthenticationService, NoNetworkAuthenticationService>()
                .Singleton<IRepositoryService, NoNetworkRepositoryService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<RepositorySearchViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(Application).GetTypeInfo().Assembly;
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