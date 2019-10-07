using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TechEd.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TechEd
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(MainView), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            Window.Current.Activate();

            ConfigureSettings();
        }

        private void ConfigureSettings()
        {
            var settingsPane = SettingsPane.GetForCurrentView();

            settingsPane.CommandsRequested += OnSettingsCommandRequested;
        }

        private void OnSettingsCommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand(1, "Options",
                h => OpenSettingsView<OptionsView>()));

            args.Request.ApplicationCommands.Add(new SettingsCommand(2, "Privacy Policy",
                h => OpenSettingsView<PrivacyPolicyView>()));

            args.Request.ApplicationCommands.Add(new SettingsCommand(3, "View Website",
                async h => await Launcher.LaunchUriAsync(new Uri("http://markermetro.com"))));
        }

        private void OpenSettingsView<T>() where T : SettingsFlyout, new()
        {
            var flyout = new T();

            flyout.Show();
        }
    }
}
