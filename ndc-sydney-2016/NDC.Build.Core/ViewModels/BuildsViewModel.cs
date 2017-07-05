using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;

namespace NDC.Build.Core.ViewModels
{
    public class BuildsViewModel : Screen
    {
        private readonly ITeamServicesClient teamServices;
        private readonly IDialogService dialogs;
        private IReadOnlyCollection<Definition> definitions;

        public BuildsViewModel(ITeamServicesClient teamServices, IDialogService dialogs)
        {
            this.teamServices = teamServices;
            this.dialogs = dialogs;

            Builds = new BindableCollection<BuildViewModel>();
        }

        public string ProjectId { get; set; }

        protected override async void OnInitialize()
        {
            Project = await teamServices.GetProjectAsync(ProjectId);

            definitions = await teamServices.GetDefinitionsAsync(Project);

            var builds = await teamServices.GetBuildsAsync(Project);

            Builds.AddRange(builds.OrderByDescending(b => b.QueueTime).Select(b => new BuildViewModel(b)));
        }
        
        public async void QueueBuild()
        {
            var selectedDefinition = await dialogs.ShowSelectionDialogAsync("Queue a new build", "Definitions", definitions);

            if (selectedDefinition == null)
                return;

            var queuedBuild = await teamServices.QueueBuildAsync(Project, new BuildRequest
            {
                Definition = selectedDefinition,
                SourceBranch = "master"
            });

            Builds.Insert(0, new BuildViewModel(queuedBuild));
        }

        public BindableCollection<BuildViewModel> Builds { get; }

        public Project Project { get; set; }
    }
}
