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
    [Register ("ViewController_Ins_OTP")]
    partial class ViewController_Ins_OTP
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnOTPVerify { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtOTP { get; set; }

        [Action ("BtnOTPVerify_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnOTPVerify_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnOTPVerify != null) {
                btnOTPVerify.Dispose ();
                btnOTPVerify = null;
            }

            if (txtOTP != null) {
                txtOTP.Dispose ();
                txtOTP = null;
            }
        }
    }
}