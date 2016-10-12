using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ignite.Features.Views
{
    public sealed partial class InkingView
    {
        public Symbol TouchWriting = (Symbol)0xED5F;
        public Symbol CalligraphyPen = (Symbol)0xEDFB;

        public InkingView()
        {
            InitializeComponent();
        }

        private void OnToggleTouch(object sender, RoutedEventArgs e)
        {
            Canvas.InkPresenter.InputDeviceTypes = TouchToggle.IsChecked ?? false
                ? CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch
                : CoreInputDeviceTypes.Pen;
        }

        private async void OnOpen(object sender, RoutedEventArgs e)
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".ink");

            var inputFile = await fileOpenPicker.PickSingleFileAsync();
            var inputStream = await inputFile.OpenSequentialReadAsync();

            await Canvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
        }

        private async void OnSave(object sender, RoutedEventArgs e)
        {
            var fileSavePicker = new FileSavePicker();
            fileSavePicker.FileTypeChoices.Add("Ink", new [] { ".ink" });

            var outputFile = await fileSavePicker.PickSaveFileAsync();
            var outputStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite);

            await Canvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);

            Canvas.InkPresenter.StrokeContainer.Clear();
        }
    }
}
