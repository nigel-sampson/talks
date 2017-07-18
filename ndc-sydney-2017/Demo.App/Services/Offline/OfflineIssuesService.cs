using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Core.Services;
using Octokit;

namespace Demo.App.Services.Offline
{
    public class OfflineIssuesService : OfflineServiceBase, IIssuesService
    {
        public Task<IReadOnlyList<Issue>> Get(string owner, string name)
        {
            return Deserialize<IReadOnlyList<Issue>>("caliburn-micro-issues");
        }

        public Task<IReadOnlyList<IssueComment>> GetComments(string owner, string name, int number)
        {
            return Deserialize<IReadOnlyList<IssueComment>>("caliburn-micro-comments");
        }
    }
}
