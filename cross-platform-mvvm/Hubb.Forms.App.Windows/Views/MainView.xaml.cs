using System;
using Caliburn.Micro;

namespace Hubb.Forms.App.Windows.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            Xamarin.Forms.Forms.Init();

            LoadApplication(new Core.Application(IoC.Get<PhoneContainer>()));
        }
    }
}