using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Register : UIViewController
	{
		WebDataModel<VerifyOTP> objWSRegion = new WebDataModel<VerifyOTP>();
		partial void BtnRegiser_TouchUpInside(UIButton sender)
		{
			if (txtName.Text == "")
			{
				Toast.MakeText("Jewel Exchange Name is Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			LoadRegionData();		
		}

		private void LoadRegionData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@JewelXchangeName", txtName.Text );
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_CHK_XName, urlParam);
		}


		private void SaveRetailData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyName", "");
			urlParam.Add("@CompanyType", "Retailer");
			urlParam.Add("@Phone", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());
			urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());
			urlParam.Add("@FirstName", NSUserDefaults.StandardUserDefaults.StringForKey("UserName").ToString());
			urlParam.Add("@MiddleName", "");
			urlParam.Add("@LastName", "");
			urlParam.Add("@Password", NSUserDefaults.StandardUserDefaults.StringForKey("UserName").ToString());
			urlParam.Add("@JewelXchangeName", NSUserDefaults.StandardUserDefaults.StringForKey("UserExchangeName").ToString());
			objWSRegion.GetWebDataTask(resultSaveRetailCompletion, _webFunction.GET_Save_Retail, urlParam);
		}

		void resultSaveRetailCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "True")
			{
				NSUserDefaults.StandardUserDefaults.SetString("Registered", "CompletedStep");
				NSUserDefaults.StandardUserDefaults.SetBool(true, "LoggedIn");

				NSObject sender = new NSObject();
				this.PerformSegue("CallThanks", sender);
			}
			else
			{
				Toast.MakeText("Jewels Exchange Name Already Exists.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}


		void resultRegionCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "Valid Name")
			{
				NSUserDefaults.StandardUserDefaults.SetString(txtName.Text, "UserExchangeName");
				SaveRetailData();
				//NSUserDefaults.StandardUserDefaults.SetString("Registered", "CompletedStep");
				//NSUserDefaults.StandardUserDefaults.SetBool(true, "LoggedIn");
				//NSUserDefaults.StandardUserDefaults.SetString(txtName.Text, "UserExchangeName");
				//NSObject sender = new NSObject();
				//this.PerformSegue("CallThanks", sender);
			}
			else
			{
				Toast.MakeText("Jewels Exchange Name Already Exists.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}




		public ViewController_Ins_Register() : base("ViewController_Ins_Register", null)
		{
			
		}
		public ViewController_Ins_Register(IntPtr p) : base(p)
		{
			
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

