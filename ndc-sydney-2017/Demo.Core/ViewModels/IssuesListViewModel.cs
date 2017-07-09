using System.Linq;
using Caliburn.Micro;
using Demo.Core.Messages;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class IssuesListViewModel : Screen, IHandle<RepositorySelectedMessage>
    {
        private readonly IGitHubClient gitHubClient;

        public IssuesListViewModel(IEventAggregator eventAggregator, IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
            
            eventAggregator.Subscribe(this);
        }

        public async void Handle(RepositorySelectedMessage message)
        {
            var issues = await gitHubClient.Issue.GetAllForRepository(message.Owner, message.Name);

            Issues.Clear();
            Issues.AddRange(issues.Select(i => new IssueViewModel(i)));
        }

        public BindableCollection<IssueViewModel> Issues { get; } = new BindableCollection<IssueViewModel>();

        public IssueViewModel SelectedIssue { get; set; }
    }
}
