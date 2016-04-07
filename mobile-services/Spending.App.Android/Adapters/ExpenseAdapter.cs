using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using Spending.Core.ViewModels;

namespace Spending.App.Android.Adapters
{
    public class ExpenseAdapter : BindableCollectionAdapter<ExpenseItemViewModel>
    {
        private readonly Activity activity;

        public ExpenseAdapter(Activity activity, BindableCollection<ExpenseItemViewModel> items)
            : base(items)
        {
            this.activity = activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ??
                       activity.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);

            var expenseItem = this[position];

            view.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = expenseItem.Amount;
            view.FindViewById<TextView>(global::Android.Resource.Id.Text2).Text = expenseItem.Occurred;

            return view;
        }

        protected override long GetItemId(ExpenseItemViewModel item)
        {
            return item.GetHashCode();
        }
    }
}