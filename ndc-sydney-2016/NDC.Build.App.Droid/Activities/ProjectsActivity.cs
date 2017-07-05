using System;
using Android.App;
using Android.OS;
using Android.Widget;
using NDC.Build.App.Droid.Adapters;
using NDC.Build.Core.ViewModels;

namespace NDC.Build.App.Droid.Activities
{
    [Activity(ParentActivity = typeof(LoginActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".LoginActivity")]
    public class ProjectsActivity : BaseActivity<ProjectsViewModel>
    {
        protected override int LayoutResource => Resource.Layout.SimpleListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var projectsList = FindViewById<ListView>(Resource.Id.boundList);

            projectsList.Adapter = new ProjectsAdapter(this, ViewModel.Projects);
            projectsList.ItemClick += (s, e) => ViewModel.ViewProject(ViewModel.Projects[e.Position]);
        }
    }
}