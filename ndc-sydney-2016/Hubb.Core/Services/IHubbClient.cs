using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public interface IHubbClient
    {
        Task<IReadOnlyList<Repository>> SearchAsync(string term);
        Task<IReadOnlyList<Issue>> GetIssuesAsync(Repository repository);
    }
}