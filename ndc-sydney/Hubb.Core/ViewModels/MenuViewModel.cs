using System;
using Caliburn.Micro;
using Hubb.Core.Messages;
using Hubb.Core.Services;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly IHubbClient hubbClient;
        private readonly IEventAggregator eventAggregator;

        public MenuViewModel(IHubbClient hubbClient, IEventAggregator eventAggregator)
        {
            this.hubbClient = hubbClient;
            this.eventAggregator = eventAggregator;

            Repositories = new BindableCollection<Repository>();
        }

        protected override async void OnInitialize()
        {
            var results = await hubbClient.SearchAsync("caliburn");

            Repositories.AddRange(results);

            eventAggregator.PublishOnUIThread(new RepositorySelectedMessage(Repositories[0]));
        }

        public void SelectRepository(Repository repository)
        {
            eventAggregator.PublishOnUIThread(new RepositorySelectedMessage(repository));
        }

        public BindableCollection<Repository> Repositories { get; }
    }
}
