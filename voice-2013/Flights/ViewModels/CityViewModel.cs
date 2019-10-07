using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Flights.ViewModels
{
    public class CityViewModel : PropertyChangedBase
    {
        public static IEnumerable<CityViewModel> GetCities()
        {
            return new[]
                   {
                       new CityViewModel { Id = 1, Name = "Auckland" },
                       new CityViewModel { Id = 2, Name = "Hamilton" },
                       new CityViewModel { Id = 3, Name = "Tauranga" },
                       new CityViewModel { Id = 4, Name = "Wellington" },
                       new CityViewModel { Id = 5, Name = "Nelson" },
                       new CityViewModel { Id = 6, Name = "Christchurch" },
                       new CityViewModel { Id = 7, Name = "Dunedin" }
                   };
        }

        private int id;
        private string name;
        
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    }
}
