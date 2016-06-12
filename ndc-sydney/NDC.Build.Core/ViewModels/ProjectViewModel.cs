using System;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(Project project)
        {
            Project = project;
        }

        public Project Project { get; }
    }
}
