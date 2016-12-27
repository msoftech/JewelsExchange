using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Agree : UIViewController
	{
		//partial void BtnAgree_TouchUpInside(UIButton sender)
		//{
		//	//ViewController_Ins_OTP controller = this.Storyboard.InstantiateViewController("ViewController_Ins_OTP") as ViewController_Ins_OTP;
		//	//this.NavigationController.PushViewController (controller, true);

		//	//UINavigationController ctrl = new UINavigationController();
		//	//ViewController_Ins_Types controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Types") as ViewController_Ins_Types;
		//	//ctrl.PushViewController(controller, true);

		//	//this.PerformSegue("lnk_Types", sender);
		//}

		public ViewController_Ins_Agree() : base("ViewController_Ins_Agree", null)
		{
		}
		public ViewController_Ins_Agree(IntPtr p) : base(p)
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

