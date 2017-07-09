using System.Linq;
using Caliburn.Micro;
using Demo.Core.Messages;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IGitHubClient gitHubClient;

        public MenuViewModel(IEventAggregator eventAggregator, IGitHubClient gitHubClient)
        {
            this.eventAggregator = eventAggregator;
            this.gitHubClient = gitHubClient;
        }

        protected override async void OnInitialize()
        {
            var result = await gitHubClient.Search.SearchRepo(new SearchRepositoriesRequest("mvvm")
            {
                Language = Language.CSharp,
            });

            Repositories.AddRange(result.Items.Select(r => new RepositoryViewModel(r)));
        }

        public void RepoistorySelected(RepositoryViewModel repository)
        {
            var message = new RepositorySelectedMessage(repository.Owner, repository.Name);

            eventAggregator.PublishOnCurrentThread(message);
        }

        public BindableCollection<RepositoryViewModel> Repositories { get; } = new BindableCollection<RepositoryViewModel>();
    }
}
