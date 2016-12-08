using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class IntroVC : UIViewController
	{
		//public ViewController_Launch() : base("ViewController_Launch", null)
		//{
		//}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var imageView = new UIImageView(UIImage.FromBundle("Back1"));
			imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

