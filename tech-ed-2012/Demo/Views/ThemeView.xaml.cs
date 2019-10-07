using System;
using Windows.UI.Xaml.Navigation;

namespace Demo.Views
{
    public sealed partial class ThemeView
    {
        public ThemeView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var names = new[]
            {
                "Ben Gracewood",
                "Keith Patton",
                "Ian Randall",
                "Nigel Sampson"
            };

            NamesCombo.ItemsSource = names;
            NamesList.ItemsSource = names;
            NamesGrid.ItemsSource = names;
        }
    }
}
