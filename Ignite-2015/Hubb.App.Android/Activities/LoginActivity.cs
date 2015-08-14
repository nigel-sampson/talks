using System;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Widget;
using Hubb.Core.ViewModels;

namespace Hubb.App.Android.Activities
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        protected override int LayoutResource => Resource.Layout.Login;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

            var userName = FindViewById<EditText>(Resource.Id.userName);
            var password = FindViewById<EditText>(Resource.Id.password);

            var button = FindViewById<Button>(Resource.Id.signIn);

            var feedback = FindViewById<TextView>(Resource.Id.feedback);

            //button.Click += async (s, e) => await ViewModel.Login();

            //EventHandler<TextChangedEventArgs> toggleSignIn = (s, e) =>
            //{
            //    ViewModel.Username = userName.Text;
            //    ViewModel.Password = password.Text;

            //    button.Enabled = ViewModel.CanLogin;
            //};

            //userName.TextChanged += toggleSignIn;
            //password.TextChanged += toggleSignIn;

            //ViewModel.OnChanged(v => v.Message, () => feedback.Text = ViewModel.Message);
        }
    }
}