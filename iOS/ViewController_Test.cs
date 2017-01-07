using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Test : UIViewController
	{
		public ViewController_Test() : base("ViewController_Test", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public ViewController_Test(IntPtr ptr) : base(ptr)
		{
			//initialize();
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

