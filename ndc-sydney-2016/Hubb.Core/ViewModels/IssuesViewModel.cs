using System;
using System.Linq;
using Caliburn.Micro;
using Hubb.Core.Messages;
using Hubb.Core.Services;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class IssuesViewModel : Conductor<IssueViewModel>.Collection.OneActive, IHandle<RepositorySelectedMessage>
    {
        private readonly IHubbClient hubbClient;
        private readonly IEventAggregator eventAggregator;

        public IssuesViewModel(IHubbClient hubbClient, IEventAggregator eventAggregator)
        {
            this.hubbClient = hubbClient;
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
            Items.Clear();

            var issues = await hubbClient.GetIssuesAsync(message.Repository);

            Items.AddRange(issues.Select(i => new IssueViewModel(i)));
            
            ActiveItem = Items.FirstOrDefault();
        }
    }
}
