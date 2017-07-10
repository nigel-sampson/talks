using Caliburn.Micro;
using Demo.Core.Messages;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class RepositoryDetailsViewModel : Screen, IHandle<RepositorySelectedMessage>
    {
        private readonly IGitHubClient gitHubClient;

        public RepositoryDetailsViewModel(IEventAggregator eventAggregator, IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;

            eventAggregator.Subscribe(this);
        }

        public async void Handle(RepositorySelectedMessage message)
        {
            var repository = await gitHubClient.Repository.Get(message.Owner, message.Name);

            Name = $"{repository.Owner.Login} / {repository.Name}";
            Description = repository.Description;

            var readme = await gitHubClient.Repository.Content.GetReadme(message.Owner, message.Name);

            Readme = readme.Content;
        }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Readme { get; set; }
    }
}
