using System;
using Demo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Demo.Selectors
{
    public class StoreStyleSelector : StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var product = (ProductViewModel) item;

            switch (product.Size)
            {
                case TileSize.Standard:
                    return Standard;

                case TileSize.Large:
                    return Large;

                case TileSize.Wide:
                    return Wide;

                case TileSize.Tall:
                    return Tall;

                default:
                    return Standard;
            }
        }

        public Style Standard
        {
            get; set;
        }

        public Style Large
        {
            get;
            set;
        }

        public Style Wide
        {
            get;
            set;
        }

        public Style Tall
        {
            get;
            set;
        }
    }
}
