using System;
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;
using System.Windows.Input;

namespace JewelsExchange.iOS
{
	public partial class ViewController : UIViewController
	{
		//int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			try
			{
				var imageView = new UIImageView(UIImage.FromBundle("welcome.jpeg"));
				imageView.Frame = new CoreGraphics.CGRect(10, 30,imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);

				View.AddSubview(imageView);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			//UIImage image = UIImage.FromBundle("Images/test_icon.png");
			//// image is null
			//this.SetImage(image, UIControlState.Normal);
			//ex.ToString()	"System.ArgumentNullException: Value cannot be null.\nParameter name: image\n  at UIKit.UIImageView..ctor (UIKit.UIImage image) [0x00016] in /Users/builder/data/lanes/3969/44931ae8/source/xamarin-macios/src/build/ios/native/UIKit/UIImageView.g.cs:104 \n  at JewelsExchange.iOS.ViewController.ViewDidLoad () [0x00012] in /Users/shiddic/Projects/msoftech/JewelsExchange.git/iOS/ViewController.cs:23 "	string//ex.ToString()	"System.ArgumentNullException: Value cannot be null.\nParameter name: image\n  at UIKit.UIImageView..ctor (UIKit.UIImage image) [0x00016] in /Users/builder/data/lanes/3969/44931ae8/source/xamarin-macios/src/build/ios/native/UIKit/UIImageView.g.cs:104 \n  at JewelsExchange.iOS.ViewController.ViewDidLoad () [0x00012] in /Users/shiddic/Projects/msoftech/JewelsExchange.git/iOS/ViewController.cs:23 "	string
			//ex.ToString()	"System.ArgumentNullException: Value cannot be null.\nParameter name: image\n  at UIKit.UIImageView..ctor (UIKit.UIImage image) [0x00016] in /Users/builder/data/lanes/3969/44931ae8/source/xamarin-macios/src/build/ios/native/UIKit/UIImageView.g.cs:104 \n  at JewelsExchange.iOS.ViewController.ViewDidLoad () [0x00012] in /Users/shiddic/Projects/msoftech/JewelsExchange.git/iOS/ViewController.cs:23 "	string
			//Tittle
			//UILabel lblTittle = new UILabel(new CGRect(10, 60, 300, 40)); 
			//lblTittle.Text = "Jewels Exchange";
			////lblTittle.TextColor = UIColor.White;
			//lblTittle.TextAlignment = UITextAlignment.Center;
			//lblTittle.AdjustsFontSizeToFitWidth = true;
			//lblTittle.Font = UIFont.FromName("Helvetica-Bold", 30f);
			//lblTittle.MinimumFontSize = 12f; // never gets smaller than this size
			//lblTittle.LineBreakMode = UILineBreakMode.TailTruncation;
			//lblTittle.Lines = 1; // 0 means unlimited
			//View.AddSubview(lblTittle);

			//Email Tittle
			UILabel lblEmail = new UILabel(new CGRect(20, 150, 100, 12));
			lblEmail.Text = "Email";
			lblEmail.TextColor = UIColor.Gray ;
			lblEmail.TextAlignment = UITextAlignment.Left;
			lblEmail.AdjustsFontSizeToFitWidth = true;
			lblEmail.Font = UIFont.FromName("Helvetica-Bold", 10f);
			//lblTittle.MinimumFontSize = 12f; // never gets smaller than this size
			//lblEmail.LineBreakMode = UILineBreakMode.TailTruncation;
			//lblEmail.Lines = 1; // 0 means unlimited
			View.AddSubview(lblEmail);

			UITextField txtEmailID = new UITextField(new CoreGraphics.CGRect(20, 170, 270, 30));
			txtEmailID.BorderStyle = UITextBorderStyle.RoundedRect;
			txtEmailID.Font = UIFont.FromName("Helvetica-Bold", 12f);
			//txtEmailID.TextColor  = UIColor.Gray ;
			//txtEmailID.BackgroundColor = UIColor.Black;
			txtEmailID.Placeholder = "Enter the Email ID";
			txtEmailID.Text = "";
			View.AddSubview(txtEmailID);

			//Email Tittle
			UILabel lblPassword = new UILabel(new CGRect(20, 210, 100, 12));
			lblPassword.Text = "Password";
			lblPassword.TextColor = UIColor.Gray ;
			lblPassword.TextAlignment = UITextAlignment.Left;
			lblPassword.AdjustsFontSizeToFitWidth = true;
			lblPassword.Font = UIFont.FromName("Helvetica-Bold", 10f);
			//lblTittle.MinimumFontSize = 12f; // never gets smaller than this size
			//lblEmail.LineBreakMode = UILineBreakMode.TailTruncation;
			//lblEmail.Lines = 1; // 0 means unlimited
			View.AddSubview(lblPassword);


			UITextField txtPassword = new UITextField(new CoreGraphics.CGRect(20, 230, 270, 30));
			txtPassword.BorderStyle = UITextBorderStyle.RoundedRect;
			txtPassword.Font = UIFont.FromName("Helvetica-Bold", 12f);
			//txtEmailID.TextColor  = UIColor.Gray ;
			//txtEmailID.BackgroundColor = UIColor.Black;
			txtPassword.Placeholder = "Enter the Password";
			//UITextField * passwordTextField = [[UITextField alloc] initWithFrame: passwordTextFieldFrame];
			txtPassword.SecureTextEntry = true;
			txtPassword.Text = "";
			View.AddSubview(txtPassword);


			UIButton  btnLogin = UIButton.FromType(UIButtonType.RoundedRect);
			btnLogin = new UIButton(new CGRect(20, 310, 270, 30));
			btnLogin.SetTitle("LOGIN", UIControlState.Normal);
			btnLogin.Font = UIFont.FromName("Helvetica-Bold", 12f);
			btnLogin.BackgroundColor = UIColor.Blue;
			btnLogin.TouchUpInside += delegate
			{
				PerformSegue("SignInSegue", this);

				//var title = string.Format("{0} clicks!", count++);
				//Button.SetTitle(title, UIControlState.Normal);

				//LoginViewController* loginController = [[UIStoryboard storyboardWithName: @"MainStoryboard" bundle: nil] instantiateViewControllerWithIdentifier: @"loginController"]; 
				////or the homeController
				//UINavigationController* navController = [[UINavigationController alloc]initWithRootViewController: loginController];
				//self.window.rootViewController = navController;

				//Login* lgn =[[Login alloc]initWithNibName: @"Login" bundle:[NSBundle mainBundle]];
				//[self.navigationController pushViewController: lgn animated: YES];


			


			};
			View.AddSubview(btnLogin);



			UIButton btnSignup = UIButton.FromType(UIButtonType.RoundedRect);
			btnSignup = new UIButton(new CGRect(20, 350, 270, 30));
			btnSignup.SetTitle("SINGUP", UIControlState.Normal);
			btnSignup.Font = UIFont.FromName("Helvetica-Bold", 12f);
			btnSignup.BackgroundColor = UIColor.DarkGray;
			View.AddSubview(btnSignup);

		

			//View.BackgroundColor = UIColor.Black  ;
			// Perform any additional setup after loading the view, typically from a nib.
			//Button.AccessibilityIdentifier = "myButton";
			//Button.TouchUpInside += delegate
			//{
			//	var title = string.Format("{0} clicks!", count++);
			//	Button.SetTitle(title, UIControlState.Normal);
			//};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
