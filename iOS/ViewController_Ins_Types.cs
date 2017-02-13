using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Foundation;
using JewelsExchange.Webservices;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Types : UIViewController
	{
		WebDataModel<VerifyOTP> objWSReSent = new WebDataModel<VerifyOTP>();
		WebDataModel<CHKCompOTP> objWSChkCompData = new WebDataModel<CHKCompOTP>();
		public string DeviceId = "";
		private string GetDeviceIdInternal()
		{
			var id = default(string);
			id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			return id;
		}




		partial void Btnnexttype_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetBool(true, "LoggedIn");
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
			if (txtCompanyEmailID.Text == "")
			{
				Toast.MakeText("Company Registered Email ID Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			if (txtComplayMobileNo.Text == "")
			{
				Toast.MakeText("Company Registered Mobile No. Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}


			NSUserDefaults.StandardUserDefaults.SetString("", "UserPhoneCode");
			NSUserDefaults.StandardUserDefaults.SetString(txtComplayMobileNo.Text, "UserPhoneNumber");
			NSUserDefaults.StandardUserDefaults.SetString(txtCompanyEmailID.Text, "UserEmailID");
			NSUserDefaults.StandardUserDefaults.SetString("WholeSaleUser1", "UserType");
			LoadChkCompanyData();
			//this.PerformSegue("CallUserCreation", sender);
		}


		private void LoadChkCompanyData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{

			var urlParam = new Dictionary<string, string>();
		
			urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());
			urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());
			urlParam.Add("@OTPID", DeviceId );
			objWSChkCompData.GetWebDataTask(resultChkCompanyData, _webFunction.GET_Save_ChkCompData, urlParam);
		}



		void resultChkCompanyData(ObservableCollection<CHKCompOTP> wDatas)
		{
			NSObject sender = new NSObject();
			//this.PerformSegue("CallUserCreation", sender);
			string res = "";
			if (wDatas[0].Result != null)
			{
				res = wDatas[0].Result.ToString();
			}
			else
			{
				res = "Valid User";
			}
			if (res == "Invalid User")
				{
					Toast.MakeText("Registered EmailID and PhoneNo. Invalid.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
					return;
				}
			else
				{
				res = wDatas[0].RandomNumber.ToString();
					//NSUserDefaults.StandardUserDefaults.SetString("OTP", "CompletedStep");
				 NSUserDefaults.StandardUserDefaults.SetString(res, "CompanyUserOTP");
					this.PerformSegue("CallCompUserOTP", sender);
				}
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
			DeviceId = GetDeviceIdInternal();
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

