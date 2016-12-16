using System;

using UIKit;

namespace JewelsExchange.iOS
{
	public partial class GrowRowTableView : UITableViewSource
	{
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			// Initialize table
			TableView.DataSource = new GrowRowTableDataSource(this);
			TableView.Delegate = new GrowRowTableDelegate(this);
			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 40f;
			TableView.ReloadData();
		}
		//WebDataModel<ResultJewelry> viewModel;
		List<ResultJewelry> models;
		string CellIdentifier = "GrowCell";

		public GrowRowTableCell(IntPtr handle) : base (handle)
        {


		}

		public GrowRowTableCell(List<ResultJewelry> models)
		{
			this.models = models;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}

		public string CellID
		{
			get { return "GrowCell"; }
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			//string item = models[indexPath.Row].JewelBaseDescName; //TableItems[indexPath.Row]
			//cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);

			////cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as GrowRowTableCell;
			//lbltitle.Text = "Kannan";
			//Image.Image = UIImage.FromBundle("User");



			var cell = tableView.DequeueReusableCell(CellID, indexPath) as GrowRowTableCell;
			var item = models[indexPath.Row];

			// Setup
			cell.Image.Image = UIImage.FromBundle("User");
			cell.lbltitle.Text = models[indexPath.Row].JewelBaseDescName;
			//cell.Description = item.Description;


			//UILabel lbl1 = new UILabel(new System.Drawing.RectangleF(100f, 10f, 100, 13f));
			//lbl1.TextColor = UIColor.Gray;
			//lbl1.Font = UIFont.SystemFontOfSize(18);
			//lbl1.Font = UIFont.FromName("Helvetica", 12f);
			//lbl1.Text = "Bangles";


			//UILabel lbl2 = new UILabel(new System.Drawing.RectangleF(100f, 25f, 100, 13f));
			//lbl2.TextColor = UIColor.Gray;
			//lbl2.Font = UIFont.SystemFontOfSize(18);
			//lbl2.Font = UIFont.FromName("Helvetica", 12f);
			//lbl2.Text = "Coimbatore Fancy";

			//UILabel lbl3 = new UILabel(new System.Drawing.RectangleF(100f, 40f, 100, 13f));
			//lbl3.TextColor = UIColor.Orange;
			//lbl3.Font = UIFont.SystemFontOfSize(18);
			//lbl3.Font = UIFont.FromName("Helvetica", 12f);
			//lbl3.Text = "Okachimachi";

			//var imageView = new UIImageView(UIImage.FromBundle("User"));
			//imageView.Frame = new CoreGraphics.CGRect(10, 10, 50, 50);

			//cell.ContentView.AddSubview(lbl1);
			//cell.ContentView.AddSubview(lbl2);
			//cell.ContentView.AddSubview(lbl3);
			//cell.ContentView.AddSubview(imageView);


			//RectangleF rectCell = (System.Drawing.RectangleF)cell.Frame;
			//rectCell.Height = 800;
			//cell.Frame = rectCell;
			//cell.ImageView.Image = UIImage.FromBundle("User");
			//cell = ccell;



			//cell.TextLabel.Text = item;
			//cell.DetailTextLabel.Text = models[indexPath.Row].StockNumber;// tableItems[indexPath.Row].SubHeading;
			//cell.ImageView.Image = UIImage.FromBundle("User");// UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageName);

			return cell;
		}


	}
}

