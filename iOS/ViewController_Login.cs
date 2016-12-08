using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Login : UIViewController
	{
		public ViewController_Login() : base("ViewController_Main", null)
		{
		}

		public ViewController_Login(IntPtr p) : base(p)
{
		}
		//public ViewController_Login(IntPtr obj)
		//{
		//	Initializer();
		//}
		//public void Initializer()
		//{
			

		//}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			txtEmailid.BackgroundColor = UIColor.Clear;
			txtEmailid.BorderStyle = UITextBorderStyle.None;
			txtEmailid.Font = UIFont.FromName("HollywoodHills", 20f);

			txtPassword.BackgroundColor = UIColor.Clear;
			txtPassword.BorderStyle = UITextBorderStyle.None;
			txtPassword.Font = UIFont.FromName("HollywoodHills", 20f);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}
	}
}

