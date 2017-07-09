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

        public void Handle(RepositorySelectedMessage message)
        {
            
        }
    }
}
