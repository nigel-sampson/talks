using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Ignite.Features.Messages;
using Ignite.Features.ViewModels;

namespace Ignite.Features
{
    public sealed partial class App
    {
        private WinRTContainer container;
        private IEventAggregator eventAggregator;

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
                .PerRequest<AnimationsTargetViewModel>()
                .PerRequest<ControlsViewModel>()
                .PerRequest<DetectionViewModel>()
                .PerRequest<EffectsViewModel>()
                .PerRequest<ImplicitAnimationsViewModel>()
                .PerRequest<InkingViewModel>()
                .PerRequest<LinksViewModel>()
                // XY helper, check box to toggle element sounds
                .PerRequest<XboxViewModel>()
                // ???
                .PerRequest<HoloLensViewModel>()
                .PerRequest<WebsiteViewModel>();
            
            // Get better gif
            // Switch wallpaper

            var appView = ApplicationView.GetForCurrentView();
            var coreApp = CoreApplication.GetCurrentView();

            appView.TitleBar.BackgroundColor = Color.FromArgb(255, 30, 30, 30);
            appView.TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 30, 30, 30);
            appView.TitleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 3, 169, 244);
            coreApp.TitleBar.ExtendViewIntoTitleBar = true;

            eventAggregator = container.GetInstance<IEventAggregator>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            if (args.Kind == ActivationKind.Protocol)
            {
                Debug.WriteLine("Protocol Activated");

                eventAggregator.PublishOnCurrentThread(new ProtocolMessage());
            }
        }

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);

            var deferral = args.TaskInstance.GetDeferral();

            Debug.WriteLine("Background Task Activated");

            eventAggregator.PublishOnCurrentThread(new BackgroundTaskMessage());

            deferral.Complete();
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
