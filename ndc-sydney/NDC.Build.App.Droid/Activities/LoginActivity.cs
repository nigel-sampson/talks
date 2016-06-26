using System;
using Android.App;
using Android.OS;
using Android.Widget;
using NDC.Build.Core.ViewModels;
using Praeclarum.Bind;

namespace NDC.Build.App.Droid.Activities
{
    [Activity(Label = "Builds Browser", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        protected override int LayoutResource => Resource.Layout.LoginView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

            var accountText = FindViewById<EditText>(Resource.Id.account);
            var tokenText = FindViewById<EditText>(Resource.Id.token);
            var loginButton = FindViewById<Button>(Resource.Id.logIn);
            var feedbackText = FindViewById<TextView>(Resource.Id.feedback);

            loginButton.Click += (s, e) => ViewModel.Login();

            Binding.Create(() => accountText.Text == ViewModel.Account);
            Binding.Create(() => tokenText.Text == ViewModel.Token);
            Binding.Create(() => loginButton.Enabled == ViewModel.CanLogin);
            Binding.Create(() => feedbackText.Text == ViewModel.Message);
        }
    }
}