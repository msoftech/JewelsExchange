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
		List<ResultJewelry> localModels = new List<ResultJewelry>();

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
			
			TableViewSearch.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);

			TableViewSearch.RowHeight = UITableView.AutomaticDimension;
			TableViewSearch.EstimatedRowHeight = 50;

			TableViewSearch.RowHeight = UITableView.AutomaticDimension;
			TableViewSearch.EstimatedRowHeight = 100;
			TableViewSearch.Source = new TableSource(localModels,this);

			loadData("AF MAN01", 0, 10, "n", false);
		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			viewModel = new WebDataModel<ResultJewelry>();
			InitializeTableView();

		}
	
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

		private void loadData(String LoggedCompanyCode, int StartRow, int EndRow, String closeout, Boolean showProgressMiddle)
		{

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

			TableViewSearch.Source = new TableSource(mModels,this);


				
			TableViewSearch.ReloadData();
			//Add(table);
		}

}


	//--------
	

	public class TableSource : UITableViewSource
	{
		ViewController_StockList owner;
		//public event EventHandler<SongSelectedEventArgs> SongSelected;
		List<ResultJewelry> models;
		string CellIdentifier = "TableCell";



		public TableSource(List<ResultJewelry> models,ViewController_StockList owner)
		{
			this.models = models;
			this.owner = owner;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			//UIAlertController okAlertController = UIAlertController.Create("Row Selected", models[indexPath.Row].JewelBaseDescName , UIAlertControllerStyle.Alert);
			//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			//owner.PresentViewController(okAlertController, true, null);

			var index = indexPath.Row;

			ViewController_StockDetails controller = owner.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
			controller.models  = models;
			controller.indexPath = indexPath;

			//ViewController_StockDetails vs = new ViewController_StockDetails();

			owner.NavigationController.PushViewController(controller,true);

			tableView.DeselectRow(indexPath, true);

			//var handler = SongSelected;
			//if (handler != null)
			//handler(this, new SongSelectedEventArgs(models[indexPath.Row]));

			//var index = indexPath.Row;
			//ViewController_StockDetails vs = new ViewController_StockDetails();
			//vs.sVar1 = "Kannan";
			//vs.StudentName = "Kannansd";

			//tableView1 = tableView;
			//indexPath1 = indexPath;
		

		    //ViewController_StockList vs = new ViewController_StockList();
		    //vs.subloadNavi();
		    //tableView.DeselectRow(indexPath, true);

		    //UIAlertController okAlertController = UIAlertController.Create("Row Selected", models[indexPath.Row].JewelBaseDescName, UIAlertControllerStyle.Alert);
		    //okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));	


		//	//this.selectedIndex = indexPath.Row;
		//	//if (this.ItemSelected != null)
		//	//{
		//	//	this.ItemSelected(this, new EventArgs());
		//	//}

		//	//new UIAlertView("Row Selected", models[indexPath.Row].JewelBaseDescName, null, "OK").Show();
		//	//ViewController_StockList vs = new ViewController_StockList();
		//	//	vs.subloadNavi();

		//		  var index = indexPath.Row;

		//		//var DetailViewController = new ViewController_StockDetails();
		//		//UINavigationController controller = new UINavigationController();
		//		//// Pass the selected object to the new view controller.
		//		//parent.controller.PushViewController(DetailViewController, true);
		//		//parentController.NavigationController.PushViewController(new MyDetailViewController(index));
		//		//UINavigationController nv = new UINavigationController();
		//		//nv.PushViewController(new ViewController_StockDetails(), true)

		//		//ViewController_StockDetails controller = Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
		//		//parent.NavigationController.PushViewController(controller,true);

		//	//try
		//	//{
		//	//	ViewController_StockDetails controller = this.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
		//	//	this.NavigationController.PushViewController(controller, true);
		//	//}
		//	//catch (Exception ex)
		//	//{
		//	//	Console.Write(ex.ToString());
		//	//}
		//	//tableView.DeselectRow(indexPath, true);
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
			cell.UpdateCell(models, UIImage.FromFile("User.png"), indexPath);
			return cell;
		}


	}




}

