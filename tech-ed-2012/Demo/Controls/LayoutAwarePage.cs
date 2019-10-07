using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Demo.Controls
{
    public class LayoutAwarePage : Page
    {
        private List<Control> _layoutAwareControls;

        public LayoutAwarePage()
        {
            Loaded += StartLayoutUpdates;
            Unloaded += StopLayoutUpdates;
        }

        public void StartLayoutUpdates(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;

            if (control == null)
                return;

            if (_layoutAwareControls == null)
            {
                Window.Current.SizeChanged += WindowSizeChanged;
                _layoutAwareControls = new List<Control>();
            }

            _layoutAwareControls.Add(control);

            VisualStateManager.GoToState(control, DetermineVisualState(ApplicationView.Value), false);
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            InvalidateVisualState();
        }

        public void StopLayoutUpdates(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;

            if (control == null || _layoutAwareControls == null)
                return;

            _layoutAwareControls.Remove(control);

            if (_layoutAwareControls.Count != 0)
                return;

            _layoutAwareControls = null;
            Window.Current.SizeChanged -= WindowSizeChanged;
        }

        protected virtual string DetermineVisualState(ApplicationViewState viewState)
        {
            return viewState.ToString();
        }

        public void InvalidateVisualState()
        {
            if (_layoutAwareControls == null)
                return;

            var visualState = DetermineVisualState(ApplicationView.Value);

            foreach (var layoutAwareControl in _layoutAwareControls)
            {
                VisualStateManager.GoToState(layoutAwareControl, visualState, false);
            }
        }
    }
}
