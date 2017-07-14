using System;
using Demo.App.Views.Issue;

namespace Demo.App.Views
{
    public sealed partial class IssuesListView
    {
        public IssuesListView()
        {
            InitializeComponent();

            var views = new[]
            {
                new IssueView("MasterView", "Default"),
                new IssueView("ReactionsView", "Reactions")
            };

            ViewSelector.ItemsSource = views;
            ViewSelector.SelectedItem = views[0];
        }
    }
}
