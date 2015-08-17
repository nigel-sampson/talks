using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Caliburn.Micro;

namespace Hubb.App.Android.Activities
{
    public abstract class BaseActivity<TViewModel> : AppCompatActivity
    {
        public Toolbar Toolbar
        {
            get;
            set;
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

            ViewModel = (TViewModel) ViewModelLocator.LocateForView(this);

            var viewAware = ViewModel as IViewAware;

            viewAware?.AttachView(this);
        }


        protected override void OnResume()
        {
            base.OnResume();

            var activate = ViewModel as IActivate;

            activate?.Activate();
        }

        protected override void OnPause()
        {
            base.OnPause();

            var deactivate = ViewModel as IDeactivate;

            deactivate?.Deactivate(false);
        }

        protected TViewModel ViewModel { get; private set; }

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }
    }

}