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
    [Register ("ViewController_Ins_Types")]
    partial class ViewController_Ins_Types
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRetail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnWholesale { get; set; }

        [Action ("BtnRetail_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnRetail_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnWholesale_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnWholesale_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnRetail != null) {
                btnRetail.Dispose ();
                btnRetail = null;
            }

            if (btnWholesale != null) {
                btnWholesale.Dispose ();
                btnWholesale = null;
            }
        }
    }
}