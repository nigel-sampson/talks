using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Core.Services;
using Octokit;

namespace Demo.App.Services.Offline
{
    public class OfflineIssuesService : IIssuesService
    {
        public Task<IReadOnlyList<Issue>> Get(string owner, string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<IssueComment>> GetComments(string owner, string name, int number)
        {
            throw new NotImplementedException();
        }
    }
}
