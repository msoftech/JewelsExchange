using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Menu : UIViewController
	{
		public ViewController_Menu() : base("ViewController_Menu", null)
		{
		}

		public ViewController_Menu(IntPtr ptr) : base(ptr)
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

