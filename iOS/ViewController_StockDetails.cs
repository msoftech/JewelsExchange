using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockDetails : UIViewController
	{
		partial void BtnHome_TouchUpInside(UIButton sender)
		{
		try
			{
				ViewController_temp controller = this.Storyboard.InstantiateViewController("ViewController_temp") as ViewController_temp;
				this.NavigationController.PushViewController(controller, true);
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
		}

		public ViewController_StockDetails() : base("ViewController_StockDetails", null)
		{
		}
		public ViewController_StockDetails(IntPtr ptr) : base(ptr)
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
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

