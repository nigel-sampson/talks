using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Demo.Data;

namespace Demo.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        public StoreViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Categories = new BindableCollection<CategoryViewModel>();
        }

        protected override async void OnInitialize()
        {
            var storeDataSource = new StoreDataSource();
            var categories = await storeDataSource.LoadCategories();

            foreach(var category in categories)
            {
                AssignSizes(category.Products);
            }

            Categories.AddRange(categories);
        }

        public BindableCollection<CategoryViewModel> Categories
        {
            get; private set;
        }

        private void AssignSizes(IList<ProductViewModel> products)
        {
            products[0].Size = TileSize.Large;
            products[1].Size = TileSize.Wide;
            products[2].Size = TileSize.Standard;
            products[3].Size = TileSize.Tall;
            products[4].Size = TileSize.Tall;
            products[5].Size = TileSize.Standard;
        }
    }
}
