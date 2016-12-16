using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
		private void InitializeTableView()
		{
			//tableView = new UITableView();
			tableView.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			tableView.RowHeight = UITableView.AutomaticDimension;
			tableView.EstimatedRowHeight = 50;
			//var vegtables = LoadVegatables();
			//tableView.Source = new VegetableTableViewSource(vegtables);
			//View.AddSubview(tableView);

			List<ResultJewelry> localModels = new List<ResultJewelry>();
			//localModels.Add(null);
			tableView.RowHeight = UITableView.AutomaticDimension;
			tableView.EstimatedRowHeight = 100;
			tableView.Source = new TableSourceTemp(localModels);

			loadData("AF MAN01", 0, 10, "n", false);
		}
		private void initialize()
		{
			
			//tableView.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			//tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			//tableView.RowHeight = UITableView.AutomaticDimension;
			//tableView.EstimatedRowHeight = 100;
		}
		//public override void ViewWillAppear(bool animated)
		//{
		//	base.ViewWillAppear(animated);
		//}

		//public override void ViewDidAppear(bool animated)
		//{
		//	base.ViewDidAppear(animated);
		//}

		//public override void ViewWillDisappear(bool animated)
		//{
		//	base.ViewWillDisappear(animated);
		//}

		//public override void ViewDidDisappear(bool animated)
		//{
		//	base.ViewDidDisappear(animated);
		//}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			viewModel = new WebDataModel<ResultJewelry>();
			InitializeTableView();

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

		//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		//{
		//}

		//public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		//{
		//	return _prototype.MeasureHeight(tableView, _owner._items[indexPath.Row]);
		//}

		void resultCompletion(ObservableCollection<ResultJewelry> wDatas)
		{
			List<ResultJewelry> mModels = new List<ResultJewelry>(wDatas);
			tableView.Source = new TableSourceTemp(mModels);
			tableView.ReloadData();
		}
	}

	public class TableSourceTemp : UITableViewSource
	{

		List<ResultJewelry> models;
		//Reuse
		//string CellIdentifier = "Reuse";
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

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 80;
		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
			cell.UpdateCell(models, UIImage.FromFile("User.png"),indexPath);
			return cell;

		
		}


	}

	//public class TableViewCustomCell : UITableViewCell
	//{
	//	public UILabel  lbl2;
	//	public UILabel lbl1;
	//	public UILabel lbl3;


	//	public TableViewCustomCell()
	//	{
	//		lbl2 = new UILabel();
	//		lbl1 = new UILabel();
	//		lbl3 = new UILabel();
	//	}

	//	public UITableViewCell GetCellFrame(string v1,string v2,string v3)
	//	{
	//		TableViewCustomCell ccell = new TableViewCustomCell();

	//		lbl2 = new UILabel(new System.Drawing.RectangleF(100f, 10f, 500, 30f));
	//		lbl2.BackgroundColor = UIColor.Red ;


	//		return ccell;
	//	}
	//}
}

