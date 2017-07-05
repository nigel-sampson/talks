using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using NDC.Build.App.Droid.Adapters;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.Droid.Activities
{
    [Activity(ParentActivity = typeof(ProjectsActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".ProjectsActivity")]
    public class BuildsActivity : BaseActivity<BuildsViewModel>
    {
        protected override int LayoutResource => Resource.Layout.SimpleListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ViewModel.ProjectId = Intent.GetStringExtra("ProjectId");

            var projectsList = FindViewById<ListView>(Resource.Id.boundList);

            projectsList.Adapter = new BuildsAdapter(this, ViewModel.Builds);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Builds, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.QueueNewBuild:
                    ViewModel.QueueBuild();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}