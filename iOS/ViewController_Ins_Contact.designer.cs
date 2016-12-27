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
    [Register ("ViewController_Ins_Contact")]
    partial class ViewController_Ins_Contact
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnContactNext { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCountryClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchCountry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewStock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCountryName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmailId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhoneCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhonenumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar txtSearchBar { get; set; }

        [Action ("BtnContactNext_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnContactNext_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnCountryClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCountryClose_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSearchCountry_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearchCountry_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnContactNext != null) {
                btnContactNext.Dispose ();
                btnContactNext = null;
            }

            if (btnCountryClose != null) {
                btnCountryClose.Dispose ();
                btnCountryClose = null;
            }

            if (btnSearchCountry != null) {
                btnSearchCountry.Dispose ();
                btnSearchCountry = null;
            }

            if (pnlSearch != null) {
                pnlSearch.Dispose ();
                pnlSearch = null;
            }

            if (TableViewStock != null) {
                TableViewStock.Dispose ();
                TableViewStock = null;
            }

            if (txtCountryName != null) {
                txtCountryName.Dispose ();
                txtCountryName = null;
            }

            if (txtEmailId != null) {
                txtEmailId.Dispose ();
                txtEmailId = null;
            }

            if (txtPhoneCode != null) {
                txtPhoneCode.Dispose ();
                txtPhoneCode = null;
            }

            if (txtPhonenumber != null) {
                txtPhonenumber.Dispose ();
                txtPhonenumber = null;
            }

            if (txtSearchBar != null) {
                txtSearchBar.Dispose ();
                txtSearchBar = null;
            }
        }
    }
}