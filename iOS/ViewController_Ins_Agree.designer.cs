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
    [Register ("ViewController_Ins_Agree")]
    partial class ViewController_Ins_Agree
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAgree { get; set; }

        [Action ("BtnAgree_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAgree_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAgree != null) {
                btnAgree.Dispose ();
                btnAgree = null;
            }
        }
    }
}