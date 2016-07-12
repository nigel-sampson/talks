using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Caliburn.Micro;
using Xamarin.Forms.Platform.Android;

namespace NDC.Build.Forms.App.Droid.Activities
{
    [Activity(Label = "Hello.Forms", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class HostActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new Core.Application(IoC.Get<SimpleContainer>()));
        }
    }
}