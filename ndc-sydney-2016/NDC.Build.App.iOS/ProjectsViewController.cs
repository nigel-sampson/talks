using Foundation;
using System;
using NDC.Build.App.iOS.ViewControllers;
using NDC.Build.Core.ViewModels;
using UIKit;

namespace NDC.Build.App.iOS
{
    public partial class ProjectsViewController : UITableViewControllerBase<ProjectsViewModel>
    {
        public ProjectsViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new ProjectsTableViewSource(this, ViewModel.Projects, p => ViewModel.ViewProject(p));
        }
    }
}