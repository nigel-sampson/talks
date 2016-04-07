using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Caliburn.Micro;
using Com.Lilarcor.Cheeseknife;

namespace Spending.App.Android.Activities
{
    public abstract class BaseActivity<TViewModel> : AppCompatActivity
    {
        public Toolbar Toolbar
        {
            get; set;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ViewModel = (TViewModel) ViewModelLocator.LocateForView(this);

            SetContentView(LayoutResource);

            Cheeseknife.Inject(this);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (Toolbar == null)
                return;

            SetSupportActionBar(Toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            ScreenExtensions.TryActivate(ViewModel);
        }

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }

        protected TViewModel ViewModel { get; private set; }
    }
}