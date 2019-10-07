using System;
using System.Windows;
using Caliburn.Micro;
using Flights.Services;
using System.Linq;
using System.Threading.Tasks;
using Windows.Phone.Speech.Synthesis;

namespace Flights.ViewModels
{
    public class BookingsViewModel : Screen
    {
        private readonly IBookedFlightsService bookedFlightsService;
        private readonly Random random = new Random();

        public BookingsViewModel(IBookedFlightsService bookedFlightsService)
        {
            this.bookedFlightsService = bookedFlightsService;
            
            Flights = new BindableCollection<FlightViewModel>();
        }

        protected async override void OnInitialize()
        {
            Flights.AddRange(await bookedFlightsService.GetFlightsAsync());

            if (VoiceCommandName == "Status")
            {
                var booking = Flights.First(b => b.Name == Booking);

                SelectFlightAsync(booking, true);
            }
        }

        public void SelectFlight(FlightViewModel flight)
        {
            SelectFlightAsync(flight, false);
        }

        public async Task SelectFlightAsync(FlightViewModel flight, bool speak)
        {
            var statusValue = random.Next(0, 3);
            var status = String.Empty;

            switch (statusValue)
            {
                case 0:
                    status = "on time";
                    break;
                case 1:
                    status = "delayed";
                    break;
                case 2:
                    status = "cancelled";
                    break;
            }

            var message = String.Format("Flight {0} is {1}", flight.Name, status);

            if (speak)
            {
                var speech = new SpeechSynthesizer();

                await speech.SpeakTextAsync(message);
            }
            else
                MessageBox.Show(message, "Flight Status", MessageBoxButton.OK);
        }

        public BindableCollection<FlightViewModel> Flights
        {
            get; private set;
        }

        public string VoiceCommandName
        {
            get; set;
        }

        public string Booking
        {
            get; set;
        }
    }
}
