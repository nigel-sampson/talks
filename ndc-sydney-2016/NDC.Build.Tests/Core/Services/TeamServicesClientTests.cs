using System;
using System.Linq;
using System.Threading.Tasks;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;
using Xunit;

namespace NDC.Build.Tests.Core.Services
{
    [Trait("Category", "Integration")]
    public class TeamServicesClientTests
    {
        [Fact]
        public async Task CanGetProjectsAsync()
        {
            var client = new TeamServicesClient(new EnvironmentVariableCredentialsService());

            var projects = await client.GetProjectsAsync();

            Assert.True(projects.Count > 0);
        }

        [Fact]
        public async Task CanGetProjectsAndThenBuildsAsync()
        {
            var client = new TeamServicesClient(new EnvironmentVariableCredentialsService());

            var projects = await client.GetProjectsAsync();
            var project = projects.First();

            var builds = await client.GetBuildsAsync(project);

            Assert.True(builds.Count > 0);
        }

        [Fact]
        public async Task CanGetProjectsAndThenDefinitionsAsync()
        {
            var client = new TeamServicesClient(new EnvironmentVariableCredentialsService());

            var projects = await client.GetProjectsAsync();
            var project = projects.First();

            var definitions = await client.GetDefinitionsAsync(project);

            Assert.True(definitions.Count > 0);
        }

        [Fact]
        public async Task CanQueueBuildAsync()
        {
            var client = new TeamServicesClient(new EnvironmentVariableCredentialsService());

            var projects = await client.GetProjectsAsync();
            var project = projects.First();

            var definitions = await client.GetDefinitionsAsync(project);

            var buildRequest = new BuildRequest
            {
                Definition = definitions.First(),
                SourceBranch = "refs/heads/master"
            };

            var build = await client.QueueBuildAsync(project, buildRequest);

            Assert.NotNull(build);
        }
    }
}
