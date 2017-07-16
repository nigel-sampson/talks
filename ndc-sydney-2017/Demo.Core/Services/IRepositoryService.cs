using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Demo.Core.Services
{
    public interface IRepositoryService
    {
        Task<Repository> Get(string owner, string name);
        Task<IReadOnlyList<Repository>> Search(string term);
        Task<Readme> GetReadme(string owner, string name);
    }
}