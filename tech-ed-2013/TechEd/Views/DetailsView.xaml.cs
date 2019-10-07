using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TechEd.Services;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.Media.PlayTo;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;

namespace TechEd.Views
{
    public sealed partial class DetailsView
    {
        private SearchResult currentResult;
        
        public DetailsView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            currentResult = (SearchResult)e.Parameter;

            DataContext = currentResult;

            BodyWebView.NavigateToString(currentResult.BodyDocument);

            var transferManager = DataTransferManager.GetForCurrentView();
            var playToManager = PlayToManager.GetForCurrentView();
            var printManager = PrintManager.GetForCurrentView();

            transferManager.DataRequested += OnDataRequested;
            playToManager.SourceRequested += OnSourceRequested;
            printManager.PrintTaskRequested += OnPrintRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var transferManager = DataTransferManager.GetForCurrentView();
            var playToManager = PlayToManager.GetForCurrentView();
            var printManager = PrintManager.GetForCurrentView();

            transferManager.DataRequested -= OnDataRequested;
            playToManager.SourceRequested -= OnSourceRequested;
            printManager.PrintTaskRequested -= OnPrintRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = currentResult.Title;
            args.Request.Data.Properties.Description = currentResult.Authors;

            if (currentResult.HasSmallThumbnail)
            {
                args.Request.Data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromUri(new Uri(currentResult.SmallThumbnail, UriKind.Absolute));
            }

            args.Request.Data.SetWebLink(new Uri(currentResult.ItemLink));
            args.Request.Data.SetHtmlFormat(currentResult.Body);
        }

        private async void OnSourceRequested(PlayToManager sender, PlayToSourceRequestedEventArgs args)
        {
            var deferral = args.SourceRequest.GetDeferral();

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    args.SourceRequest.SetSource(MediaDetails.PlayToSource);
                    
                    deferral.Complete();
                });
        }

        private void OnPrintRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            args.Request.CreatePrintTask(currentResult.Title, async request =>
                {
                    var deferral = request.GetDeferral();

                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            var document = new PrintDocument();

                            document.GetPreviewPage += OnPrintPreview;
                            document.AddPages += OnPrintAddPages;

                            request.SetSource(document.DocumentSource);

                            deferral.Complete();
                        });
                });
        }

        private void OnPrintAddPages(object sender, AddPagesEventArgs e)
        {
            var document = (PrintDocument)sender;

            var printView = new DetailsPrintView();

            printView.Initialise(currentResult);

            printView.InvalidateMeasure();
            printView.UpdateLayout();

            document.AddPage(printView);
            document.AddPagesComplete();
        }

        private void OnPrintPreview(object sender, GetPreviewPageEventArgs e)
        {
            var document = (PrintDocument)sender;

            var printView = new DetailsPrintView();

            printView.Initialise(currentResult);

            printView.InvalidateMeasure();
            printView.UpdateLayout();

            document.SetPreviewPage(e.PageNumber, printView);
        }

        private void OnBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
