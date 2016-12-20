using System;

using UIKit;
using Foundation;
using CoreGraphics;
using SidebarNavigation;
using JewelsExchange.Webservices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Stock : UIViewController
	{
		partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		{
				pnlSearch.Hidden = false;
				txtSearchBar.Placeholder = sRegionPH;
				loadData("AF MAN01", 0, 10, "n", false);
		}


		//partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		//{
		//	pnlSearch.Hidden = false;
		//	txtSearchBar.Placeholder = sRegionPH;
		//	loadData("AF MAN01", 0, 10, "n", false);
		//}

		const string sRegionPH = "Region Search";
		const string sWorkTypePH = "WorkType Search";
		const string sCategoryPH = "Category Search";
		const string sKaratPH = "Karat Search";

		WebDataModel<ResultJewelry> viewModel;
		//List<ResultJewelry> localModels = new List<ResultJewelry>();
		//List<ResultJewelry> localModelsSearch = new List<ResultJewelry>();
		List<ResultJewelry> localModels;
		List<ResultJewelry> localModelsSearch;

		//TableSourceSearch DataSource = new TableSourceSearch();






		partial void BtnSearchKarat_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sKaratPH;
		}

		partial void BtnSearchCategory_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sCategoryPH;
		}

		partial void BtnSearchWorkType_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sWorkTypePH;
		}


		public void SetSearchData(string sData)
		{
			switch (txtSearchBar.Placeholder)
			{
				case sRegionPH:
					txtRegion.Text = sData;
					txtKarat.Text = "";
					txtCategory.Text = "";
					txtWorkType.Text = "";
					break;
				case sWorkTypePH:
					txtWorkType.Text = sData;
					txtKarat.Text = "";
					txtCategory.Text = "";
					break;
				case sCategoryPH:
					txtCategory.Text = sData;
					txtKarat.Text = "";
					break;
				case sKaratPH:
					txtKarat.Text = sData;
					break;
			}
			pnlSearch.Hidden = true;
		}



		partial void TabControl_Selection(UISegmentedControl sender)
		{
			var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
			if (selectedSegmentId == 0)
			{
				pnlStock.Hidden = false;
				pnlCloseout.Hidden = true;
			}
			else
			{
				pnlStock.Hidden = true;
				pnlCloseout.Hidden = false;
			}
		}

		public SidebarNavigation.SidebarController SidebarController { get; private set; }
		public bool bMenuStatus = false;

		partial void BtnMenu_Activated(UIBarButtonItem sender)
		{

			var introController = (ViewController_Stock)Storyboard.InstantiateViewController("ViewController_Stock");
			var menuController = (ViewController_Menu)Storyboard.InstantiateViewController("ViewController_Menu");


			SidebarController = new SidebarNavigation.SidebarController(this, introController, menuController);
			SidebarController.MenuWidth = 220;
			SidebarController.ReopenOnRotate = false;
			SidebarController.MenuLocation = SidebarController.MenuLocations.Left;
			SidebarController.ToggleMenu();

		}

		public ViewController_Stock() : base("ViewController_Stock", null)
		{

		}

		public ViewController_Stock(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
		}

		partial void BtnSearch_TouchUpInside(UIButton sender)
		{
			try
			{
				ViewController_StockList controller = this.Storyboard.InstantiateViewController("ViewController_StockList") as ViewController_StockList;
				this.NavigationController.PushViewController(controller, true);
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
		}

		private void InitializeTableView()
		{
			TableViewStock.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			TableViewStock.RowHeight = UITableView.AutomaticDimension;
			TableViewStock.EstimatedRowHeight = 50;
			TableViewStock.RowHeight = UITableView.AutomaticDimension;
			TableViewStock.EstimatedRowHeight = 100;
		

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
			localModels = mModels;
			localModelsSearch = mModels;
			TableViewStock.Source  = new TableSourceSearch(this);

			//TableViewStock.Source = new TableSourceSearch(mModels, this);

			TableViewStock.ReloadData();
		}

		//private void Search()
		//{
		//	DataSource.PerformSearch(txtSearchBar.Text);
		//	TableViewStock.ReloadData();
		//}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			viewModel = new WebDataModel<ResultJewelry>();
			InitializeTableView();
			pnlCloseout.Hidden = true;
			pnlSearch.Hidden = true;
			pnlSearch.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);

			var DataSource1 = new TableSourceSearch(this);
			TableViewStock.Source = DataSource1;
			var sdc = searchDisplayController;
			sdc.SearchResultsSource = DataSource1;
			sdc.SearchBar.TextChanged += (sender, e) =>
				{
					string text = e.SearchText.Trim();
					localModelsSearch = (from fruit in localModels
										 where fruit.JewelBaseDescName.ToUpper().Contains(text.ToUpper())
										 select fruit).ToList();
				};

			//txtSearchBar.TextChanged += (sender, e) =>
			//{
			//	Search();
			//};System.NullReferenceException: Object reference not set to an instance of an object
		//	at JewelsExchange.iOS.ViewController_Stock.ViewDidLoad()[0x00070] in / Users / shiddic / Documents / JewelsExchange / msoftech / JewelsExchange.git / iOS / ViewController_Stock.cs:197
  //at at (wrapper managed - to - native) UIKit.UIApplication:UIApplicationMain(int, string[], intptr, intptr)
  //at UIKit.UIApplication.Main(System.String[] args, System.IntPtr principal, System.IntPtr delegate)[0x00005] in / Users / builder / data / lanes / 3969 / 44931ae8 / source / xamarin - macios / src / UIKit / UIApplication.cs:79
  //at UIKit.UIApplication.Main(System.String[] args, System.String principalClassName, System.String delegateClassName)[0x00038] in / Users / builder / data / lanes / 3969 / 44931ae8 / source / xamarin - macios / src / UIKit / UIApplication.cs:63
  //at JewelsExchange.iOS.Application.Main(System.String[] args)[0x00008] in / Users / shiddic / Documents / JewelsExchange / msoftech / JewelsExchange.git / iOS / Main.cs:18

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	


	public class TableSourceSearch : UITableViewSource
	{
		ViewController_Stock owner;
			private UISearchDisplayController search;
		//List<ResultJewelry> models;
		//List<ResultJewelry> modelsSearch;

		string CellIdentifier = "TableCell";

		public TableSourceSearch()
		{

		}
		public TableSourceSearch( ViewController_Stock owner)
		{
			//this.models = models;
			//this.modelsSearch = this.models;
			this.owner = owner;
				search = owner.searchDisplayController;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

				//var index = indexPath.Row;

				////ViewController_StockDetails controller = owner.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
				////controller.models = models;
				////controller.indexPath = indexPath;
				////owner.NavigationController.PushViewController(controller, true);

				//owner.SetSearchData(GetFruit()[indexPath.Row].JewelBaseDescName);
				//   tableView.DeselectRow(indexPath, true);

				//var detailController = new UIViewController();
				//detailController.View.BackgroundColor = UIColor.White;
				//detailController.Title = GetFruit()[indexPath.Row].JewelBaseDescName;
				//owner.NavigationController.PushViewController(detailController, true);



		}

		//public void PerformSearch(string searchText)
		//{
		//	//filter master data set by the text entered by the user
		//	searchText = searchText.ToLower();
		//	//this.modelsSearch = models.Where(x => x.JewelBaseDescName.ToLower().Contains(searchText)).ToList();
		//	this.modelsSearch = (from model in models
		//						 where model.JewelBaseDescName.ToUpper().Contains(searchText)
		//						 select model).ToList();

		//}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
				if (GetFruit() == null)
				{
					return 0;
				}
				else
				{
					return GetFruit().Count;
				}




					//return modelsSearch.Count;
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 40;
		}

		
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
				cell.UpdateCellSearch(GetFruit(), indexPath);
				return cell;
			}

			private List<ResultJewelry> GetFruit()
			{
				
				return search.Active ? owner.localModelsSearch : owner.localModels;
			}
	}

}
}

