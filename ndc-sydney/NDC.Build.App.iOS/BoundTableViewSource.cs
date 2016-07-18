using System;
using System.Collections.Specialized;
using Caliburn.Micro;
using Foundation;
using UIKit;

namespace NDC.Build.App.iOS
{
    public abstract class BoundTableViewSource<T> : UITableViewSource
    {
        private readonly UITableViewController controller;
        private readonly BindableCollection<T> items;
        private readonly string cellIdentifier;
        private readonly Action<T> onSelected;

        protected BoundTableViewSource(
            UITableViewController controller, 
            BindableCollection<T> items, 
            string cellIdentifier,
            Action<T> onSelected)
        {
            this.controller = controller;
            this.items = items;
            this.cellIdentifier = cellIdentifier;
            this.onSelected = onSelected;

            items.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            controller.TableView.ReloadData();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = items[indexPath.Row];
            var cell = tableView.DequeueReusableCell(cellIdentifier)
                       ?? new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);

            BindCell(cell, item);

            return cell;
        }

        protected abstract void BindCell(UITableViewCell cell, T item);

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = items[indexPath.Row];

            onSelected(item);

           controller.TableView.DeselectRow(indexPath, false);
        }
    }
}
