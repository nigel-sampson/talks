using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Spending.App.Web.Startup))]

namespace Spending.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}