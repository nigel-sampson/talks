using System;
using Windows.UI.Xaml.Navigation;

namespace Demo.Views
{
    public sealed partial class SemanticZoomView
    {
        public SemanticZoomView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LanguagesGrid.ItemsSource = LanguagesViewSource.View.CollectionGroups;
        }
    }
}
