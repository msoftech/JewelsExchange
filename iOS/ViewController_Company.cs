using System;
using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Company : UIViewController
	{
		

		public ViewController_Company() : base("ViewController_Company", null)
		{
		}
		public ViewController_Company(IntPtr p) : base(p)
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

