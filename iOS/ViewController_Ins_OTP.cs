using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Foundation;
using JewelsExchange.Webservices;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_OTP : UIViewController
	{
		string sCurrentOTP = "";
		partial void BtnWholeOTPVerify_TouchUpInside(UIButton sender)
		{
			this.PerformSegue("CallCompanyThanks", sender);
		}

		private int _duration = 0;
		bool _GameInProgress = true;
		int iMint = 1;

		partial void BtnResent_TouchUpInside(UIButton sender)
		{
			LoadReSendData();
			btnResent.Hidden = true;
			btnOTPVerify.Hidden = false ;
			//iMint = 1;
			//StartTimer();
		}

		

		WebDataModel<VerifyOTP> objWSRegion = new WebDataModel<VerifyOTP>();
		WebDataModel<SentOTP> objWSReSent = new WebDataModel<SentOTP>();

		public string DeviceId = "";// = GetDeviceIdInternal();//"789";// { get { return GetDeviceIdInternal(); } }
		private string GetDeviceIdInternal()
		{
			var id = default(string);
			id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			return id;
		}



		public async void StartTimer()
		{
			_duration = 60;


			// tick every second while game is in progress
			while (_GameInProgress)
			{
				await Task.Delay(1000);
				_duration--;
				if (iMint < 0)
				{
					lblTime.Text = "OTP Expired";
					btnResent.Hidden = false;
					btnOTPVerify.Hidden = true;
					return;
				}
				//string s = TimeSpan.FromSeconds(_duration).ToString(@"mm\:ss");
				lblTime.Text = "Time : " + iMint.ToString("00") + " : " + _duration.ToString("00");
				if (_duration == 0)
				{
					_duration = 60;
					iMint--;


				}
			}
		}



		partial void BtnOTPVerify_TouchUpInside(UIButton sender)
		{
			//this.PerformSegue("CallRegister", sender);
			//btnOTPVerify.Hidden = true;
			if (sCurrentOTP != "")
			{
				if (txtOTP.Text.Trim() == sCurrentOTP)
				{
					LoadRegionData(txtOTP.Text);
				}
				else
				{
					Toast.MakeText("OTP Invalid.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
					return;
				}
			}
			else
			{
				Toast.MakeText("OTP Not Received.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
		}


			//UIWindow windows;
			//windows = new UIWindow(UIScreen.MainScreen.Bounds);

			//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
			////this.NavigationController.PushViewController(controller, true);
			//windows.RootViewController = controller;
			//windows.MakeKeyAndVisible();

			//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
			//this.NavigationController.PresentViewController (controller, true);





		private void LoadRegionData(string sOTP)//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();

			if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "WholeSaleUser")
			{
				urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());//NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString()
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());//
				urlParam.Add("@OTPID", DeviceId);
				urlParam.Add("@OTP",sOTP);
			}
			else if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() != "WholeSale")
			{
				urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());
				urlParam.Add("@OTPID", DeviceId);
				urlParam.Add("@OTP", sOTP);
			}
			else
			{
				urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyEmailID").ToString());
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneNumber").ToString());
				urlParam.Add("@OTPID", DeviceId);
				urlParam.Add("@OTP", sOTP);
			}
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_OTP, urlParam);
		}
		private void LoadReSendData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			
			var urlParam = new Dictionary<string, string>();

			if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "WholeSaleUser")
			{
				urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());//NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString()
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());//
				urlParam.Add("@OTPID", DeviceId);
				urlParam.Add("@OTP", "");
			}
			else if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() != "WholeSale")
			{
				urlParam.Add("@EmailId",NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString() );//NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString()
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());//
				urlParam.Add("@OTPID",DeviceId);
				urlParam.Add("@OTP", "");
			}
			else
			{
				urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyEmailID").ToString());
				urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneNumber").ToString());
				urlParam.Add("@OTPID", DeviceId);
				urlParam.Add("@OTP", "");
			}
			objWSReSent.GetWebDataTask(resultReSendCompletion, _webFunction.GET_OTP, urlParam);
		}



		void resultRegionCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "Valid Otp")
			{
				
				NSObject sender = new NSObject();



				if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "WholeSaleUser" && NSUserDefaults.StandardUserDefaults.StringForKey("CompanyOTP").ToString() == "Yes")
				{
					NSUserDefaults.StandardUserDefaults.SetString("OTP", "CompletedStep");
					NSUserDefaults.StandardUserDefaults.SetString("", "CompanyOTP");
					this.PerformSegue("CallDetails", sender);
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "WholeSaleUser" && NSUserDefaults.StandardUserDefaults.StringForKey("CompanyOTP").ToString() == "")
				{
					NSUserDefaults.StandardUserDefaults.SetString("OTP", "CompletedStep");
					NSUserDefaults.StandardUserDefaults.SetString("Yes", "CompanyOTP");
					this.PerformSegue("CallCompUser", sender);
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() != "WholeSale")
				{
					NSUserDefaults.StandardUserDefaults.SetString("OTP", "CompletedStep");
					this.PerformSegue("CallDetails", sender);
				}
				else
				{
					SaveRetailData();
				}
				//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
				//this.NavigationController.PushViewController(controller, true);
			}
			else
			{
				Toast.MakeText("OTP Timeout.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}



		//NSUserDefaults.StandardUserDefaults.SetString(txtCompanyName.Text, "CompanyName");
		//	NSUserDefaults.StandardUserDefaults.SetString(txtContactPerson.Text, "ContactPerson");

		//	NSUserDefaults.StandardUserDefaults.SetString(txtPhoneCode.Text, "CompanyPhoneCode");
		//	NSUserDefaults.StandardUserDefaults.SetString(txtPhonenumber.Text, "CompanyPhoneNumber");
		//	NSUserDefaults.StandardUserDefaults.SetString(txtEmailId.Text, "CompanyEmailID");


		private void SaveRetailData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyName", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyName").ToString());
			urlParam.Add("@CompanyType", "WholeSaler");
			urlParam.Add("@Phone", "+" + NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("CompanyPhoneNumber").ToString());
			urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyEmailID").ToString());
			urlParam.Add("@FirstName", NSUserDefaults.StandardUserDefaults.StringForKey("ContactPerson").ToString());
			urlParam.Add("@MiddleName", "");
			urlParam.Add("@LastName", "");
			urlParam.Add("@Password", NSUserDefaults.StandardUserDefaults.StringForKey("ContactPerson").ToString());
			urlParam.Add("@JewelXchangeName", NSUserDefaults.StandardUserDefaults.StringForKey("CompanyWholeSaleID").ToString());
			objWSRegion.GetWebDataTask(resultSaveRetailCompletion, _webFunction.GET_Save_Retail, urlParam);
		}

		void resultSaveRetailCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "True")
			{
				NSUserDefaults.StandardUserDefaults.SetString("CompanyRegistered", "CompletedStep");
				//NSUserDefaults.StandardUserDefaults.SetBool(true, "LoggedIn");

				NSObject sender = new NSObject();
				this.PerformSegue("callmsg", sender);
				//this.PerformSegue("CallThanks", sender);
			}
			else
			{
				Toast.MakeText("Jewels Exchange Name Already Exists.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}




		void resultReSendCompletion(ObservableCollection<SentOTP> wDatas)
		{
			sCurrentOTP = wDatas[0].RandomNumber.ToString();
			iMint = 1;
			  StartTimer();
			lblTime.Hidden = false;
		}

		public ViewController_Ins_OTP() : base("ViewController_Ins_OTP", null)
		{
		}

		public ViewController_Ins_OTP(IntPtr p) : base(p)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			lblTime.Hidden = true;
			btnResent.Hidden = true;
			btnOTPVerify.Hidden = false;
			DeviceId = GetDeviceIdInternal();
			if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "WholeSaleUser1")
			{
				sCurrentOTP = NSUserDefaults.StandardUserDefaults.StringForKey("CompanyUserOTP").ToString();
				NSUserDefaults.StandardUserDefaults.SetString("WholeSaleUser", "UserType");
				iMint = 1;
				StartTimer();
				lblTime.Hidden = false;
				//NSUserDefaults.StandardUserDefaults.SetString(res, "CompanyUserOTP");
			}
			else
			{
				LoadReSendData();
			}
			//KK	iMint = 2; 
			//KK	StartTimer(); 
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

