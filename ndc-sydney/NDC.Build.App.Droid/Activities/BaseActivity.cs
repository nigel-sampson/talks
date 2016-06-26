using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Caliburn.Micro;

namespace NDC.Build.App.Droid.Activities
{
    public abstract class BaseActivity<T> : AppCompatActivity
    {
        protected Toolbar Toolbar
        {
            get;
            private set;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(LayoutResource);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            ViewModel = (T) ViewModelLocator.LocateForView(this);

            var viewAware = ViewModel as IViewAware;

            viewAware?.AttachView(this);
        }


        protected override void OnResume()
        {
            base.OnResume();

            ScreenExtensions.TryActivate(ViewModel);
        }

        protected override void OnPause()
        {
            base.OnPause();

            ScreenExtensions.TryDeactivate(ViewModel, false);
        }

        protected T ViewModel { get; private set; }

        protected abstract int LayoutResource
        {
            get;
        }

        //protected int ActionBarIcon
        //{
        //    set { Toolbar.SetNavigationIcon(value); }
        //}
    }
}