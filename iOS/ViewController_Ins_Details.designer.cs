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
    [Register ("ViewController_Ins_Details")]
    partial class ViewController_Ins_Details
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDetailsNext { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl rbGender { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtRetailerName { get; set; }

        [Action ("BtnDetailsNext_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDetailsNext_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDetailsNext != null) {
                btnDetailsNext.Dispose ();
                btnDetailsNext = null;
            }

            if (rbGender != null) {
                rbGender.Dispose ();
                rbGender = null;
            }

            if (txtRetailerName != null) {
                txtRetailerName.Dispose ();
                txtRetailerName = null;
            }
        }
    }
}