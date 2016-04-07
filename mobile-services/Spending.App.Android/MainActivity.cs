using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace Spending.App.Android
{
    [Activity(Label = "Spending.App.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var clickButton = FindViewById<Button>(Resource.Id.my_button);

            clickButton.Click += (sender, args) =>
            {
                clickButton.Text = String.Format("{0} clicks!", count++);
            };

            var navigationButton = FindViewById<Button>(Resource.Id.nav_button);

            navigationButton.Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(SecondActivity));

                intent.PutExtra("clicks", count);

                StartActivity(intent);
            };
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

        }
    }
}

