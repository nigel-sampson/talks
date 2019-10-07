using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TechEd.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TechEd.Views
{
    public sealed partial class DetailsPrintView : Page
    {
        private SearchResult searchResult;
        public DetailsPrintView()
        {
            InitializeComponent();
        }

        public void Initialise(SearchResult result)
        {
            searchResult = result;

            DataContext = searchResult;
        }
    }
}
