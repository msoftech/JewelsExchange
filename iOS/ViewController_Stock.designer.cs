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
    [Register ("ViewController_Stock")]
    partial class ViewController_Stock
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchKarat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchRegion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchWorkType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem mnuStockMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView pnlCloseout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView pnlStock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar SearchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl TabControl { get; set; }

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnSearch_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearch_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchCategory_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchCategory_TouchUpInside (UIKit.UIButton sender);

        [Action ("btnSearchClose_Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnSearchClose_Click (UIKit.UIButton sender);

        [Action ("BtnSearchKarat_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchKarat_TouchUpInside (UIKit.UIButton sender);

        [Action ("btnSearchRegion_Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnSearchRegion_Click (UIKit.UIButton sender);

        [Action ("BtnSearchWorkType_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchWorkType_TouchUpInside (UIKit.UIButton sender);

        [Action ("TabControl_Selection:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TabControl_Selection (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnMenu != null) {
                btnMenu.Dispose ();
                btnMenu = null;
            }

            if (btnSearch != null) {
                btnSearch.Dispose ();
                btnSearch = null;
            }

            if (btnSearchCategory != null) {
                btnSearchCategory.Dispose ();
                btnSearchCategory = null;
            }

            if (btnSearchClose != null) {
                btnSearchClose.Dispose ();
                btnSearchClose = null;
            }

            if (btnSearchKarat != null) {
                btnSearchKarat.Dispose ();
                btnSearchKarat = null;
            }

            if (btnSearchRegion != null) {
                btnSearchRegion.Dispose ();
                btnSearchRegion = null;
            }

            if (btnSearchWorkType != null) {
                btnSearchWorkType.Dispose ();
                btnSearchWorkType = null;
            }

            if (mnuStockMenu != null) {
                mnuStockMenu.Dispose ();
                mnuStockMenu = null;
            }

            if (pnlCloseout != null) {
                pnlCloseout.Dispose ();
                pnlCloseout = null;
            }

            if (pnlSearch != null) {
                pnlSearch.Dispose ();
                pnlSearch = null;
            }

            if (pnlStock != null) {
                pnlStock.Dispose ();
                pnlStock = null;
            }

            if (SearchBar != null) {
                SearchBar.Dispose ();
                SearchBar = null;
            }

            if (TabControl != null) {
                TabControl.Dispose ();
                TabControl = null;
            }
        }
    }
}