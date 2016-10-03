using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;

namespace Ignite.Features.Behaviors
{
    public class AccessKeyTooltipBehavior : DependencyObject, IBehavior
    {
        public static readonly DependencyProperty AssociatedObjectProperty = DependencyProperty.Register(
            "AssociatedObject", typeof (DependencyObject), typeof (AccessKeyTooltipBehavior), new PropertyMetadata(default(DependencyObject)));

        public DependencyObject AssociatedObject
        {
            get { return (DependencyObject) GetValue(AssociatedObjectProperty); }
            set { SetValue(AssociatedObjectProperty, value); }
        }

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;

            var element = associatedObject as UIElement;

            if (element == null)
                return;

            element.AccessKeyDisplayRequested += OnDisplayRequested;
            element.AccessKeyDisplayDismissed += OnDisplayDismissed;
        }
        
        private void OnDisplayRequested(UIElement sender, AccessKeyDisplayRequestedEventArgs args)
        {
            var tooltip = new ToolTip
            {
                Background = new SolidColorBrush(Colors.Black),
                Foreground = new SolidColorBrush(Colors.White),
                Padding = new Thickness(4),
                VerticalOffset = -20,
                Placement = PlacementMode.Bottom,
                Content = sender.AccessKey
            };

            ToolTipService.SetToolTip(sender, tooltip);

            tooltip.IsOpen = true;
        }

        private void OnDisplayDismissed(UIElement sender, AccessKeyDisplayDismissedEventArgs args)
        {
            var tooltip = ToolTipService.GetToolTip(sender) as ToolTip;

            if (tooltip != null)
                tooltip.IsOpen = false;

            ToolTipService.SetToolTip(sender, null);
        }

        public void Detach()
        {
            var element = AssociatedObject as UIElement;

            AssociatedObject = null;

            if (element == null)
                return;

            element.AccessKeyDisplayRequested += OnDisplayRequested;
            element.AccessKeyDisplayDismissed += OnDisplayDismissed;
        }
    }
}
