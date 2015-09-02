using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;

namespace Hubb.Core.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IGitHubClient gitHubClient;

        public RepositoryService(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public async Task<IReadOnlyList<Repository>> SearchAsync(string term)
        {
            var result = await gitHubClient.Search.SearchRepo(new SearchRepositoriesRequest(term)
            {
                Page = 1,
                PerPage = 20
            });

            return result.Items;
        }

        public Task<Repository> GetDetailsAsync(string owner, string name)
        {
            return gitHubClient.Repository.Get(owner, name);
        }
    }
}
