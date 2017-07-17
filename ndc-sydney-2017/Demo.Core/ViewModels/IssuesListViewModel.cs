using System.Linq;
using Caliburn.Micro;
using Demo.Core.Messages;
using Demo.Core.Services;

namespace Demo.Core.ViewModels
{
    public class IssuesListViewModel : Conductor<IssueViewModel>.Collection.OneActive, IHandle<RepositorySelectedMessage>
    {
        private readonly IIssuesService issues;

        public IssuesListViewModel(IEventAggregator eventAggregator, IIssuesService issues)
        {
            this.issues = issues;
            
            eventAggregator.Subscribe(this);
        }

        public async void Handle(RepositorySelectedMessage message)
        {
            var repositoryIssues = await issues.Get(message.Owner, message.Name);

            Items.Clear();
            Items.AddRange(repositoryIssues.Select(i => new IssueViewModel(i, () => issues.GetComments(message.Owner, message.Name, i.Number))));
        }
    }
}
