using System;
using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Types : UIViewController
	{
		partial void BtnWholesale_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("Types", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString("WholeSale", "UserType");
		}//Wholesale


		partial void BtnRetail_TouchUpInside(UIButton sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString("Types", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString("Retails", "UserType");
			this.PerformSegue("CallContact", sender);
			//ViewController_Ins_Contact controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Contact") as ViewController_Ins_Contact;
			//this.NavigationController.PushViewController(controller, true);
		}
	
		public ViewController_Ins_Types() : base("ViewController_Ins_Types", null)
		{
			
		}
		public ViewController_Ins_Types(IntPtr p) : base(p)
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

