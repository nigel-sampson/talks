using System.Security.Principal;
using Foundation;
using UIKit;

namespace NDC.Build.App.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var controller = new UIViewController
            {
                View = {BackgroundColor = UIColor.Blue}
            };

            Window.RootViewController = controller;
            
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}


