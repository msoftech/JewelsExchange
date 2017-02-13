using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;
namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Agree : UIViewController
	{
//UINavigationController navController;
		
		partial void BtnAgree_TouchUpInside(UIButton sender)
		{
			//UINavigationController nav = new UINavigationController();
			//UIWindow window = new UIWindow(UIScreen.MainScreen.Bounds);
			//ViewController_Ins_Types controller = this.Storyboard.InstantiateViewController("ViewController_Ins_Types") as ViewController_Ins_Types;
			//nav.PushViewController(controller, true);
			//window.MakeKeyAndVisible();

			//	UIWindow window = new UIWindow(UIScreen.MainScreen.Bounds);
			//ViewController_Ins_Types	viewController = new ViewController_Ins_Types();
			//	navController = new UINavigationController(viewController);
			//	window.RootViewController = navController;
			//	window.MakeKeyAndVisible();
			NSUserDefaults.StandardUserDefaults.SetString("", "CompanyOTP");
			NSUserDefaults.StandardUserDefaults.SetString("Agree", "CompletedStep");
			this.PerformSegue("CallTypes", sender);

		}

		public ViewController_Ins_Agree() : base("ViewController_Ins_Agree", null)
		{
		}
		public ViewController_Ins_Agree(IntPtr p) : base(p)
		{
		}

	
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

		}
	
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

