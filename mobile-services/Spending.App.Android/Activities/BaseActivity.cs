using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
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

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }

        protected TViewModel ViewModel { get; private set; }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:

                    NavUtils.NavigateUpFromSameTask(this);

                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}