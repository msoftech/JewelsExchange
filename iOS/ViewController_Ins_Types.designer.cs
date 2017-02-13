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
    [Register ("ViewController_Ins_Types")]
    partial class ViewController_Ins_Types
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDiamondJewelry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGoldJewelry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNewCompany { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnnexttype { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnOTPWholeVerify { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRetail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnWholesale { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCompanyEmailID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtComplayMobileNo { get; set; }

        [Action ("BtnDiamondJewelry_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDiamondJewelry_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnGoldJewelry_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnGoldJewelry_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnNewCompany_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnNewCompany_TouchUpInside (UIKit.UIButton sender);

        [Action ("Btnnexttype_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btnnexttype_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnOTPWholeVerify_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnOTPWholeVerify_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnRetail_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnRetail_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnWholesale_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnWholesale_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDiamondJewelry != null) {
                btnDiamondJewelry.Dispose ();
                btnDiamondJewelry = null;
            }

            if (btnGoldJewelry != null) {
                btnGoldJewelry.Dispose ();
                btnGoldJewelry = null;
            }

            if (btnNewCompany != null) {
                btnNewCompany.Dispose ();
                btnNewCompany = null;
            }

            if (btnnexttype != null) {
                btnnexttype.Dispose ();
                btnnexttype = null;
            }

            if (btnOTPWholeVerify != null) {
                btnOTPWholeVerify.Dispose ();
                btnOTPWholeVerify = null;
            }

            if (btnRetail != null) {
                btnRetail.Dispose ();
                btnRetail = null;
            }

            if (btnWholesale != null) {
                btnWholesale.Dispose ();
                btnWholesale = null;
            }

            if (lblMsg != null) {
                lblMsg.Dispose ();
                lblMsg = null;
            }

            if (lblTime != null) {
                lblTime.Dispose ();
                lblTime = null;
            }

            if (txtCompanyEmailID != null) {
                txtCompanyEmailID.Dispose ();
                txtCompanyEmailID = null;
            }

            if (txtComplayMobileNo != null) {
                txtComplayMobileNo.Dispose ();
                txtComplayMobileNo = null;
            }
        }
    }
}