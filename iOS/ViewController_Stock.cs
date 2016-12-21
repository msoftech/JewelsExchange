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

		//Any change Tablecell need to change
		const string sRegionPH = "Region Search";
		const string sWorkTypePH = "WorkType Search";
		const string sCategoryPH = "Category Search";
		const string sKaratPH = "Karat Search";

		WebDataModel<Master.Region> objWSRegion = new WebDataModel<Master.Region>();
		List<Master.Region> objRegion;
		List<Master.Region> objRegionSearch;
		private string sRegionSelectionData = "";

		WebDataModel<Master.WorkType> objWSWorkType = new WebDataModel<Master.WorkType>();
		List<Master.WorkType> objWorkType;
		List<Master.WorkType> objWorkTypeSearch;
		private string sWorkTypeSelectionData = "";

		WebDataModel<Master.Category> objWSCategory = new WebDataModel<Master.Category>();
		List<Master.Category> objCategory;
		List<Master.Category> objCategorySearch;
		private string sCategorySelectionData = "";

		WebDataModel<Master.Karat> objWSKarat = new WebDataModel<Master.Karat>();
		List<Master.Karat> objKarat;
		List<Master.Karat> objKaratSearch;
		private string sKaratSelectionData = "";

		public SidebarNavigation.SidebarController SidebarController { get; private set; }
		public bool bMenuStatus = false;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		
			InitializeTableView();
			pnlCloseout.Hidden = true;
			pnlSearch.Hidden = true;
			pnlSearch.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);

			var Temp = new TableSourceSearch(this,sRegionPH );
			TableViewStock.Source = Temp;
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
					if (sSearchType == sRegionPH)
					{
						objRegionSearch = (from Data in objRegion
										   where Data.JewelRegionName.ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					}
					else if (sSearchType == sWorkTypePH)
					{
						objWorkTypeSearch = (from Data in objWorkType
										   where Data.WorkTypeName .ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					}
					else if (sSearchType == sCategoryPH)
					{
						objCategorySearch = (from Data in objCategory
										   where Data.JewelCategoryName.ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					}
					else// for Karat
					{
						objKaratSearch = (from Data in objKarat
										   where Data.JewelMetalKaratName .ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					}
					


				TableViewStock.Source = new TableSourceSearch(this,txtSearchBar.Placeholder.Trim());
					TableViewStock.ReloadData();

				};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
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

		private void InitializeTableView()
		{
			TableViewStock.RegisterClassForCellReuse(typeof(TableCell), TableCell.Identifier);
			TableViewStock.RowHeight = UITableView.AutomaticDimension;
			TableViewStock.EstimatedRowHeight = 50;

		}

		partial void BtnSearchClose_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = true;
		}

		partial void BtnSearchDone_TouchUpInside(UIButton sender)
		{
			SetSearchData();
		}

		partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		{
				pnlSearch.Hidden = false;
				txtSearchBar.Placeholder = sRegionPH;
				LoadRegionData("AMSWHO01", "GJ", 0);
		}
		private void LoadRegionData(string LoggedCompanyCode, string sBType,int closeoutPrice)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
		    objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_MASTER_REGION , urlParam);
		}

		void resultRegionCompletion(ObservableCollection<Master.Region> wDatas)
		{
			List<Master.Region> mModels = new List<Master.Region>(wDatas);
			objRegion = mModels;
			objRegionSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		partial void BtnSearchKarat_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sKaratPH;
			LoadKaratData("AMSWHO01", "GJ", 0);
		}

		private void LoadKaratData(string LoggedCompanyCode, string sBType, int closeoutPrice)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			objWSKarat.GetWebDataTask(resultKaratCompletion, _webFunction.GET_MASTER_KARAT, urlParam);
		}

		void resultKaratCompletion(ObservableCollection<Master.Karat> wDatas)
		{
			List<Master.Karat> mModels = new List<Master.Karat>(wDatas);
			objKarat = mModels;
			objKaratSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}


     
		partial void BtnSearchCategory_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sCategoryPH;
			LoadCategoryData("AMSWHO01", "GJ", 0, sRegionSelectionData, sWorkTypeSelectionData);
		}

		private void LoadCategoryData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData,string sWorkType)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@WorkType", sRegionData);
			urlParam.Add("@Region", sWorkType);
			objWSCategory.GetWebDataTask(resultCategoryCompletion, _webFunction.GET_MASTER_CATEGORY, urlParam);
		}

		void resultCategoryCompletion(ObservableCollection<Master.Category> wDatas)
		{
			List<Master.Category> mModels = new List<Master.Category>(wDatas);
			objCategory = mModels;
			objCategorySearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		partial void BtnSearchWorkType_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sWorkTypePH;
			LoadWorkTypeData("AMSWHO01", "GJ", 0,sRegionSelectionData);
		}

		private void LoadWorkTypeData(string LoggedCompanyCode, string sBType, int closeoutPrice,string sRegionData)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@RegionCode", sRegionData);
			objWSWorkType.GetWebDataTask(resultWorkTypeCompletion, _webFunction.GET_MASTER_WORKTYPE, urlParam);
		}

		void resultWorkTypeCompletion(ObservableCollection<Master.WorkType> wDatas)
		{
			List<Master.WorkType> mModels = new List<Master.WorkType>(wDatas);
			objWorkType = mModels;
			objWorkTypeSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}



		public void SetSearchData()
		{
			int i = 0;
			switch (txtSearchBar.Placeholder)
			{
				case sRegionPH:
					sRegionSelectionData = "";
					sWorkTypeSelectionData = "";
					sCategorySelectionData = "";
					sKaratSelectionData = "";

					for (i = 0; i <= objRegion.Count-1; i++)
					{
						if (objRegion[i].bStatus == true)
						{
							if (sRegionSelectionData.Trim() == "")
							{
								sRegionSelectionData = objRegion[i].JewelRegionCode;
								txtRegion.Text=objRegion[i].JewelRegionName;
							}
							else
							{
								sRegionSelectionData = sRegionSelectionData + "," + objRegion[i].JewelRegionCode;
								txtRegion.Text = txtRegion.Text + "-" + objRegion[i].JewelRegionName ;
							}
						}
					}
					//txtRegion.Text = sRegionSelectionData;
					txtKarat.Text = "";
					txtCategory.Text = "";
					txtWorkType.Text = "";
					break;
				case sWorkTypePH:
					
					sWorkTypeSelectionData = "";
					sCategorySelectionData = "";
					sKaratSelectionData = "";

					for (i = 0; i <= objWorkType.Count-1; i++)
					{
						if (objWorkType[i].bStatus == true)
						{
							if (sWorkTypeSelectionData.Trim() == "")
							{
								sWorkTypeSelectionData = objWorkType[i].WorkTypeCode;
								txtWorkType.Text = objWorkType[i].WorkTypeName;
							}
							else
							{
								sWorkTypeSelectionData = sWorkTypeSelectionData + "," + objWorkType[i].WorkTypeCode;
								txtWorkType.Text  = txtWorkType.Text  + "-" + objWorkType[i].WorkTypeName;

							}
						}
					}

					//txtWorkType.Text = sData;
					txtKarat.Text = "";
					txtCategory.Text = "";
					break;
				case sCategoryPH:
					
					sCategorySelectionData = "";
					sKaratSelectionData = "";

					for (i = 0; i <= objCategory.Count - 1; i++)
					{
						if (objCategorySearch[i].bStatus == true)
						{
							if (sWorkTypeSelectionData.Trim() == "")
							{
								sWorkTypeSelectionData = objCategory[i].JewelCategoryCode;
								txtWorkType.Text = objCategory[i].JewelCategoryName;
							}
							else
							{
								sWorkTypeSelectionData = sWorkTypeSelectionData + "," + objCategory[i].JewelCategoryCode ;
								txtWorkType.Text = txtWorkType.Text + "-" + objCategory[i].JewelCategoryName;

							}
						}
					}

					//txtWorkType.Text = sData;
					txtKarat.Text = "";

					break;
				case sKaratPH:

					sKaratSelectionData = "";

					for (i = 0; i <= objKaratSearch.Count - 1; i++)
					{
						if (objKaratSearch[i].bStatus == true)
						{
							if (sWorkTypeSelectionData.Trim() == "")
							{
								sWorkTypeSelectionData = objKarat[i].JewelMetalKaratCode;
								txtWorkType.Text = objKarat[i].JewelMetalKaratName ;
							}
							else
							{
								sWorkTypeSelectionData = sWorkTypeSelectionData + "," + objKarat[i].JewelMetalKaratCode ;
								txtWorkType.Text = txtWorkType.Text + "-" + objKarat[i].JewelMetalKaratName ;

							}
						}
					}

					//txtWorkType.Text = sData;
				
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



		//private void Search()
		//{
		//	DataSource.PerformSearch(txtSearchBar.Text);
		//	TableViewStock.ReloadData();
		//}


	


	public class TableSourceSearch : UITableViewSource
	{
		ViewController_Stock owner;
			private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			private string sSearchType = "";
		string CellIdentifier = "TableCell";

		public TableSourceSearch()
		{

		}
		public TableSourceSearch( ViewController_Stock owner,string sSearchType)
		{
			//this.models = models;
			//this.modelsSearch = this.models;
			this.owner = owner;
				search = owner.searchDisplayController;
				this.sSearchType = sSearchType;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

				if (sSearchType == sRegionPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetRegionMaster()[indexPath.Row].bStatus;
					this.GetRegionMaster()[indexPath.Row].bStatus = !this.GetRegionMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
				}
				else if (sSearchType == sWorkTypePH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetWorkTypeMaster()[indexPath.Row].bStatus;
					this.GetWorkTypeMaster()[indexPath.Row].bStatus = !this.GetWorkTypeMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
				}
				else if (sSearchType == sCategoryPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetCategoryMaster()[indexPath.Row].bStatus;
					this.GetCategoryMaster()[indexPath.Row].bStatus = !this.GetCategoryMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
				}
				else if (sSearchType == sKaratPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetKaratMaster()[indexPath.Row].bStatus;
					this.GetKaratMaster()[indexPath.Row].bStatus = !this.GetKaratMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
				}

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
				

				if (sSearchType == sRegionPH)
				{
					if (GetRegionMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetRegionMaster().Count;
					}
				}
				else if (sSearchType == sWorkTypePH)
				{
					if (GetWorkTypeMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetWorkTypeMaster().Count;
					}
				}
				else if (sSearchType == sCategoryPH)
				{
					if (GetCategoryMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetCategoryMaster().Count;
					}
				}
				else 
				{
					if (GetKaratMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetKaratMaster().Count;
					}
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

				if (sSearchType == sRegionPH)
				{
					cell.UpdateCellRegionMaster(GetRegionMaster(), indexPath);
				}
				else if (sSearchType == sWorkTypePH)
				{
					cell.UpdateCellWorkTypeMaster(GetWorkTypeMaster(), indexPath);
				}
				else if (sSearchType == sCategoryPH)
				{
					cell.UpdateCellCategoryMaster(GetCategoryMaster(), indexPath);
				}
				else if (sSearchType == sKaratPH)
				{
					cell.UpdateCellKaratMaster(GetKaratMaster(), indexPath);
				}

				return cell;
			}

			private List<Master.Region> GetRegionMaster()
			{
				
					return search.Active ? owner.objRegion : owner.objRegionSearch;

			}

			private List<Master.WorkType> GetWorkTypeMaster()
			{
				
					return search.Active ? owner.objWorkType : owner.objWorkTypeSearch;
			
			

			}
			private List<Master.Category> GetCategoryMaster()
			{

				return search.Active ? owner.objCategory : owner.objCategorySearch;

			
			}
			private List<Master.Karat > GetKaratMaster()
			{

				return search.Active ? owner.objKarat  : owner.objKaratSearch;


			}
	}

}
}

