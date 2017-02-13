using System;
using CoreGraphics;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Test : UIViewController
	{
		UIScrollView scrollView;
		UIImageView imageView;

		public ViewController_Test() : base("ViewController_Test", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.Title = "Photo Viewer";
			this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Back"
			, UIBarButtonItemStyle.Plain, (sender, args) =>
			{
				NavigationController.PopViewController(true);
			}), true);
		



			scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height - NavigationController.NavigationBar.Frame.Height));
			View.AddSubview(scrollView);

			imageView = new UIImageView(UIImage.FromFile("Company.png"));
			scrollView.ContentSize = imageView.Image.Size;
			scrollView.AddSubview(imageView);

			scrollView.MaximumZoomScale = 3f;
			scrollView.MinimumZoomScale = .1f;
			scrollView.ViewForZoomingInScrollView += (UIScrollView sv) => { return imageView; };

			UITapGestureRecognizer doubletap = new UITapGestureRecognizer(OnDoubleTap)
			{
				NumberOfTapsRequired = 2 // double tap
			};
			scrollView.AddGestureRecognizer(doubletap);

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

		private void OnDoubleTap(UIGestureRecognizer gesture)
		{
			if (scrollView.ZoomScale >= 1)
				scrollView.SetZoomScale(0.25f, true);
			else
				scrollView.SetZoomScale(2f, true);
		}
	}
}

