using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockDetails : UIViewController
	{


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

