using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TechEd.Services;
using Windows.ApplicationModel.Search;
using Windows.ApplicationModel.Search.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TechEd.Views
{
    public sealed partial class OptionsView
    {
        public OptionsView()
        {
            InitializeComponent();

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            InitalSearchQuery.Text = ApplicationSettings.InitialQuery;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            ApplicationSettings.InitialQuery = InitalSearchQuery.Text;
        }

        private void OnClearHistory(object sender, RoutedEventArgs e)
        {
            var suggestionManager = new SearchSuggestionManager();

            suggestionManager.ClearHistory();

            Hide();
        }
    }
}
