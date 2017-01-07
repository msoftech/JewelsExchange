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
        UIKit.UIButton btnCloseFilter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFilter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFilterDone { get; set; }

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
        UIKit.UIButton btnStockDetails { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlSearchFilter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Process { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewSearch { get; set; }

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
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UISearchDisplayController searchDisplayController { get; set; }

		[Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtRegion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar txtSearchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWorkType { get; set; }

        [Action ("BtnCloseFilter_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCloseFilter_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnFilter_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFilter_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnFilterDone_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFilterDone_TouchUpInside (UIKit.UIButton sender);

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

        [Action ("BtnStockDetails_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnStockDetails_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCloseFilter != null) {
                btnCloseFilter.Dispose ();
                btnCloseFilter = null;
            }

            if (btnFilter != null) {
                btnFilter.Dispose ();
                btnFilter = null;
            }
			  if (searchDisplayController != null)
			{
				searchDisplayController.Dispose();
				searchDisplayController = null;
			}

			if (btnFilterDone != null) {
                btnFilterDone.Dispose ();
                btnFilterDone = null;
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

            if (btnStockDetails != null) {
                btnStockDetails.Dispose ();
                btnStockDetails = null;
            }

            if (pnlSearch != null) {
                pnlSearch.Dispose ();
                pnlSearch = null;
            }

            if (pnlSearchFilter != null) {
                pnlSearchFilter.Dispose ();
                pnlSearchFilter = null;
            }

            if (Process != null) {
                Process.Dispose ();
                Process = null;
            }

            if (TableViewSearch != null) {
                TableViewSearch.Dispose ();
                TableViewSearch = null;
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