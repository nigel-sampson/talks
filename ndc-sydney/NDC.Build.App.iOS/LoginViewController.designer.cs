// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NDC.Build.App.iOS
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Account { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Login { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Message { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Token { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Account != null) {
                Account.Dispose ();
                Account = null;
            }

            if (Login != null) {
                Login.Dispose ();
                Login = null;
            }

            if (Message != null) {
                Message.Dispose ();
                Message = null;
            }

            if (Token != null) {
                Token.Dispose ();
                Token = null;
            }
        }
    }
}