using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Spending.Core.ViewModels;

namespace Spending.App.Android.Activities
{
    [Activity(Label = "Add Expense", ParentActivity = typeof(CurrentExpensesActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".CurrentExpensesActivity")]
    public class AddExpenseActivity : BaseActivity<AddExpenseViewModel>
    {
        protected override int LayoutResource => Resource.Layout.AddExpenseView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var amount = FindViewById<EditText>(Resource.Id.AmountText);
            var save = FindViewById<Button>(Resource.Id.SaveButton);

            amount.TextChanged += (s, e) => ViewModel.Text = amount.Text;
            save.Click += (s, e) => ViewModel.Save();

            ViewModel.OnChanged(v => v.CanSave, s =>  save.Enabled = s);
        }
    }
}