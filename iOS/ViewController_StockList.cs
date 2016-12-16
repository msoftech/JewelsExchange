using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockList : UIViewController
	{
		WebDataModel<ResultJewelry> viewModel;
		partial void BtnStockDetails_TouchUpInside(UIButton sender)
		{
			try
			{
				ViewController_StockDetails controller = this.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
				this.NavigationController.PushViewController(controller, true);
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
		}




		public ViewController_StockList() : base("ViewController_StockList", null)
		{
		}
		public ViewController_StockList(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
		}

	private void InitializeTableView()
		{
			//tableView = new UITableView();
			TableViewSearch.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			TableViewSearch.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			TableViewSearch.RowHeight = UITableView.AutomaticDimension;
			TableViewSearch.EstimatedRowHeight = 50;
			//var vegtables = LoadVegatables();
			//tableView.Source = new VegetableTableViewSource(vegtables);
			//View.AddSubview(tableView);

			List<ResultJewelry> localModels = new List<ResultJewelry>();
			//localModels.Add(null);
			TableViewSearch.RowHeight = UITableView.AutomaticDimension;
			TableViewSearch.EstimatedRowHeight = 100;
			TableViewSearch.Source = new TableSourceTemp(localModels);

			loadData("AF MAN01", 0, 10, "n", false);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			viewModel = new WebDataModel<ResultJewelry>();
			InitializeTableView();
			//string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			//table.Source = new TableSource(tableItems);
			//Add(table);


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

			TableViewSearch.Source = new TableSource(mModels);
			TableViewSearch.ReloadData();
			//Add(table);
		}


	}

	public class TableSource : UITableViewSource
	{

		List<ResultJewelry> models;
		string CellIdentifier = "TableCell";


		public TableSource(List<ResultJewelry> models)
		{
			this.models = models;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}
		//public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		//{
		//	return 70;
		//}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
			cell.UpdateCell(models, UIImage.FromFile("User.png"), indexPath);
			return cell;
		}


	}
}

