using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Caliburn.Micro;

namespace Spending.Core.ViewModels
{
    public static class NotifyPropertyChangedExtensions
    {
        public static void OnChanged<TViewModel, TProperty>(this TViewModel viewModel, Expression<Func<TViewModel, TProperty>> propertyExpression, Action<TProperty> onChanged)
            where TViewModel : INotifyPropertyChanged
        {
            var propertyFunction = propertyExpression.Compile();
            var name = propertyExpression.GetMemberInfo().Name;

            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != name)
                    return;

                onChanged(propertyFunction(viewModel));
            };
        }
    }
}
