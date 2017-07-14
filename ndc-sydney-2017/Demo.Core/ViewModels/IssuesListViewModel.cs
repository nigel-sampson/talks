using System.Linq;
using Caliburn.Micro;
using Demo.Core.Messages;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class IssuesListViewModel : Conductor<IssueViewModel>.Collection.OneActive, IHandle<RepositorySelectedMessage>
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

            Items.Clear();
            Items.AddRange(issues.Select(i => new IssueViewModel(gitHubClient, message.Owner, message.Name, i)));
        }
    }
}
