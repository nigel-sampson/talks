using System;
using System.Runtime.InteropServices;
using Caliburn.Micro;
using CoreAnimation;
using CoreGraphics;
using NDC.Build.Core.ViewModels;
using UIKit;

namespace NDC.Build.App.iOS
{
    public class BuildsTableViewSource : BoundTableViewSource<BuildViewModel>
    {
        public BuildsTableViewSource(UITableViewController controller, BindableCollection<BuildViewModel> items)
            : base(controller, items, "BuildTableCell", null)
        {
        }

        protected override void BindCell(UITableViewCell cell, BuildViewModel item)
        {
            cell.TextLabel.Text = item.Build.Definition.Name;
            cell.DetailTextLabel.Text = item.StartedOn;

            cell.TextLabel.Alpha = (nfloat) item.Completed;
            cell.DetailTextLabel.Alpha = (nfloat)item.Completed;

            var view = new UIView(new CGRect(5, 0, 5, cell.Frame.Size.Height))
            {
                BackgroundColor = item.Result.ToUIColor()
            };

            cell.ContentView.AddSubview(view);
        }
    }
}
