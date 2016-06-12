using System;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.Services
{
    public interface IApplicationNavigationService
    {
        void ToProjects();
        void ToProject(Project project);
    }
}
