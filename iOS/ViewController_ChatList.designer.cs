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
    [Register ("ViewController_ChatList")]
    partial class ViewController_ChatList
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnIDSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSendChatRequest { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblJewelXchangeID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblQuickBoxID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem mnuStockMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView pnlChatRequest { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TVChatRequest { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCompanyName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtContactName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmailID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtJewelsExchangeID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtType { get; set; }

        [Action ("BtnIDSearch_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnIDSearch_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnSendChatRequest_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSendChatRequest_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton12884_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton12884_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnIDSearch != null) {
                btnIDSearch.Dispose ();
                btnIDSearch = null;
            }

            if (btnMenu != null) {
                btnMenu.Dispose ();
                btnMenu = null;
            }

            if (btnSendChatRequest != null) {
                btnSendChatRequest.Dispose ();
                btnSendChatRequest = null;
            }

            if (lblJewelXchangeID != null) {
                lblJewelXchangeID.Dispose ();
                lblJewelXchangeID = null;
            }

            if (lblQuickBoxID != null) {
                lblQuickBoxID.Dispose ();
                lblQuickBoxID = null;
            }

            if (mnuStockMenu != null) {
                mnuStockMenu.Dispose ();
                mnuStockMenu = null;
            }

            if (pnlChatRequest != null) {
                pnlChatRequest.Dispose ();
                pnlChatRequest = null;
            }

            if (TVChatRequest != null) {
                TVChatRequest.Dispose ();
                TVChatRequest = null;
            }

            if (txtCompanyName != null) {
                txtCompanyName.Dispose ();
                txtCompanyName = null;
            }

            if (txtContactName != null) {
                txtContactName.Dispose ();
                txtContactName = null;
            }

            if (txtEmailID != null) {
                txtEmailID.Dispose ();
                txtEmailID = null;
            }

            if (txtJewelsExchangeID != null) {
                txtJewelsExchangeID.Dispose ();
                txtJewelsExchangeID = null;
            }

            if (txtPhone != null) {
                txtPhone.Dispose ();
                txtPhone = null;
            }

            if (txtType != null) {
                txtType.Dispose ();
                txtType = null;
            }
        }
    }
}