using System;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;
using UIKit;

namespace NDC.Build.App.iOS.Services
{
    public class StoryboardNavigationService : IApplicationNavigationService
    {
        private readonly UINavigationController navigationController;

        public StoryboardNavigationService(UINavigationController navigationController)
        {
            this.navigationController = navigationController;
        }

        public void ToProjects()
        {
            //var controller = navigationController.Storyboard.InstantiateViewController("x");

            //navigationController.PushViewController(controller, true);
            throw new NotImplementedException();
        }

        public void ToProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
