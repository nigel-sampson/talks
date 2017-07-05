using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDC.Build.Core.Model;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.Core.Services.NoNetwork
{
	public class OfflineTeamServicesClient : ITeamServicesClient
	{
        private readonly Random random = new Random();
	    private readonly string[] definitionNames = {"Continuous Integration", "Release", "Pull Requests"};
        private readonly List<Project> projects = new List<Project>
        {
            new Project
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Caliburn Micro",
                Description = "XAML made easy"
            },
            new Project
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "VSTS Toolset",
                Description = "Better open source with VSTS"
            },
            new Project
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Experiments",
                Description = "Weird stuff I'm playing with"
            }
        };

        public Task<Project> GetProjectAsync(string id)
        {
            return Task.FromResult(projects.SingleOrDefault(p => p.Id == id));
        }

		public Task<IReadOnlyCollection<Project>> GetProjectsAsync()
		{
			return Task.FromResult<IReadOnlyCollection<Project>>(projects);
		}

		public Task<IReadOnlyCollection<BuildDetail>> GetBuildsAsync(Project project)
		{
		    var builds = Enumerable.Range(1, 15).Select(i => GetBuild()).ToList();

			return Task.FromResult<IReadOnlyCollection<BuildDetail>>(builds);
		}

	    private BuildDetail GetBuild()
	    {
            var definitonId = random.Next(definitionNames.Length);

	        return new BuildDetail
	        {
	            Id = 1,
	            Definition = new Definition
	            {
	                Id = definitonId,
	                Name = definitionNames[definitonId]
	            },
	            QueueTime = DateTimeOffset.UtcNow.AddHours(-1),
	            StartTime = DateTimeOffset.UtcNow.AddMinutes(-2),
	            FinishTime = DateTimeOffset.UtcNow.AddMinutes(-1),
	            Result = BuildViewModel.Colours.Keys.ElementAt(random.Next(3)),
	            Status = "completed"
	        };
	    }

		public Task<IReadOnlyCollection<Definition>> GetDefinitionsAsync(Project project)
		{
		    var definitions = definitionNames.Select((n, i) => new Definition
		    {
		        Id = i,
		        Name = n
		    }).ToList();

			return Task.FromResult<IReadOnlyCollection<Definition>>(definitions);
		}

		public Task<BuildDetail> QueueBuildAsync(Project project, BuildRequest buildRequest)
		{
			return Task.FromResult(new BuildDetail
			{
				Id = 1,
				Definition = buildRequest.Definition,
				QueueTime = DateTimeOffset.UtcNow,
				StartTime = DateTimeOffset.UtcNow,
				FinishTime = DateTimeOffset.UtcNow,
				Result = "unknown",
				Status = ""
			});
		}
	}
}
