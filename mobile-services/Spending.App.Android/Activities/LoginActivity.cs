using System;
using Android.App;
using Android.OS;
using Com.Lilarcor.Cheeseknife;
using Spending.Core.ViewModels;

namespace Spending.App.Android.Activities
{
    [Activity(Label = "Spending", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        protected override int LayoutResource => Resource.Layout.LoginView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        [InjectOnClick(Resource.Id.MicosoftAccountButton)]
        private void OnLoginMicrosoftAccount(object sender, EventArgs e) => ViewModel.LoginWithMicrosoftAccount();

        [InjectOnClick(Resource.Id.ActiveDirectoryButton)]
        private void OnLoginActiveDirectory(object sender, EventArgs e) => ViewModel.LoginWithActiveDirectory();
    }
}