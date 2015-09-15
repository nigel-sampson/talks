using System;
using System.ComponentModel;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using Octokit;
using Activity = Android.App.Activity;

namespace Hubb.App.Android.Adapters
{
    public class RepositoryAdapter : BoundAdapter<Repository>
    {
        private readonly Activity activity;

        public RepositoryAdapter(Activity activity, BindableCollection<Repository> items) 
            : base(items)
        {
            this.activity = activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ??
                       activity.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);

            var repository = this[position];

            view.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = repository.Name;
            view.FindViewById<TextView>(global::Android.Resource.Id.Text2).Text = repository.Owner.Login;

            return view;
        }

        protected override long GetItemId(Repository item)
        {
            return item.Id;
        }
    }
}