using System;
using System.Linq;
using Caliburn.Micro;
using NDC.Build.Core.Services;

namespace NDC.Build.Core.ViewModels
{
    public class ProjectsViewModel : Screen
    {
        private readonly ITeamServicesClient teamServices;
        private readonly IApplicationNavigationService navigation;

        public ProjectsViewModel(ITeamServicesClient teamServices, IApplicationNavigationService navigation)
        {
            this.teamServices = teamServices;
            this.navigation = navigation;

            Projects = new BindableCollection<ProjectViewModel>();
        }

        protected override async void OnInitialize()
        {
            var projects = await teamServices.GetProjectsAsync();

            Projects.AddRange(projects.Select(p => new ProjectViewModel(p)));
        }

        public void ViewProject(ProjectViewModel projectViewModel)
        {
            if (projectViewModel == null)
                return;

            navigation.ToProject(projectViewModel.Project);
        }

        public BindableCollection<ProjectViewModel> Projects { get; }
    }
}
