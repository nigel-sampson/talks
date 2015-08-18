using Android.App;
using Android.OS;
using Android.Widget;
using Caliburn.Micro;
using Xamarin.Forms.Platform.Android;

namespace Hubb.Forms.App.Android.Activities
{
    [Activity(Label = "Hubb", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new Core.Application(IoC.Get<SimpleContainer>()));
        }
    }
}

