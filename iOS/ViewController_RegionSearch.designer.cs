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
    [Register ("ViewController_RegionSearch")]
    partial class ViewController_RegionSearch
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem mnuStockMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewStock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar txtSearchBar { get; set; }

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnSearch_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearch_TouchUpInside (UIKit.UIButton sender);

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

            if (mnuStockMenu != null) {
                mnuStockMenu.Dispose ();
                mnuStockMenu = null;
            }

            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }

            if (TableViewStock != null) {
                TableViewStock.Dispose ();
                TableViewStock = null;
            }

            if (txtSearchBar != null) {
                txtSearchBar.Dispose ();
                txtSearchBar = null;
            }
        }
    }
}