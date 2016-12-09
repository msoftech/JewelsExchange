using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Stock : UIViewController
	{
		public ViewController_Stock() : base("ViewController_Stock", null)
		{
			
		}
		public ViewController_Stock(IntPtr ptr) : base (ptr)
{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
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
			UIBarButtonItem  customButton = new UIBarButtonItem(
			   UIImage.FromBundle("Menu5"),
			   UIBarButtonItemStyle.Plain,
			   (s, e) =>
			   {
				   UIAlertView alert = new UIAlertView()
				   {
				   	Title = "alert title",
				   	Message = "this is a simple alert"
				   };
				   alert.AddButton("OK");
				   alert.Show();
			   }
			   );
			NavigationItem.RightBarButtonItem = customButton;
			//mnuNavBar.AddSubview(NavigationItem);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

