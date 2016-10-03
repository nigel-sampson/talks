using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Ignite.Features.Views
{
    public sealed partial class ControlsView
    {
        public ControlsView()
        {
            InitializeComponent();
        }

        private void OnNumbersShortcut(UIElement sender, AccessKeyInvokedEventArgs args)
        {
            args.Handled = true;

            Numbers.Focus(FocusState.Programmatic);
        }
    }
}
