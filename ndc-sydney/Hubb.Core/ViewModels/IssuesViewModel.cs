using System;
using System.Linq;
using Caliburn.Micro;
using Hubb.Core.Messages;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class IssuesViewModel : Conductor<IssueViewModel>.Collection.OneActive, IHandle<RepositorySelectedMessage>
    {
        private readonly IGitHubClient gitHubClient;
        private readonly IEventAggregator eventAggregator;

        public IssuesViewModel(IGitHubClient gitHubClient, IEventAggregator eventAggregator)
        {
            this.gitHubClient = gitHubClient;
            this.eventAggregator = eventAggregator;
        }

        protected override void OnInitialize()
        {
            eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            eventAggregator.Unsubscribe(this);
        }

        public async void Handle(RepositorySelectedMessage message)
        {
            var repository = message.Repository;

            Items.Clear();

            var issues = await gitHubClient.Issue.GetAllForRepository(repository.Owner.Login, repository.Name);

            Items.AddRange(issues.Select(i => new IssueViewModel(i)));
            
            ActiveItem = Items.FirstOrDefault();
        }
    }
}
