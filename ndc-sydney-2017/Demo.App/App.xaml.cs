using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Caliburn.Micro;
using Demo.App.Services;
using Demo.App.Services.Offline;
using Demo.Core.Messages;
using Demo.Core.Services;
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
            ConfigureTitleBar();

            ViewModelLocator.AddNamespaceMapping("Demo.App.Views", "Demo.Core.ViewModels");
            ViewLocator.AddNamespaceMapping("Demo.Core.ViewModels", "Demo.App.Views");

            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container.Singleton<ISettingsService, StorageSettingsService>();
            container.Singleton<IRepositoryService, RepositoryService>();
            container.Singleton<IIssuesService, IssuesService>();

            container.Instance(CreateClient());

            container
                .ViewModel<ShellViewModel>()
                .ViewModel<MenuViewModel>()
                .ViewModel<RepositoryDetailsViewModel>()
                .ViewModel<IssuesListViewModel>();
        }

        private static void ConfigureTitleBar()
        {
            var appView = ApplicationView.GetForCurrentView();
            appView.TitleBar.BackgroundColor = Color.FromArgb(255, 0, 122, 204);
            appView.TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 30, 30, 30);
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

        private IGitHubClient CreateClient()
        {
            var settings = container.GetInstance<ISettingsService>();
            var credentials = settings.GetCredentials();

            return new GitHubClient(new ProductHeaderValue("DemoApp"))
            {
                Credentials = credentials
            };
        }
    }
}
