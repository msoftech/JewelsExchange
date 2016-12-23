using System;
using Foundation;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Login : UIViewController
	{
		partial void BtnLogin_TouchUpInside(UIButton sender)
		{
			//string ss = NSUserDefaults.StandardUserDefaults.StringForKey("UserCode");
			//Toast.MakeText(ss, Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Bottom).SetBgRed(30).Show();

			//NSUserDefaults.StandardUserDefaults.SetString("Kannan", "UserCode");
			//NSUserDefaults.StandardUserDefaults.SetBool(true, "BooleanUniqueKey");
			//NSUserDefaults.StandardUserDefaults.SetInt(100, "IntUniqueKey");


		}

		//  partial void BtnLogin_TouchUpInside(UIButton sender)
		//  {
		//	//this.PerformSegue("lnkStock", sender);
		//	try
		//	{
		//		//ViewController_Stock controller = this.Storyboard.InstantiateViewController("ViewController_Stock") as ViewController_Stock;
		//		//this.NavigationController.PushViewController(controller, true);
		//		UIViewController  controller = this.Storyboard.InstantiateViewController("Navigation") as UIViewController ;
		//		this.NavigationController.PushViewController(controller, true);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.Write(ex.ToString());
		//	}
		//  }


		public ViewController_Login() : base("ViewController_Main", null)
		{
		}

		public ViewController_Login(IntPtr p) : base(p)
		{
		}
	
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			txtEmailid.BackgroundColor = UIColor.Clear;
			txtEmailid.BorderStyle = UITextBorderStyle.RoundedRect ;
			txtEmailid.Font = UIFont.FromName("HollywoodHills", 17f);
			txtEmailid.TextColor = UIColor.White;
			txtEmailid.AttributedPlaceholder = new NSAttributedString("Enter the Email-ID", new UIStringAttributes() { ForegroundColor = UIColor.Gray });
			txtEmailid.Layer.BorderColor = UIColor.White.CGColor;
			txtEmailid.Layer.BorderWidth = 1f;


			txtPassword.BackgroundColor = UIColor.Clear;
			txtPassword.BorderStyle = UITextBorderStyle.RoundedRect;
			txtPassword.Font = UIFont.FromName("HollywoodHills", 17f);
			txtPassword.TextColor = UIColor.White;
			txtPassword.AttributedPlaceholder = new NSAttributedString("Enter the Password", new UIStringAttributes() { ForegroundColor = UIColor.Gray });
			txtPassword.Layer.BorderColor = UIColor.White.CGColor;
			txtPassword.Layer.BorderWidth = 1f;
			txtPassword.SecureTextEntry = true;

			lblSeparater.Frame = new CoreGraphics.CGRect(160, 460, 1.5, 40);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}
	}
}

