using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.Services.NoNetwork
{
	public class TeamServicesClient : ITeamServicesClient
	{
		public Task<Project> GetProjectAsync(string id)
		{
			return Task.FromResult(new Project
			{
				Id = "0025a1fb-1783-46b1-a458-6fd787d202dc",
				Name = "Caliburn Micro",
				Description = "XAML made easy",
				Url = "http://caliburnmicro.com"
			});
		}

		public Task<IReadOnlyCollection<Project>> GetProjectsAsync()
		{
			var projects = new List<Project>
			{
				new Project
				{
					Id = "0025a1fb-1783-46b1-a458-6fd787d202dc",
					Name = "Caliburn Micro",
					Description = "XAML made easy",
					Url = "http://caliburnmicro.com"
				}
			};

			return Task.FromResult<IReadOnlyCollection<Project>>(new ReadOnlyCollection<Project>(projects));
		}

		public Task<IReadOnlyCollection<BuildDetail>> GetBuildsAsync(Project project)
		{
			var builds = new List<BuildDetail>
			{
				new BuildDetail
				{
					Id = 1,
					Definition = new Definition
					{
						Id = 2,
						Name = "Continuous Integration"
					},
					QueueTime = DateTimeOffset.UtcNow.AddHours(-1),
					StartTime = DateTimeOffset.UtcNow.AddMinutes(-2),
					FinishTime = DateTimeOffset.UtcNow.AddMinutes(-1),
					Result = "succeeded",
					Status = "completed"
				}
			};

			return Task.FromResult<IReadOnlyCollection<BuildDetail>>(new ReadOnlyCollection<BuildDetail>(builds));
		}

		public Task<IReadOnlyCollection<Definition>> GetDefinitionsAsync(Project project)
		{
			var builds = new List<Definition>
			{
				new Definition
				{
					Id = 2,
					Name = "Continuous Integration"
				}
			};

			return Task.FromResult<IReadOnlyCollection<Definition>>(new ReadOnlyCollection<Definition>(builds));
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
