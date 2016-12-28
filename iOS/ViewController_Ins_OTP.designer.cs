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
        UIKit.UIButton btnOPTBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnOTPVerify { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnResent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtOTP { get; set; }

        [Action ("BtnOTPVerify_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnOTPVerify_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnResent_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnResent_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnOPTBack != null) {
                btnOPTBack.Dispose ();
                btnOPTBack = null;
            }

            if (btnOTPVerify != null) {
                btnOTPVerify.Dispose ();
                btnOTPVerify = null;
            }

            if (btnResent != null) {
                btnResent.Dispose ();
                btnResent = null;
            }

            if (lblTime != null) {
                lblTime.Dispose ();
                lblTime = null;
            }

            if (txtOTP != null) {
                txtOTP.Dispose ();
                txtOTP = null;
            }
        }
    }
}