using System;
using System.Linq;
using Caliburn.Micro;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;

namespace NDC.Build.Core.ViewModels
{
    public class BuildsViewModel : Screen
    {
        private readonly ITeamServicesClient teamServices;

        public BuildsViewModel(ITeamServicesClient teamServices)
        {
            this.teamServices = teamServices;

            Builds = new BindableCollection<BuildViewModel>();
        }

        public string ProjectId { get; set; }

        protected override async void OnInitialize()
        {
            Project = await teamServices.GetProjectAsync(ProjectId);

            var builds = await teamServices.GetBuildsAsync(Project);

            Builds.AddRange(builds.Select(b => new BuildViewModel(b)));
        }

        public async void QueueBuild()
        {
            var definitions = await teamServices.GetDefinitionsAsync(Project);
            await teamServices.QueueBuildAsync(Project, new BuildRequest
            {
                Definition = definitions.First(),
                SourceBranch = "master"
            });
        }

        public BindableCollection<BuildViewModel> Builds { get; }

        public Project Project { get; set; }
    }
}
