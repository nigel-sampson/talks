using System;
using Caliburn.Micro;

namespace Demo.ViewModels
{
    public class ProductViewModel : PropertyChangedBase
    {
        private string _name;
        private string _colour;
        private TileSize _size;

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

        public string Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                _colour = value;
                NotifyOfPropertyChange();
            }
        }

        public TileSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
