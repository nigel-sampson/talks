using System.Collections.Generic;
using System.Threading.Tasks;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.Services
{
    public interface ITeamServicesClient
    {
        Task<IReadOnlyCollection<Project>> GetProjectsAsync();
        Task<IReadOnlyCollection<BuildDetail>> GetBuildsAsync(Project project);
        Task<IReadOnlyCollection<Definition>> GetDefinitionsAsync(Project project);
        Task<BuildDetail> QueueBuildAsync(Project project, BuildRequest buildRequest);
    }
}