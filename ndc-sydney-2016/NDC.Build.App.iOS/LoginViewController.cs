using System;
using NDC.Build.App.iOS.ViewControllers;
using NDC.Build.Core.ViewModels;
using Praeclarum.Bind;

namespace NDC.Build.App.iOS
{
    public partial class LoginViewController : UIViewControllerBase<LoginViewModel>
    {
        public LoginViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Login.TouchUpInside += (s, e) => ViewModel.Login();

            Binding.Create(() => Account.Text == ViewModel.Account);
            Binding.Create(() => Token.Text == ViewModel.Token);
            Binding.Create(() => Login.Enabled == ViewModel.CanLogin);
            Binding.Create(() => Message.Text == ViewModel.Message);
        }
    }
}