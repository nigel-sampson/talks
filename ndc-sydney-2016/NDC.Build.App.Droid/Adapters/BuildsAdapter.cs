using System;
using Android.App;
using Android.Graphics;
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
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.BuildView, null);

            var build = this[position];

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = build.Build.Definition.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = build.StartedOn;
            view.FindViewById<View>(Resource.Id.ResultShape).SetBackgroundColor(Color.ParseColor(build.Result));

            view.Alpha = (float)build.Completed;

            return view;
        }

        protected override long GetItemId(BuildViewModel item)
        {
            return item.Build.Id;
        }
    }
}