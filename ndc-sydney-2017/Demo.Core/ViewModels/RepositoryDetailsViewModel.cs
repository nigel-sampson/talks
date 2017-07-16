using Caliburn.Micro;
using Demo.Core.Messages;
using Demo.Core.Services;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class RepositoryDetailsViewModel : Screen, IHandle<RepositorySelectedMessage>
    {
        private readonly IRepositoryService repositories;

        public RepositoryDetailsViewModel(IEventAggregator eventAggregator, IRepositoryService repositories)
        {
            this.repositories = repositories;

            eventAggregator.Subscribe(this);
        }

        public async void Handle(RepositorySelectedMessage message)
        {
            var repository = await repositories.Get(message.Owner, message.Name);

            Name = $"{repository.Owner.Login} / {repository.Name}";
            Description = repository.Description;

            var readme = await repositories.GetReadme(message.Owner, message.Name);

            Readme = readme.Content;
        }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Readme { get; set; }
    }
}
