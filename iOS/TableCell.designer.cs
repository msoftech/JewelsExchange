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
    [Register ("TableCell")]
    partial class TableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView img_profile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_Details { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (img_profile != null) {
                img_profile.Dispose ();
                img_profile = null;
            }

            if (lbl_Details != null) {
                lbl_Details.Dispose ();
                lbl_Details = null;
            }

            if (lbl_name != null) {
                lbl_name.Dispose ();
                lbl_name = null;
            }
        }
    }
}