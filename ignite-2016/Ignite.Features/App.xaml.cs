using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Ignite.Features.ViewModels;

namespace Ignite.Features
{
    public sealed partial class App
    {
        private WinRTContainer container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            MessageBinder.SpecialValues.Add("$clickedItem", c => ((ItemClickEventArgs)c.EventArgs).ClickedItem);

            container = new WinRTContainer();
            
            container.RegisterWinRTServices();

            container
                .PerRequest<ShellViewModel>()
                .PerRequest<MediaViewModel>()
                .PerRequest<BackgroundTaskViewModel>()
                .PerRequest<BindingViewModel>()
                .PerRequest<ConnectedAnimationsViewModel>()
                .PerRequest<ControlsViewModel>()
                .PerRequest<DetectionViewModel>()
                .PerRequest<EffectsViewModel>()
                .PerRequest<HoloLensViewModel>()
                .PerRequest<ImplicitAnimationsViewModel>()
                .PerRequest<InkingViewModel>()
                .PerRequest<LinksViewModel>()
                .PerRequest<XboxViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);

            Debug.WriteLine("Background Task Activated");
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
