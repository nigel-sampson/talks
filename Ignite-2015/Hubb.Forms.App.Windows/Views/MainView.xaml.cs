using Caliburn.Micro;
using Hubb.Forms.Core;

namespace Hubb.Forms.App.Windows.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            
            base.LoadApplication(new Application(IoC.Get<SimpleContainer>()));
        }
    }
}
