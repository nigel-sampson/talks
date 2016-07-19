using System;
using System.Collections.Generic;
using System.Reflection;
using Caliburn.Micro;
using NDC.Build.App.iOS.Services;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;
using NDC.Build.Forms.Core.Views;

namespace NDC.Build.Forms.App.iOS
{
    public class CaliburnAppDelegate : CaliburnApplicationDelegate
    {
        private SimpleContainer container;

        public CaliburnAppDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Instance(container);

            container
              .Singleton<ICredentialsService, UserDefaultsCredentialsService>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                typeof (LoginView).Assembly,
                typeof (LoginViewModel).Assembly
            };
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
