using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public class HubbClient : IHubbClient
    {
        private readonly IGitHubClient gitHubClient;

        public HubbClient(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public async Task<IReadOnlyList<Repository>> SearchAsync(string term)
        {
            var search = new SearchRepositoriesRequest("caliburn")
            {
                Language = Language.CSharp,
                PerPage = 25
            };

            var results = await gitHubClient.Search.SearchRepo(search);

            return results.Items;
        }

        public async Task<IReadOnlyList<Issue>> GetIssuesAsync(Repository repository)
        {
            return await gitHubClient.Issue.GetAllForRepository(repository.Owner.Login, repository.Name);
        }
    }
}
