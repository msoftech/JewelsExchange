using System;
using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Login : UIViewController
	{
		partial void BtnLogin_TouchUpInside(UIButton sender)
		{

			this.PerformSegue("lnkStock", sender);
		
		}

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

