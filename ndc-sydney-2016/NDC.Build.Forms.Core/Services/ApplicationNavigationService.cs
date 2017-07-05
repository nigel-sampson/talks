using System;
using Caliburn.Micro.Xamarin.Forms;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.Forms.Core.Services
{
    public class ApplicationNavigationService : IApplicationNavigationService
    {
        private readonly INavigationService navigation;

        public ApplicationNavigationService(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        public void ToProjects()
        {
            navigation.For<ProjectsViewModel>()
                .Navigate();
        }

        public void ToProject(Project project)
        {
            navigation.For<BuildsViewModel>()
                .WithParam(v => v.ProjectId, project.Id)
                .Navigate();
        }
    }
}
