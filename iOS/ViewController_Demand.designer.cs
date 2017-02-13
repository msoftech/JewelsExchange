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
    [Register ("ViewController_Demand")]
    partial class ViewController_Demand
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAttach { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDelete { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPlay { get; set; }

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
        UIKit.UIButton btnSend { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgAttach { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem mnuStockMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView pnlSearch1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl rbBusinessType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewStock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBaseDescription { get; set; }

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
        UIKit.UITextField txtSize { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSpecial { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtStamping { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtStockNo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWorkType { get; set; }


		 [Outlet]
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UISearchDisplayController searchDisplayController { get; set; }


		[Action ("BtnAttach_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAttach_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnDelete_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDelete_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnPlay_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnPlay_TouchUpInside (UIKit.UIButton sender);

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

        [Action ("BtnSend_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSend_TouchUpInside (UIKit.UIButton sender);

        [Action ("TabControl_Selection:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TabControl_Selection (UIKit.UISegmentedControl sender);

        [Action ("UIButton12794_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton12794_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAttach != null) {
                btnAttach.Dispose ();
                btnAttach = null;
            }

            if (btnDelete != null) {
                btnDelete.Dispose ();
                btnDelete = null;
            }

            if (btnPlay != null) {
                btnPlay.Dispose ();
                btnPlay = null;
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
			 if (searchDisplayController != null)
			{
				searchDisplayController.Dispose();
				searchDisplayController = null;
			}
            if (btnSearchWorkType != null) {
                btnSearchWorkType.Dispose ();
                btnSearchWorkType = null;
            }

            if (btnSend != null) {
                btnSend.Dispose ();
                btnSend = null;
            }

            if (imageView != null) {
                imageView.Dispose ();
                imageView = null;
            }

            if (imgAttach != null) {
                imgAttach.Dispose ();
                imgAttach = null;
            }

            if (lblTime1 != null) {
                lblTime1.Dispose ();
                lblTime1 = null;
            }

            if (lblTime2 != null) {
                lblTime2.Dispose ();
                lblTime2 = null;
            }

            if (lblTime3 != null) {
                lblTime3.Dispose ();
                lblTime3 = null;
            }

            if (mnuStockMenu != null) {
                mnuStockMenu.Dispose ();
                mnuStockMenu = null;
            }

            if (pnlSearch != null) {
                pnlSearch.Dispose ();
                pnlSearch = null;
            }

            if (pnlSearch1 != null) {
                pnlSearch1.Dispose ();
                pnlSearch1 = null;
            }

            if (rbBusinessType != null) {
                rbBusinessType.Dispose ();
                rbBusinessType = null;
            }

            if (TableViewStock != null) {
                TableViewStock.Dispose ();
                TableViewStock = null;
            }

            if (txtBaseDescription != null) {
                txtBaseDescription.Dispose ();
                txtBaseDescription = null;
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

            if (txtSize != null) {
                txtSize.Dispose ();
                txtSize = null;
            }

            if (txtSpecial != null) {
                txtSpecial.Dispose ();
                txtSpecial = null;
            }

            if (txtStamping != null) {
                txtStamping.Dispose ();
                txtStamping = null;
            }

            if (txtStockNo != null) {
                txtStockNo.Dispose ();
                txtStockNo = null;
            }

            if (txtWeight != null) {
                txtWeight.Dispose ();
                txtWeight = null;
            }

            if (txtWorkType != null) {
                txtWorkType.Dispose ();
                txtWorkType = null;
            }
        }
    }
}