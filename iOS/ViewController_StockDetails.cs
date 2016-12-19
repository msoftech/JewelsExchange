using System;
using System.Collections.Generic;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockDetails : UIViewController
	{
		public string sVar1;
		public string StudentName { get; set; }
		public List<ResultJewelry> models;
	 	public NSIndexPath indexPath;


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
			imgProductImage.Image = UIImage.FromFile("User.png");
			lblDetails.Text = models[indexPath.Row].JewelBaseDescName;
			//lblDetails.Text = sVar1;
			//lblDetails2.Text = StudentName;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

