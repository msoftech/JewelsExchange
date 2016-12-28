using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_OTP : UIViewController
	{
		
		partial void BtnResent_TouchUpInside(UIButton sender)
		{
			LoadRegionData("");
		}

		

		WebDataModel<VerifyOTP> objWSRegion = new WebDataModel<VerifyOTP>();
		public string DeviceId { get { return GetDeviceIdInternal(); } }
		private string GetDeviceIdInternal()
		{
			var id = default(string);
			id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			return id;
		}


		private int _duration = 0;
		bool _GameInProgress = true;
		int iMint = 2;
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
			LoadRegionData(txtOTP.Text);
		}
		private void LoadRegionData(string sOTP)//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@EmailId", "kannan@msoftech.com");
			urlParam.Add("@PhoneNumber", "919698761859");
			urlParam.Add("@OTPID", DeviceId);
			urlParam.Add("@OTP", sOTP);
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_OTP, urlParam);
		}

		void resultRegionCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
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

