using System;
using Caliburn.Micro;
using UIKit;

namespace NDC.Build.App.iOS.ViewControllers
{
    public class UITableViewControllerBase<T> : UITableViewController
    {
        public UITableViewControllerBase()
        {
            SetupViewModel();
        }

        protected internal UITableViewControllerBase(IntPtr handle)
            : base(handle)
        {
            SetupViewModel();
        }

        private void SetupViewModel()
        {
            ViewModel = (T)ViewModelLocator.LocateForView(this);

            var viewAware = ViewModel as IViewAware;

            viewAware?.AttachView(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ScreenExtensions.TryActivate(ViewModel);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ScreenExtensions.TryDeactivate(ViewModel, false);
        }

        protected T ViewModel { get; private set; }
    }
}
