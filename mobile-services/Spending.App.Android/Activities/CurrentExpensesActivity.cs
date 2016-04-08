using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Spending.App.Android.Adapters;
using Spending.Core.ViewModels;

namespace Spending.App.Android.Activities
{
    [Activity(Label = "Expenses")]
    public class CurrentExpensesActivity : BaseActivity<CurrentExpensesViewModel>
    {
        [InjectView(Resource.Id.ExpenseList)]
        private ListView expenseList;

        protected override int LayoutResource => Resource.Layout.CurrentExpensesView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            expenseList.Adapter = new ExpenseAdapter(this, ViewModel.ExpenseItems);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Main, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.AddAction:

                    ViewModel.Add();

                    return true;

                case Resource.Id.PushAction:

                    ViewModel.Push();

                    return true;
                case Resource.Id.PullAction:

                    ViewModel.Pull();

                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}