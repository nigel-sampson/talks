using Windows.UI.Xaml;

namespace Demo.App.Views
{
    public sealed partial class ShellView
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void OnToggleMenu(object sender, RoutedEventArgs e)
        {
            ShellContent.IsPaneOpen = !ShellContent.IsPaneOpen;
        }
    }
}
