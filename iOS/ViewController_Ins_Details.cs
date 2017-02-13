using System;
using Foundation;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Details : UIViewController
	{
		partial void BtnDetailsNext_TouchUpInside(UIButton sender)
		{
			if (txtRetailerName.Text == "")
			{
				Toast.MakeText("Name Should not be empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}

			NSUserDefaults.StandardUserDefaults.SetString("Details", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString(txtRetailerName.Text, "UserName");
			NSUserDefaults.StandardUserDefaults.SetString("", "ContactPerson");
			string Gender ="";
			if (rbGender.SelectedSegment == 0)
			{
				Gender = "Male";
			}
			else
			{
				Gender = "Female";
			}
			NSUserDefaults.StandardUserDefaults.SetString(Gender,"UserGender");
			this.PerformSegue("CallRegister", sender);




		}


		public ViewController_Ins_Details() : base("ViewController_Ins_Details", null)
		{
		}


		public ViewController_Ins_Details(IntPtr p) : base(p)
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

