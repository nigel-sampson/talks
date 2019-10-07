using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Flights.Services;
using Flights.ViewModels;
using Windows.Phone.Speech.VoiceCommands;

namespace Flights
{
    public class Bootstrapper : PhoneBootstrapper
    {
        private PhoneContainer container;

        protected override async void Configure()
        {
            container = new PhoneContainer(RootFrame);
            container.RegisterPhoneServices();

            container
                .Singleton<IBookedFlightsService, BookedFlightsService>();

            container
                .PerRequest<MenuViewModel>()
                .PerRequest<FlightSearchViewModel>()
                .PerRequest<BookingsViewModel>();

            await VoiceCommandService.InstallCommandSetsFromFileAsync(new Uri("ms-appx:///resources/commands.xml"));
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
