using System.Linq;
using Caliburn.Micro;
using Demo.Core.Messages;
using Demo.Core.Services;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRepositoryService repositories;

        public MenuViewModel(IEventAggregator eventAggregator, IRepositoryService repositories)
        {
            this.eventAggregator = eventAggregator;
            this.repositories = repositories;
        }

        protected override async void OnInitialize()
        {
            var results = await repositories.Search("mvvm");

            Repositories.AddRange(results.Select(r => new RepositoryViewModel(r)));
        }

        public void SelectRepository(RepositoryViewModel repository)
        {
            var message = new RepositorySelectedMessage(repository.Owner, repository.Name);

            eventAggregator.PublishOnCurrentThread(message);
        }

        public BindableCollection<RepositoryViewModel> Repositories { get; } = new BindableCollection<RepositoryViewModel>();
    }
}
