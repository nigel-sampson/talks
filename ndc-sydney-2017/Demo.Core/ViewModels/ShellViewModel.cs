using Caliburn.Micro;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly RepositoryDetailsViewModel details;
        private readonly IssuesListViewModel issues;

        public ShellViewModel(IEventAggregator eventAggregator, IGitHubClient gitHubClient)
        {
            details = new RepositoryDetailsViewModel(eventAggregator, gitHubClient);
            issues = new IssuesListViewModel(eventAggregator, gitHubClient);

            Menu = new MenuViewModel(eventAggregator, gitHubClient);
            Menu.ConductWith(this);

            ActiveScreen = details;
        }

        public MenuViewModel Menu { get; }

        public Screen ActiveScreen { get; set; }

        public void Toggle()
        {
            if (ActiveScreen is RepositoryDetailsViewModel)
                ActiveScreen = issues;
            else
                ActiveScreen = details;
        }
    }
}
