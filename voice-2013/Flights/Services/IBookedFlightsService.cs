using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.ViewModels;

namespace Flights.Services
{
    public interface IBookedFlightsService
    {
        Task<IList<FlightViewModel>> GetFlightsAsync();
        Task SetFlightsAsync(IList<FlightViewModel> flights);
    }
}