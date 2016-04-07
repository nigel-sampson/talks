using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace Spending.App.Android
{
    [Activity(Label = "SecondActivity", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class SecondActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get { return Resource.Layout.second; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int count = Intent.GetIntExtra("clicks", 0);
            var text = FindViewById<TextView>(Resource.Id.textView1);
            text.Text = String.Format("You clicked {0} times!", count);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.home:
                    NavUtils.NavigateUpFromSameTask(this);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}