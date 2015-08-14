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

        protected override void Configure()
        {
            ViewModelLocator.AddNamespaceMapping("Hubb.App.Android.Activities", "Hello.Xamarin.Core.ViewModels");

            container = new SimpleContainer();

            container
                .Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("hubb-uwp", "1.0.0")))
                .Instance<IAppNavigationService>(new AppNavigationService(this));

            container
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IRepositoryService, RepositoryService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<RepositorySearchViewModel>();

            //Coroutine.Completed += (s, e) =>
            //{
            //    if (e.Error == null)
            //        return;

            //    Debug.Write(e.Error.Message);
            //};
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