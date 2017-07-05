using System;
using Caliburn.Micro;
using NDC.Build.Core.ViewModels;
using UIKit;

namespace NDC.Build.App.iOS
{
    public class ProjectsTableViewSource : BoundTableViewSource<ProjectViewModel>
    {
        public ProjectsTableViewSource(
            UITableViewController controller, 
            BindableCollection<ProjectViewModel> items, 
            Action<ProjectViewModel> onSelected)
            : base(controller, items, "ProjectTableCell", onSelected)
        {

        }

        protected override void BindCell(UITableViewCell cell, ProjectViewModel item)
        {
            cell.TextLabel.Text = item.Project.Name;
            cell.DetailTextLabel.Text = item.Project.Description;
        }
    }
}
