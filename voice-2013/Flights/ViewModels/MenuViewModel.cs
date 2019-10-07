using System;
using Caliburn.Micro;
using Windows.Phone.Speech.Recognition;
using Windows.Phone.Speech.Synthesis;

namespace Flights.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly INavigationService navigationService;

        public MenuViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void Search()
        {
            navigationService
                .UriFor<FlightSearchViewModel>()
                .Navigate();
        }

        public void Booked()
        {
            navigationService
                .UriFor<BookingsViewModel>()
                .Navigate();
        }

        public async void UseVoice()
        {
            var speech = new SpeechSynthesizer();

            await speech.SpeakTextAsync("Do you want to search or see your booked flights?");

            var optionsUI = new SpeechRecognizerUI();

            optionsUI.Recognizer.Grammars.AddGrammarFromList("options", new[] { "search", "see booked flights" } );

            optionsUI.Settings.ListenText = "What do you want to do?";
            optionsUI.Settings.ExampleText = "Search, See booked flights";
            optionsUI.Settings.ShowConfirmation = true;
            optionsUI.Settings.ReadoutEnabled = true;

            var optionsResult = await optionsUI.RecognizeWithUIAsync();

            if (optionsResult.ResultStatus == SpeechRecognitionUIStatus.Succeeded
                && optionsResult.RecognitionResult.TextConfidence != SpeechRecognitionConfidence.Rejected)
            {
                if (optionsResult.RecognitionResult.Text == "search")
                    Search();
                else
                    Booked();
            }
        }
    }
}
