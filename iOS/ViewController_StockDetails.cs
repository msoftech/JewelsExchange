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
			lblStock .Text = models[indexPath.Row].JewelBaseDescName;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

