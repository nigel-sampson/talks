using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.Droid.Adapters
{
    public class ProjectsAdapter : BoundAdapter<ProjectViewModel>
    {
        private readonly Activity activity;

        public ProjectsAdapter(Activity activity, BindableCollection<ProjectViewModel> items) 
            : base(items)
        {
            this.activity = activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var projectViewModel = this[position];

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = projectViewModel.Project.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = projectViewModel.Project.Description;

            return view;
        }

        protected override long GetItemId(ProjectViewModel item)
        {
            return item.Project.Id.GetHashCode();
        }
    }
}