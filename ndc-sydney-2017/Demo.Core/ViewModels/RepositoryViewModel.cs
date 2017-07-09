using Octokit;

namespace Demo.Core.ViewModels
{
    public class RepositoryViewModel
    {
        public RepositoryViewModel(Repository repository)
        {
            Owner = repository.Owner.Login;
            Name = repository.Name;
        }

        public string Owner { get; }
        public string Name { get; }
    }
}
