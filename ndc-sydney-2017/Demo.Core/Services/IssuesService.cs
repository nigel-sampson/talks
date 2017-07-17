using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Demo.Core.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly IGitHubClient gitHubClient;

        public IssuesService(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public Task<IReadOnlyList<Issue>> Get(string owner, string name)
        {
            return gitHubClient.Issue.GetAllForRepository(owner, name);
        }

        public Task<IReadOnlyList<IssueComment>> GetComments(string owner, string name, int number)
        {
            return gitHubClient.Issue.Comment.GetAllForIssue(owner, name, number);
        }
    }
}
