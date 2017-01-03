using System;
using System.Text.RegularExpressions;
using Foundation;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Types : UIViewController
	{
		partial void Btnnexttype_TouchUpInside(UIButton sender)
		{
			this.PerformSegue("callbType", sender);
		}




		partial void BtnDiamondJewelry_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("DiamondJewelery", "BusinessType");
		}

		partial void BtnGoldJewelry_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("GoldJewelery", "BusinessType");
			this.PerformSegue("callRegionSearch", sender);
		}

		partial void BtnNewCompany_TouchUpInside(UIButton sender)
		{
			this.PerformSegue("CallCompany", sender);
		}

		partial void BtnOTPWholeVerify_TouchUpInside(UIButton sender)
		{
			//if (txtCompanyEmailID.Text == "")
			//{
			//	Toast.MakeText("Email ID Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			//	return;
			//}

			//else if (Regex.Match(txtCompanyEmailID.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success == false)
			//{
			//	Toast.MakeText("Wrong Email ID", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			//	return;
			//}
			//else if (txtComplayMobileNo.Text == "")
			//{

			//	Toast.MakeText("Phone Number Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			//	return;
			//}
			//else if (Regex.IsMatch(txtComplayMobileNo.Text, "[^0-9.-]"))
			//{
			//	Toast.MakeText("Wrong Phone Number.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			//	return;
			//}


			//LoadRegionData();

			//NSUserDefaults.StandardUserDefaults.SetString("Contact", "CompletedStep");
			//NSUserDefaults.StandardUserDefaults.SetString(txtCountryName.Text, "UserContryName");
			NSUserDefaults.StandardUserDefaults.SetString("", "UserPhoneCode");
			NSUserDefaults.StandardUserDefaults.SetString(txtComplayMobileNo.Text, "CompanyPhoneNumber");
			NSUserDefaults.StandardUserDefaults.SetString(txtCompanyEmailID.Text, "CompanyEmailID");

			this.PerformSegue("CallUserCreation", sender);
		}


		partial void BtnWholesale_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("Types", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString("WholeSale", "UserType");
			this.PerformSegue("CallWholeSale", sender);
		}//Wholesale


		partial void BtnRetail_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("Types", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString("Retails", "UserType");
			this.PerformSegue("CallContact", sender);
			//ViewController_Ins_Contact controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Contact") as ViewController_Ins_Contact;
			//this.NavigationController.PushViewController(controller, true);
		}
	
		public ViewController_Ins_Types() : base("ViewController_Ins_Types", null)
		{
			
		}
		public ViewController_Ins_Types(IntPtr p) : base(p)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType") == "WholeSale")
			//{
			//	pnlSearch.Hidden = true;
			//	pnlSearch.Frame = new CoreGraphics.CGRect(0, 50, 320, 518);
			//}
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

