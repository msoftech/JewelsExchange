using System;

using UIKit;
using Foundation;
using CoreGraphics;
using SidebarNavigation;


namespace JewelsExchange.iOS
{
	public partial class ViewController_Stock : UIViewController
	{

		public SidebarNavigation.SidebarController SidebarController { get; private set; }
		public bool bMenuStatus = false;

		partial void BtnMenu_Activated(UIBarButtonItem sender)
		{

			var introController = (ViewController_Stock)Storyboard.InstantiateViewController("ViewController_Stock");
			var menuController = (ViewController_Menu)Storyboard.InstantiateViewController("ViewController_Menu");


			SidebarController = new SidebarNavigation.SidebarController(this, introController, menuController);
			SidebarController.MenuWidth = 220;
			SidebarController.ReopenOnRotate = false;
			SidebarController.MenuLocation = SidebarController.MenuLocations.Left;
			SidebarController.ToggleMenu();
			//if (bMenuStatus == true )
			//{
			//	bMenuStatus = false;
			//	SidebarController.CloseMenu();
			//}
			//else
			//{
			//	bMenuStatus = true;
			//	SidebarController.ToggleMenu();

			//}

		

			//UIAlertView alert = new UIAlertView()
			//{
			//	Title = "alert title",
			//	Message = "this is a simple alert"
			//};
			//alert.AddButton("OK");
			//alert.Show();
		}

		public ViewController_Stock() : base("ViewController_Stock", null)
		{

		}

		public ViewController_Stock(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
		}

		partial void BtnSearch_TouchUpInside(UIButton sender)
		{
			try
			{
				ViewController_StockList controller = this.Storyboard.InstantiateViewController("ViewController_StockList") as ViewController_StockList;
				this.NavigationController.PushViewController(controller, true);
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
		}

	
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();




			//UIAlertView alert = new UIAlertView()
			//{
			//	Title = "alert title",
			//	Message = "this is a simple alert"
			//};
			//alert.AddButton("OK");
			//alert.Show();
			//UIBarButtonItem  customButton = new UIBarButtonItem(
			//   UIImage.FromBundle("Menu5"),
			//   UIBarButtonItemStyle.Plain,
			//   (s, e) =>
			//   {
			//	   UIAlertView alert = new UIAlertView()
			//	   {
			//	   	Title = "alert title",
			//	   	Message = "this is a simple alert"
			//	   };
			//	   alert.AddButton("OK");
			//	   alert.Show();
			//   }
			//   );
			//NavigationItem.RightBarButtonItem = customButton;
			//mnuNavBar.AddSubview(NavigationItem);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

