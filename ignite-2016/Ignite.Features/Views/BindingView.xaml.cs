using System;
using Ignite.Features.ViewModels;

namespace Ignite.Features.Views
{
    public sealed partial class BindingView
    {
        public BindingView()
        {
            InitializeComponent();
        }

        public BindingViewModel ViewModel => DataContext as BindingViewModel;

        public string Format(int value) => value > 10 ? "High Score!" : "Low Score :(";
    }
}
