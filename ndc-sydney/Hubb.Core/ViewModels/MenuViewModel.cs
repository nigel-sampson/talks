using System;
using Caliburn.Micro;
using Hubb.Core.Messages;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly IGitHubClient gitHubClient;
        private readonly IEventAggregator eventAggregator;

        public MenuViewModel(IGitHubClient gitHubClient, IEventAggregator eventAggregator)
        {
            this.gitHubClient = gitHubClient;
            this.eventAggregator = eventAggregator;

            Repositories = new BindableCollection<Repository>();
        }

        protected override async void OnInitialize()
        {
            var search = new SearchRepositoriesRequest("caliburn")
            {
                Language = Language.CSharp,
                PerPage = 25
            };

            var results = await gitHubClient.Search.SearchRepo(search);

            Repositories.AddRange(results.Items);

            eventAggregator.PublishOnUIThread(new RepositorySelectedMessage(Repositories[0]));
        }

        public void SelectRepository(Repository repository)
        {
            eventAggregator.PublishOnUIThread(new RepositorySelectedMessage(repository));
        }

        public BindableCollection<Repository> Repositories { get; }
    }
}
