using System;
using Caliburn.Micro;
using NDC.Build.Forms.Core;

namespace NDC.Build.Forms.App.UWP.Views
{
    public sealed partial class HostView
    {
        public HostView()
        {
            InitializeComponent();

            LoadApplication(new Application(IoC.Get<SimpleContainer>()));
        }
    }
}
