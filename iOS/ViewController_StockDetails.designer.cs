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
    [Register ("ViewController_StockDetails")]
    partial class ViewController_StockDetails
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnHome { get; set; }

        [Action ("BtnHome_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnHome_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnHome != null) {
                btnHome.Dispose ();
                btnHome = null;
            }
        }
    }
}