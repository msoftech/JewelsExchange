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
    [Register ("ViewController_Ins_Register")]
    partial class ViewController_Ins_Register
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRegiser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bttn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtName { get; set; }

        [Action ("BtnClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnClose_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnRegiser_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnRegiser_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }

            if (btnRegiser != null) {
                btnRegiser.Dispose ();
                btnRegiser = null;
            }

            if (bttn != null) {
                bttn.Dispose ();
                bttn = null;
            }

            if (txtName != null) {
                txtName.Dispose ();
                txtName = null;
            }
        }
    }
}