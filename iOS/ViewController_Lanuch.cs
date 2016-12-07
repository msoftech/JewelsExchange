using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Lanuch : UIViewController
	{
		public ViewController_Lanuch() : base("ViewController_Lanuch", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			try
			{
				var imageView = new UIImageView(UIImage.FromBundle("welcome.jpeg"));
				imageView.Frame = new CoreGraphics.CGRect(10, 30, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);

				View.AddSubview(imageView);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

