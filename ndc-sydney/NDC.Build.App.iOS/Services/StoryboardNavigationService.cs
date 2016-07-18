using System;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;
using UIKit;

namespace NDC.Build.App.iOS.Services
{
    public class StoryboardNavigationService : IApplicationNavigationService
    {
        private readonly UINavigationController navigationController;

        public StoryboardNavigationService()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            navigationController = (UINavigationController) window.RootViewController;
        }

        public void ToProjects()
        {
            var controller = navigationController.Storyboard.InstantiateViewController("Projects");

            navigationController.PushViewController(controller, true);
        }

        public void ToProject(Project project)
        {
            var controller = (BuildsViewController) navigationController.Storyboard.InstantiateViewController("Builds");

            controller.SetProject(project);

            navigationController.PushViewController(controller, true);
        }
    }
}
