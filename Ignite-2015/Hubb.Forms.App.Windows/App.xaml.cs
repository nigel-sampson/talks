using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Hubb.Forms.App.Windows.Views;

namespace Hubb.Forms.App.Windows
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame
                {
                    Language = global::Windows.Globalization.ApplicationLanguages.Languages[0]
                };


                Xamarin.Forms.Forms.Init(e);

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainView), e.Arguments);
            }

            Window.Current.Activate();
        }
    }
}