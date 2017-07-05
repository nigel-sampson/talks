using Foundation;
using System;
using NDC.Build.App.iOS.ViewControllers;
using NDC.Build.Core.Model;
using NDC.Build.Core.ViewModels;
using UIKit;

namespace NDC.Build.App.iOS
{
    public partial class BuildsViewController : UITableViewControllerBase<BuildsViewModel>
    {
        public BuildsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new BuildsTableViewSource(this, ViewModel.Builds);

            NavigationItem.RightBarButtonItems = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.Add, (s, e) => ViewModel.QueueBuild())
            };
        }

        public void SetProject(Project project) => ViewModel.ProjectId = project.Id;
    }
}