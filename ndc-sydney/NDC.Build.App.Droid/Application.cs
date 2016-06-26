using System;
using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Android.Widget;
using Caliburn.Micro;
using NDC.Build.App.Droid.Services;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.Droid
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
            ViewModelLocator.AddNamespaceMapping("NDC.Build.App.Droid.Activities", "NDC.Build.Core.ViewModels");
            
            container = new SimpleContainer();

            container.Instance(this);
            
            container
                .Singleton<ITeamServicesClient, TeamServicesClient>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IApplicationNavigationService, ApplicationNavigationService>()
                .Singleton<ICredentialsService, PreferencesCredentialsService>()
                .Singleton<IDialogService, AlertDialogService>();

            container
                .PerRequest<LoginViewModel>()
                .PerRequest<ProjectsViewModel>()
                .PerRequest<BuildsViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(Application).GetTypeInfo().Assembly;
            yield return typeof(LoginViewModel).GetTypeInfo().Assembly;
        }

        protected override object GetInstance(Type service, string key)
        {
            try
            {
                var x = container.GetInstance(service, key);

                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
            
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