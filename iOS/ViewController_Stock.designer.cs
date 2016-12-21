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
        UIKit.UIButton btnSearchDone { get; set; }

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
        UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl TabControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewStock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtKarat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtRegion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar txtSearchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWorkType { get; set; }

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnSearch_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearch_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchCategory_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchCategory_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchClose_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchDone_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchDone_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchKarat_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchKarat_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchRegion_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchRegion_TouchUpInside (UIKit.UIButton sender);

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

            if (btnSearchDone != null) {
                btnSearchDone.Dispose ();
                btnSearchDone = null;
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

            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }

            if (TabControl != null) {
                TabControl.Dispose ();
                TabControl = null;
            }

            if (TableViewStock != null) {
                TableViewStock.Dispose ();
                TableViewStock = null;
            }

            if (txtCategory != null) {
                txtCategory.Dispose ();
                txtCategory = null;
            }

            if (txtKarat != null) {
                txtKarat.Dispose ();
                txtKarat = null;
            }

            if (txtRegion != null) {
                txtRegion.Dispose ();
                txtRegion = null;
            }

            if (txtSearchBar != null) {
                txtSearchBar.Dispose ();
                txtSearchBar = null;
            }

            if (txtWorkType != null) {
                txtWorkType.Dispose ();
                txtWorkType = null;
            }
        }
    }
}