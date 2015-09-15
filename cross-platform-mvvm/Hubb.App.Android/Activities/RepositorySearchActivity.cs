using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Hubb.App.Android.Adapters;
using Hubb.Core.ViewModels;
using SearchView = Android.Support.V7.Widget.SearchView;

namespace Hubb.App.Android.Activities
{
    [Activity(Label = "Repository Search")]
    public class RepositorySearchActivity : BaseActivity<RepositorySearchViewModel>
    {
        protected override int LayoutResource => Resource.Layout.RepositorySearchView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var repositoryList = FindViewById<ListView>(Resource.Id.RepositoryList);

            repositoryList.Adapter = new RepositoryAdapter(this, ViewModel.Results);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Main, menu);

            var item = menu.FindItem(Resource.Id.action_search);
            var searchItem = MenuItemCompat.GetActionView(item);

            var searchView = searchItem.JavaCast<SearchView>();

            searchView.QueryTextSubmit += async (s, e) => await ViewModel.Search(e.Query);

            return true;
        }
    }
}