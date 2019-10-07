using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Demo.Views
{
    public sealed partial class AsyncView
    {
        public AsyncView()
        {
            InitializeComponent();
        }

        private void OnThrowError(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void OnDoWork(object sender, RoutedEventArgs e)
        {
            await DoError();
        }

        private async Task DoError()
        {
            await Task.Delay(100);

            throw new NotSupportedException();
        }

        private async void HandleErrors(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private async void DisplayError(Exception ex)
        {
            var dialog = new MessageDialog(ex.Message, "Unhandled exception in Application!");

            await dialog.ShowAsync();
        }

        private async Task DoWorkItemOne()
        {
            await Task.Delay(4000);

            Log("Work Item One Complete");
        }

        private async Task DoWorkItemTwo()
        {
            await Task.Delay(1000);

            Log("Work Item Two Complete");
        }

        private async void OnDoSequence(object sender, RoutedEventArgs e)
        {
            LogText.Text = String.Empty;

            await DoWorkItemOne();
            await DoWorkItemTwo();

            Log("Sequence Complete");
        }

        private async void OnDoParallel(object sender, RoutedEventArgs e)
        {
            LogText.Text = String.Empty;

            var workItemOne = DoWorkItemOne();
            var workItemTwo = DoWorkItemTwo();

            await Task.WhenAll(workItemOne, workItemTwo);

            Log("Parallel Complete");
        }

        private void Log(string message)
        {
            LogText.Text += message + Environment.NewLine;
        }
    }
}
