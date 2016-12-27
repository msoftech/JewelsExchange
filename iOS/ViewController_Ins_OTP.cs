using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_OTP : UIViewController
	{
		WebDataModel<string> objWSRegion = new WebDataModel<string>();

		partial void BtnOTPVerify_TouchUpInside(UIButton sender)
		{
			LoadRegionData();
		}
		private void LoadRegionData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@EmailId", "kannan@msoftech.com");
			urlParam.Add("@PhoneNumber", "919698761859");
			urlParam.Add("@Otp", txtOTP.Text );
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_OTP, urlParam);
		}

		void resultRegionCompletion(ObservableCollection<string> wDatas)
		{
			string res = wDatas[0].ToString();


		

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
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

