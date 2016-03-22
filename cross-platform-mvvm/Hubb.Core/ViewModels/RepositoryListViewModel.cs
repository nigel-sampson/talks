using System;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class RepositoryListViewModel
    {
        private readonly Repository repository;

        public RepositoryListViewModel(Repository repository)
        {
            this.repository = repository;
        }

        public int Id => repository.Id;

        public string Name => repository.Name;

        public User Owner => repository.Owner;
    }
}
