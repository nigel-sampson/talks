using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Demo.Core.Messages;
using Demo.Core.ViewModels;
using Octokit;

namespace Demo.App
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
            ViewModelLocator.AddNamespaceMapping("Demo.App.Views", "Demo.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Demo.Core.ViewModels", "Demo.App.Views");

            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container.Instance<IGitHubClient>(new GitHubClient(new ProductHeaderValue("DemoApp")));
            container.PerRequest<ShellViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            if (args.Kind == ActivationKind.Protocol)
            {
                var protocolArgs = (ProtocolActivatedEventArgs) args;
                (var success, var owner, var name) = ParseProtocol(protocolArgs.Uri);

                if (success)
                {
                    var eventAggregator = container.GetInstance<IEventAggregator>();

                    eventAggregator.PublishOnCurrentThread(new RepositorySelectedMessage(owner, name));
                }
            }
        }

        private static (bool success, string owner, string name) ParseProtocol(Uri uri)
        {
            var expression = new Regex(@"ndc://(?<owner>[\w-]+)/(?<name>[\w-]+)");
            var match = expression.Match(uri.AbsoluteUri);

            if (!match.Success)
                return (false, null, null);

            return (true, match.Groups["owner"].Value, match.Groups["name"].Value);
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
