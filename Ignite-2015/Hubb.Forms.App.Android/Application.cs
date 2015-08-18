using System;
using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Caliburn.Micro;
using Hubb.Core.Services;
using Hubb.Core.ViewModels;
using Hubb.Forms.Core.Services;
using Hubb.Forms.Core.Views;
using Octokit;

namespace Hubb.Forms.App.Android
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
            container = new SimpleContainer();
            container.Instance(container);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(Application).GetTypeInfo().Assembly;
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