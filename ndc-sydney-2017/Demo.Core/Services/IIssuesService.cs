using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Demo.Core.Services
{
    public interface IIssuesService
    {
        Task<IReadOnlyList<Issue>> Get(string owner, string name);
        Task<IReadOnlyList<IssueComment>> GetComments(string owner, string name, int number);
    }
}