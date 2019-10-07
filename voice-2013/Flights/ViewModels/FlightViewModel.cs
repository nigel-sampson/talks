using System;
using Caliburn.Micro;

namespace Flights.ViewModels
{
    public class FlightViewModel : PropertyChangedBase
    {
        private CityViewModel _departs;
        private CityViewModel _arrives;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public CityViewModel Departs
        {
            get
            {
                return _departs;
            }
            set
            {
                _departs = value;
                NotifyOfPropertyChange(() => Departs);
            }
        }

        public CityViewModel Arrives
        {
            get
            {
                return _arrives;
            }
            set
            {
                _arrives = value;
                NotifyOfPropertyChange(() => Arrives);
            }
        }
    }
}
