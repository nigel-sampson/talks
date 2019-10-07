using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Flights.Services;
using Windows.Phone.Speech.Recognition;
using Windows.Phone.Speech.Synthesis;
using Windows.Phone.Speech.VoiceCommands;

namespace Flights.ViewModels
{
    public class FlightSearchViewModel : Screen
    {
        private readonly INavigationService navigationService;
        private readonly IBookedFlightsService bookedFlightsService;
        private CityViewModel selectedDeparture;
        private CityViewModel selectedArrival;

        public FlightSearchViewModel(INavigationService navigationService, IBookedFlightsService bookedFlightsService)
        {
            this.navigationService = navigationService;
            this.bookedFlightsService = bookedFlightsService;

            Departs = new BindableCollection<CityViewModel>(CityViewModel.GetCities());
            Arrives = new BindableCollection<CityViewModel>(CityViewModel.GetCities());
            Flights = new BindableCollection<FlightViewModel>();

            SelectedDeparture = Departs[0];
            SelectedArrival = Arrives[1];
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            if (VoiceCommandName == "Search")
            {
                SelectedArrival = Arrives.Single(c => c.Name == ArrivesCity);
                SelectedDeparture = Departs.Single(c => c.Name == DepartsCity);

                Search();
            }
        }

        public void Search()
        {
            Flights.Clear();

            var flights = Enumerable.Range(0, 10)
                .Select(i => new FlightViewModel
                    {
                        Arrives = SelectedArrival, 
                        Departs = SelectedDeparture, 
                        Name = String.Format("METRO {0}", i)
                    });

            Flights.AddRange(flights);
        }

        public async void UseVoice()
        {
            var searchUI = new SpeechRecognizerUI();

            searchUI.Recognizer.Grammars.AddGrammarFromUri("search", new Uri("ms-appx:///resources/grammar.xml"));

            searchUI.Settings.ListenText = "Search for?";
            searchUI.Settings.ExampleText = "Show flights from Auckland to Wellington";

            var searchResult = await searchUI.RecognizeWithUIAsync();

            if (searchResult.ResultStatus == SpeechRecognitionUIStatus.Succeeded
                && searchResult.RecognitionResult.TextConfidence != SpeechRecognitionConfidence.Rejected)
            {
                SelectedArrival = Arrives.Single(c => c.Name == (string) searchResult.RecognitionResult.Semantics["arrives"].Value);
                SelectedDeparture = Departs.Single(c => c.Name == (string) searchResult.RecognitionResult.Semantics["departs"].Value);

                Search();
            }
        }

        public CityViewModel SelectedDeparture
        {
            get
            {
                return selectedDeparture;
            }
            set
            {
                selectedDeparture = value;
                NotifyOfPropertyChange(() => SelectedDeparture);
            }
        }

        public CityViewModel SelectedArrival
        {
            get
            {
                return selectedArrival;
            }
            set
            {
                selectedArrival = value;
                NotifyOfPropertyChange(() => SelectedArrival);
            }
        }

        public async void SelectFlight(FlightViewModel flight)
        {
            var flights = await bookedFlightsService.GetFlightsAsync();

            flights.Add(flight);

            await bookedFlightsService.SetFlightsAsync(flights);

            MessageBox.Show(String.Format("Flight {0} has been booked", flight.Name), "Flight Booked", MessageBoxButton.OK);

            var commandSet = VoiceCommandService.InstalledCommandSets["en-GB"];

            await commandSet.UpdatePhraseListAsync("Booking", flights.Select(f => f.Name));

            navigationService.GoBack();
        }

        public BindableCollection<CityViewModel> Departs
        {
            get; private set;
        }

        public BindableCollection<CityViewModel> Arrives
        {
            get;
            private set;
        }

        public BindableCollection<FlightViewModel> Flights
        {
            get; private set;
        }

        public string VoiceCommandName
        {
            get; set;
        }

        public string DepartsCity
        {
            get; set;
        }

        public string ArrivesCity
        {
            get; set;
        }
    }
}
