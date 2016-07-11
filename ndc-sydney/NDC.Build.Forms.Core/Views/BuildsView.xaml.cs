using System;
using NDC.Build.Core.ViewModels;
using Xamarin.Forms;

namespace NDC.Build.Forms.Core.Views
{
    public partial class BuildsView
    {
        public BuildsView()
        {
            InitializeComponent();
        }

        private void OnQueueBuild(object sender, EventArgs e)
        {
            ((BuildsViewModel)BindingContext).QueueBuild();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }
    }
}
