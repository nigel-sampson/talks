using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public interface IRepositoryService
    {
        Task<IReadOnlyList<Repository>> SearchAsync(string term);
        Task<Repository> GetDetailsAsync(string owner, string name);
    }
}