using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Demo.Core.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IGitHubClient gitHubClient;

        public RepositoryService(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public Task<Repository> Get(string owner, string name)
        {
            return gitHubClient.Repository.Get(owner, name);
        }

        public async Task<IReadOnlyList<Repository>> Search(string term)
        {
            var result = await gitHubClient.Search.SearchRepo(new SearchRepositoriesRequest(term)
            {
                Language = Language.CSharp,
                PerPage = 12
            });

            return result.Items;
        }

        public Task<Readme> GetReadme(string owner, string name)
        {
            return gitHubClient.Repository.Content.GetReadme(owner, name);
        }
    }
}
