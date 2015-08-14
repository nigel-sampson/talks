using System;
using Android.App;
using Android.OS;

namespace Hubb.App.Android.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }
    }
}