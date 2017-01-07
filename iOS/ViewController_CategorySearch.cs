using System;
using ToastIOS;
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
	public partial class ViewController_CategorySearch : UIViewController
	{
		const string sRegionPH = "Category Search";


		WebDataModel<Master.Category> objWSCategory = new WebDataModel<Master.Category>();
		List<Master.Category> objCategory;
		List<Master.Category> objCategorySearch;
		private string sCategorySelectionData = "";

	

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			InitializeTableView();


			//pnlSearch.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);

			var Temp = new TableSourceSearch(this, sRegionPH);
			TableViewStock.Source = Temp;

			//pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sRegionPH;

			LoadCategoryData("AMSWHO01", "GJ", 0,"100","100");


			var sdc = searchDisplayController;
			sdc.SearchResultsSource = Temp;
			//sdc.SearchBar.TextChanged += (sender, e) =>
			//	{
			//		string text = e.SearchText.Trim();
			//		localModelsSearch = (from Data in localModels
			//	                         where Data.JewelBaseDescName.ToUpper().Trim().Contains(text.ToUpper().Trim())
			//							 select Data).ToList();
			//	};
			txtSearchBar.TextChanged += (sender, e) =>
				{
					string text = e.SearchText.Trim();
					string sSearchType = txtSearchBar.Placeholder.Trim();

					objCategorySearch = (from Data in objCategory
									   where Data.JewelCategoryName.ToUpper().Trim().Contains(text.ToUpper().Trim())
									   select Data).ToList();



					TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
					TableViewStock.ReloadData();

				};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
		public ViewController_CategorySearch() : base("ViewController_CategorySearch", null)
		{

		}

		public ViewController_CategorySearch(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
		}

		private void InitializeTableView()
		{
			TableViewStock.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			TableViewStock.RowHeight = UITableView.AutomaticDimension;
			TableViewStock.EstimatedRowHeight = 50;

		}

		//partial void BtnSearchClose_TouchUpInside(UIButton sender)
		//{
		//	pnlSearch.Hidden = true;
		//}

		//partial void BtnSearchDone_TouchUpInside(UIButton sender)
		//{
		//	SetSearchData();
		//}

		//partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		//{
		//	pnlSearch.Hidden = false;
		//	txtSearchBar.Placeholder = sRegionPH;
		//	if (sRegionSelectionData == "")
		//	{
		//		LoadRegionData("AMSWHO01", "GJ", 0);
		//	}
		//	else
		//	{
		//		TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
		//		TableViewStock.ReloadData();
		//	}
		//}

		private void LoadCategoryData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData, string sWorkType)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@WorkTypeCode", sRegionData);
			urlParam.Add("@Region", sWorkType);
			objWSCategory.GetWebDataTask(resultCategoryCompletion, _webFunction.GET_MASTER_ALLCATEGORY, urlParam);
		}

		void resultCategoryCompletion(ObservableCollection<Master.Category> wDatas)
		{
			List<Master.Category> mModels = new List<Master.Category>(wDatas);
			objCategory = mModels;
			objCategorySearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}








		public void SetSearchData()
		{
			int i = 0;
			//switch (txtSearchBar.Placeholder)
			//{
			//	case sRegionPH:
			sCategorySelectionData = "";


			for (i = 0; i <= objCategory.Count - 1; i++)
			{
				if (objCategory[i].bStatus == true)
				{
					if (sCategorySelectionData.Trim() == "")
					{
						sCategorySelectionData = objCategory[i].JewelCategoryCode;
						//txtRegion.Text = objRegion[i].JewelRegionName;
					}
					else
					{
						sCategorySelectionData = sCategorySelectionData + "," + objCategory[i].JewelCategoryCode;
						//txtRegion.Text = txtRegion.Text + "-" + objRegion[i].JewelRegionName;
					}
				}
			}
			//txtRegion.Text = sRegionSelectionData;

			//break;



			//}
			//pnlSearch.Hidden = true;
		}



		//partial void TabControl_Selection(UISegmentedControl sender)
		//{
		//	var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
		//	if (selectedSegmentId == 0)
		//	{
		//		//pnlStock.Hidden = false;
		//		//pnlCloseout.Hidden = true;
		//		sIsCloseOut = "N";
		//	}
		//	else
		//	{
		//		//pnlStock.Hidden = true;
		//		//pnlCloseout.Hidden = false;
		//		sIsCloseOut = "Y";
		//	}
		//}





		partial void BtnSearch_TouchUpInside(UIButton sender)
		{
			int i = 0;
			sCategorySelectionData = "";
			for (i = 0; i <= objCategory.Count - 1; i++)
			{
				if (objCategory[i].bStatus == true)
				{
					if (sCategorySelectionData.Trim() == "")
					{
						sCategorySelectionData = objCategory[i].JewelCategoryCode;

					}
					else
					{
						sCategorySelectionData = sCategorySelectionData + "," + objCategory[i].JewelCategoryCode;

					}
				}
			}
			if (sCategorySelectionData == "")
			{
				Toast.MakeText("Region Selection Count 0.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			else
			{
				this.PerformSegue("callmsgCompany", sender);
			}
		}



		//private void Search()
		//{
		//	DataSource.PerformSearch(txtSearchBar.Text);
		//	TableViewStock.ReloadData();
		//}





		public class TableSourceSearch : UITableViewSource
		{
			ViewController_CategorySearch owner;
			private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			private string sSearchType = "";
			string CellIdentifier = "TableCell";

			public TableSourceSearch()
			{

			}
			public TableSourceSearch(ViewController_CategorySearch owner, string sSearchType)
			{
				//this.models = models;
				//this.modelsSearch = this.models;
				this.owner = owner;
				search = owner.searchDisplayController;
				this.sSearchType = sSearchType;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
				cell.Selected = !this.GetRegionMaster()[indexPath.Row].bStatus;
				this.GetRegionMaster()[indexPath.Row].bStatus = !this.GetRegionMaster()[indexPath.Row].bStatus;
				tableView.ReloadData();


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



				if (GetRegionMaster() == null)
				{
					return 0;
				}
				else
				{
					return GetRegionMaster().Count;
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


				cell.UpdateCellCategoryMaster(GetRegionMaster(), indexPath);


				return cell;
			}

			private List<Master.Category> GetRegionMaster()
			{

				return search.Active ? owner.objCategory : owner.objCategorySearch;

			}


		}

	}
}

