using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;

namespace Hubb.App.UWP.Interactivity
{
    public class ToggleSplitViewTriggerAction : DependencyObject, IAction
    {
        public static readonly DependencyProperty SplitViewProperty = DependencyProperty.Register(
            "SplitView",
            typeof(SplitView),
            typeof(ToggleSplitViewTriggerAction),
            new PropertyMetadata(null));

        public SplitView SplitView
        {
            get { return (SplitView) GetValue(SplitViewProperty); }
            set { SetValue(SplitViewProperty, value); }
        }

        public object Execute(object sender, object parameter)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;

            return true;
        }
    }
}
