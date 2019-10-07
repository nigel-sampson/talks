using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TechEd.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TechEd.Views
{
    public sealed partial class MainView
    {
        private readonly ISearchService searchService = new Channel9SearchService();
        public MainView()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ApplicationSettings.InitialQuery))
                return;

            await SearchAsync(ApplicationSettings.InitialQuery);
        }

        private async void OnSuggestionsRequested(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args)
        {
            if (args.QueryText.Length <= 3)
                return;

            var deferral = args.Request.GetDeferral();

            var results = await searchService.SearchAsync(args.QueryText);

            foreach(var result in results.Take(5))
            {
                IRandomAccessStreamReference image = null;

                if (result.HasSmallThumbnail)
                    image = RandomAccessStreamReference.CreateFromUri(new Uri(result.SmallThumbnail, UriKind.Absolute));
                else
                    image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///resources/images/mm_50x50.scale-100.jpg"));

                args.Request.SearchSuggestionCollection.AppendResultSuggestion(
                    result.Title,
                    result.Authors,
                    result.ItemLink,
                    image,
                    result.Title);
            }

            deferral.Complete();
        }

        private void OnResultChosen(SearchBox sender, SearchBoxResultSuggestionChosenEventArgs args)
        {
            var result = searchService.GetResult(args.Tag);

            Frame.Navigate(typeof(DetailsView), result);
        }

        private async void OnQuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            await SearchAsync(args.QueryText);
        }

        private async Task SearchAsync(string queryText)
        {
            SearchProgress.IsActive = true;

            var results = await searchService.SearchAsync(queryText);

            SearchProgress.IsActive = false;

            SearchResultsList.ItemsSource = results;
        }

        private void OnResultTapped(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(DetailsView), e.ClickedItem);
        }
    }
}
