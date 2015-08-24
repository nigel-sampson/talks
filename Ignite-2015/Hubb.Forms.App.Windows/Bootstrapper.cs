using System;
using System.Collections.Generic;
using System.Reflection;
using Caliburn.Micro;
using Hubb.Core.ViewModels;
using Hubb.Forms.Core.Views;

namespace Hubb.Forms.App.Windows
{
    public class Bootstrapper : PhoneBootstrapperBase
    {
        private PhoneContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new PhoneContainer();
            container.RegisterPhoneServices(RootFrame);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(Bootstrapper).GetTypeInfo().Assembly;
            yield return typeof(LoginViewModel).GetTypeInfo().Assembly;
            yield return typeof(LoginView).GetTypeInfo().Assembly;
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
    }
}
