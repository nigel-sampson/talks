using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hubb.Core.Services;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class RepositorySearchViewModel : Screen
    {
        private readonly IRepositoryService repositories;

        public RepositorySearchViewModel(IRepositoryService repositories)
        {
            this.repositories = repositories;

            Results = new BindableCollection<RepositoryListViewModel>();
        }

        public async Task Search(string term)
        {
            var results = await repositories.SearchAsync(term);

            Results.Clear();
            Results.AddRange(results.Select(r => new RepositoryListViewModel(r)));
        }

        public BindableCollection<RepositoryListViewModel> Results { get; }
    }
}
