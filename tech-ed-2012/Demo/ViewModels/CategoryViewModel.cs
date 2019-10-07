using System;
using Caliburn.Micro;

namespace Demo.ViewModels
{
    public class CategoryViewModel : PropertyChangedBase
    {
        private string _name;

        public CategoryViewModel()
        {
            Products = new BindableCollection<ProductViewModel>();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange();
            }
        }

        public BindableCollection<ProductViewModel> Products
        {
            get; private set;
        }
    }
}
