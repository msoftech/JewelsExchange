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
		private int _duration = 0;
		bool _GameInProgress = true;
		int iMint = 1;
		partial void BtnResent_TouchUpInside(UIButton sender)
		{
			
			LoadReSendData();
			iMint = 1;
			StartTimer();
		}

		

		WebDataModel<VerifyOTP> objWSRegion = new WebDataModel<VerifyOTP>();
		WebDataModel<SentOTP> objWSReSent = new WebDataModel<SentOTP>();

		public string DeviceId { get { return GetDeviceIdInternal(); } }
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
			LoadRegionData(txtOTP.Text);
			//UIWindow windows;
			//windows = new UIWindow(UIScreen.MainScreen.Bounds);

			//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
			////this.NavigationController.PushViewController(controller, true);
			//windows.RootViewController = controller;
			//windows.MakeKeyAndVisible();

			//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
			//this.NavigationController.PresentViewController (controller, true);



		}

		private void LoadRegionData(string sOTP)//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());
			urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());
			urlParam.Add("@OTPID", DeviceId);
			urlParam.Add("@OTP", sOTP);
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_OTP, urlParam);
		}
		private void LoadReSendData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@EmailId", NSUserDefaults.StandardUserDefaults.StringForKey("UserEmailID").ToString());
			urlParam.Add("@PhoneNumber", NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneCode").ToString() + NSUserDefaults.StandardUserDefaults.StringForKey("UserPhoneNumber").ToString());
			urlParam.Add("@OTPID", DeviceId);
			urlParam.Add("@OTP", "");
			objWSReSent.GetWebDataTask(resultReSendCompletion, _webFunction.GET_OTP, urlParam);
		}



		void resultRegionCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "Valid Otp")
			{
				NSObject sender = new NSObject();
				NSUserDefaults.StandardUserDefaults.SetString("OTP", "CompletedStep");
				this.PerformSegue("CallDetails", sender);
				//ViewController_Ins_Register controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
				//this.NavigationController.PushViewController(controller, true);
			}
			else
			{
				Toast.MakeText("OTP Invalid.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}

		void resultReSendCompletion(ObservableCollection<SentOTP> wDatas)
		{
			string res = wDatas[0].RandomNumber.ToString();
			iMint = 2;

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
			LoadReSendData();
			StartTimer();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

