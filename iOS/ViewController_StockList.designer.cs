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
    [Register ("ViewController_StockList")]
    partial class ViewController_StockList
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnStockDetails { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView table { get; set; }

        [Action ("BtnStockDetails_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnStockDetails_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnStockDetails != null) {
                btnStockDetails.Dispose ();
                btnStockDetails = null;
            }

            if (table != null) {
                table.Dispose ();
                table = null;
            }
        }
    }
}