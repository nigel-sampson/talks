using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public class NoNetworkRepositoryService : IRepositoryService
    {
        public Task<IReadOnlyList<Repository>> SearchAsync(string term)
        {
            var repos = new List<Repository>();

            return Task.FromResult<IReadOnlyList<Repository>>(
                new ReadOnlyCollection<Repository>(repos));
        }

        public Task<Repository> GetDetailsAsync(string owner, string name)
        {
            return Task.FromResult(new Repository());
        }
    }
}
