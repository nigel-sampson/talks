using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Ignite.Features.ViewModels;

namespace Ignite.Features.Views
{
    public sealed partial class ControlsView
    {
        public ControlsView()
        {
            InitializeComponent();
        }

        private ControlsViewModel ViewModel => (ControlsViewModel) DataContext;

        private void OnNumbersShortcut(UIElement sender, AccessKeyInvokedEventArgs args)
        {
            args.Handled = true;

            Numbers.Focus(FocusState.Programmatic);
        }

        private void OnOpen(object sender, RoutedEventArgs e)
        {
            ViewModel.Open();
        }
    }
}
