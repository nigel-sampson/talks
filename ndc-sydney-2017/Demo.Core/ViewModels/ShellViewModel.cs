using Caliburn.Micro;
using Demo.Core.Services;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly ISettingsService settings;
        private readonly RepositoryDetailsViewModel details;
        private readonly IssuesListViewModel issues;
        private Screen activeScreen;

        public ShellViewModel(IEventAggregator eventAggregator, IGitHubClient gitHubClient, ISettingsService settings)
        {
            this.settings = settings;

            details = new RepositoryDetailsViewModel(eventAggregator, gitHubClient);
            issues = new IssuesListViewModel(eventAggregator, gitHubClient);

            Menu = new MenuViewModel(eventAggregator, gitHubClient);
            Menu.ConductWith(this);

            ActiveScreen = details;
        }

        public MenuViewModel Menu { get; }

        public Screen ActiveScreen
        {
            get => activeScreen;
            set
            {
                ScreenExtensions.TryDeactivate(activeScreen, false);
                activeScreen = value;
                ScreenExtensions.TryActivate(activeScreen);
            }
        }

        public void ViewDetails()
        {
            ActiveScreen = details;
        }

        public void ViewIssues()
        {
            ActiveScreen = issues;
        }

        public void ViewSettings()
        {
            ActiveScreen = new SettingsViewModel(settings);
        }
    }
}
