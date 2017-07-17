using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Core.Services;
using Octokit;

namespace Demo.App.Services.Offline
{
    public class OfflineRepositoryService : OfflineServiceBase, IRepositoryService
    {
        public Task<Repository> Get(string owner, string name)
        {
            return Deserialize<Repository>("caliburn-micro");
        }

        public Task<IReadOnlyList<Repository>> Search(string term)
        {
            return Deserialize<IReadOnlyList<Repository>>("search");
        }

        public Task<Readme> GetReadme(string owner, string name)
        {
            return Deserialize<Readme>("caliburn-micro-readme");
        }
    }
}
