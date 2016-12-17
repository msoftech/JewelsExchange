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

namespace JewelsExchange.iOS
{
    [Register ("ViewController_Login")]
    partial class ViewController_Login
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignup { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSeparater { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmailid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPassword { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLogin != null) {
                btnLogin.Dispose ();
                btnLogin = null;
            }

            if (btnSignup != null) {
                btnSignup.Dispose ();
                btnSignup = null;
            }

            if (lblSeparater != null) {
                lblSeparater.Dispose ();
                lblSeparater = null;
            }

            if (txtEmailid != null) {
                txtEmailid.Dispose ();
                txtEmailid = null;
            }

            if (txtPassword != null) {
                txtPassword.Dispose ();
                txtPassword = null;
            }
        }
    }
}