using System;
using System.Collections.Specialized;
using Android.Widget;
using Caliburn.Micro;

namespace NDC.Build.App.Droid.Adapters
{
    public abstract class BoundAdapter<T> : BaseAdapter<T>
    {
        private readonly BindableCollection<T> items;

        protected BoundAdapter(BindableCollection<T> items)
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

        public override int Count => items.Count;

        public override T this[int position] => items[position];

        protected abstract long GetItemId(T item);
    }
}