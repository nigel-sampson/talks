using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.Droid.Adapters
{
    public class BuildsAdapter : BoundAdapter<BuildViewModel>
    {
        private readonly Activity activity;

        public BuildsAdapter(Activity activity, BindableCollection<BuildViewModel> items)
            : base(items)
        {
            this.activity = activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var buildsViewModel = this[position];

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = buildsViewModel.Build.Definition.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = buildsViewModel.StartedOn;

            return view;
        }

        protected override long GetItemId(BuildViewModel item)
        {
            return item.Build.Id;
        }
    }
}