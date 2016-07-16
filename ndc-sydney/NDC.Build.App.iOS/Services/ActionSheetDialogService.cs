using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NDC.Build.Core.Services;
using UIKit;

namespace NDC.Build.App.iOS.Services
{
    public class ActionSheetDialogService : IDialogService
    {
        public Task<T> ShowSelectionDialogAsync<T>(string title, string header, IEnumerable<T> options)
        {
            var taskSource = new TaskCompletionSource<T>();

            var actionSheet = UIAlertController.Create(title, header, UIAlertControllerStyle.ActionSheet);

            foreach (var option in options)
            {
                actionSheet.AddAction(UIAlertAction.Create(option.ToString(), UIAlertActionStyle.Default, a => taskSource.SetResult(option)));
            }

            actionSheet.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, a => taskSource.SetResult(default(T))));

            var controller = GetCurrentController();

            controller.PresentViewController(actionSheet, true, null);

            return taskSource.Task;
        }

        private static UIViewController GetCurrentController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var controller = window.RootViewController;

            while (controller.PresentedViewController != null)
            {
                controller = controller.PresentedViewController;
            }

            return controller;
        }
    }
}
