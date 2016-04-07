using System;
using System.Collections.Specialized;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;

namespace Spending.App.Android.Adapters
{
    public abstract class BindableCollectionAdapter<T> : BaseAdapter<T>
    {
        private readonly BindableCollection<T> items;

        protected BindableCollectionAdapter(BindableCollection<T> items)
        {
            this.items = items;

            items.CollectionChanged += OnBoundCollectionChanged;
        }

        private void OnBoundCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }

        public override long GetItemId(int position)
        {
            return GetItemId(items[position]);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }

        public override int Count => items.Count;

        public override T this[int position] => items[position];

        protected abstract long GetItemId(T item);
    }
}