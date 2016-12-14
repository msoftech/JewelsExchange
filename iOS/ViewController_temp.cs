using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_temp : UIViewController
	{
		WebDataModel<ResultJewelry> viewModel;

		public ViewController_temp() : base("ViewController_temp", null)
		{
		}
		public ViewController_temp(IntPtr ptr) : base(ptr)
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
			viewModel = new WebDataModel<ResultJewelry>();

			List<ResultJewelry> localModels = new List<ResultJewelry>();
			//localModels.Add(null);
			table1.Source = new TableSourceTemp(localModels);
			loadData("AF MAN01", 0, 10, "n", false);
			//string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			//table.Source = new TableSource(tableItems);
			//Add(table);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void loadData(String LoggedCompanyCode, int StartRow, int EndRow, String closeout, Boolean showProgressMiddle)
		{

			//await viewModel.GetWebDataTask("http://montemagno.com/monkeys.json");
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@isCloseOut", closeout);
			urlParam.Add("@StartRow", StartRow.ToString());
			urlParam.Add("@EndRow", EndRow.ToString());

			viewModel.GetWebDataTask(resultCompletion, _webFunction.GET_GOLD_STOCKS, urlParam);
		}


		void resultCompletion(ObservableCollection<ResultJewelry> wDatas)
		{
			List<ResultJewelry> mModels = new List<ResultJewelry>(wDatas);

			table1.Source = new TableSourceTemp(mModels);
			table1.ReloadData();
			//Add(table);
		}
	}

	public class TableSourceTemp : UITableViewSource
	{

		List<ResultJewelry> models;
		string CellIdentifier = "TableCell";
		//string CellIdentifier = "GrowCell";
		//public TableSource(string[] items)
		//{
		//	TableItems = items;
		//}

		public TableSourceTemp(List<ResultJewelry> models)
		{
			this.models = models;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = models[indexPath.Row].JewelBaseDescName; //TableItems[indexPath.Row];


			//if (cell == null)
			//{ 
			//	cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
			//}

			//var cell = tableView.DequeueReusableCell(CellID, indexPath) as GrowRowTableCell;

		
			cell = ccell;



			cell.TextLabel.Text = item;
			cell.DetailTextLabel.Text = models[indexPath.Row].StockNumber;// tableItems[indexPath.Row].SubHeading;
			cell.ImageView.Image = UIImage.FromBundle("User");// UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageName);
															
			return cell;
		}


	}

	public class TableViewCustomCell : UITableViewCell
	{
		public UILabel  lbl2;
		public UILabel lbl1;
		public UILabel lbl3;


		public TableViewCustomCell()
		{
			lbl2 = new UILabel();
			lbl1 = new UILabel();
			lbl3 = new UILabel();
		}

		public UITableViewCell GetCellFrame(string v1,string v2,string v3)
		{
			TableViewCustomCell ccell = new TableViewCustomCell();
			lbl2 = new UILabel(new System.Drawing.RectangleF(100f, 10f, 500, 30f));



			return ccell;
		}
	}
}

