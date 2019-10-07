using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Flights.ViewModels;
using Newtonsoft.Json;
using Windows.Storage;

namespace Flights.Services
{
    public class BookedFlightsService : IBookedFlightsService
    {
        private class SavedFlight
        {
            public int DepartsId
            {
                get; set;
            }

            public int ArrivesId
            {
                get; set;
            }

            public string Name
            {
                get; set;
            }
        }

        private Task<StorageFile> GetFlightsFile()
        {
            return ApplicationData.Current.LocalFolder.CreateFileAsync("flights.json", CreationCollisionOption.OpenIfExists).AsTask();
        }

        public async Task<IList<FlightViewModel>> GetFlightsAsync()
        {
            var cities = CityViewModel.GetCities().ToList();

            var file = await GetFlightsFile();

            using (var stream = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                var json = await stream.ReadToEndAsync();

                var flights = JsonConvert.DeserializeObject<IList<SavedFlight>>(json) ?? new List<SavedFlight>();

                return flights.Select(f => new FlightViewModel
                    {
                        Name = f.Name,
                        Arrives = cities.Single(c => c.Id == f.ArrivesId),
                        Departs = cities.Single(c => c.Id == f.DepartsId)
                    }).ToList();
            }
        }

        public async Task SetFlightsAsync(IList<FlightViewModel> flights)
        {
            var flightData = flights.Select(f => new SavedFlight
                {
                    Name = f.Name,
                    ArrivesId = f.Arrives.Id,
                    DepartsId = f.Departs.Id
                }).ToList();

            var json = JsonConvert.SerializeObject(flightData);

            var file = await GetFlightsFile();

            using (var stream = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                await stream.WriteLineAsync(json);
            }
        }
    }
}
