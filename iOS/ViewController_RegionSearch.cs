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
	public partial class ViewController_RegionSearch : UIViewController
	{
		const string sRegionPH = "Region Search";
	

		WebDataModel<Master.Region> objWSRegion = new WebDataModel<Master.Region>();
		List<Master.Region> objRegion;
		List<Master.Region> objRegionSearch;
		private string sRegionSelectionData = "";

		public SidebarNavigation.SidebarController SidebarController { get; private set; }
		public bool bMenuStatus = false;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			InitializeTableView();
			
		
			//pnlSearch.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);

			var Temp = new TableSourceSearch(this, sRegionPH);
			TableViewStock.Source = Temp;

			//pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sRegionPH;

				LoadRegionData("AMSWHO01", "GJ", 0);
		

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
					
						objRegionSearch = (from Data in objRegion
										   where Data.JewelRegionName.ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					


					TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
					TableViewStock.ReloadData();

				};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
		public ViewController_RegionSearch() : base("ViewController_RegionSearch", null)
		{

		}

		public ViewController_RegionSearch(IntPtr ptr) : base(ptr)
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

		private void LoadRegionData(string LoggedCompanyCode, string sBType, int closeoutPrice)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_MASTER_REGION, urlParam);
		}

		void resultRegionCompletion(ObservableCollection<Master.Region> wDatas)
		{
			List<Master.Region> mModels = new List<Master.Region>(wDatas);
			objRegion = mModels;
			objRegionSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}


	
	



	

		public void SetSearchData()
		{
			int i = 0;
			//switch (txtSearchBar.Placeholder)
			//{
			//	case sRegionPH:
					sRegionSelectionData = "";
				

					for (i = 0; i <= objRegion.Count - 1; i++)
					{
						if (objRegion[i].bStatus == true)
						{
							if (sRegionSelectionData.Trim() == "")
							{
								sRegionSelectionData = objRegion[i].JewelRegionCode;
								//txtRegion.Text = objRegion[i].JewelRegionName;
							}
							else
							{
								sRegionSelectionData = sRegionSelectionData + "," + objRegion[i].JewelRegionCode;
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
			sRegionSelectionData = "";
			for (i = 0; i <= objRegion.Count - 1; i++)
			{
				if (objRegion[i].bStatus == true)
				{
					if (sRegionSelectionData.Trim() == "")
					{
						sRegionSelectionData = objRegion[i].JewelRegionCode;
					
					}
					else
					{
						sRegionSelectionData = sRegionSelectionData + "," + objRegion[i].JewelRegionCode;
					
					}
				}
			}
			if (sRegionSelectionData == "")
			{
				Toast.MakeText("Region Selection Count 0.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			else
			{
				this.PerformSegue("CallCategorySearch", sender);
			}
		}



		//private void Search()
		//{
		//	DataSource.PerformSearch(txtSearchBar.Text);
		//	TableViewStock.ReloadData();
		//}





		public class TableSourceSearch : UITableViewSource
		{
			ViewController_RegionSearch owner;
			private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			private string sSearchType = "";
			string CellIdentifier = "TableCell";

			public TableSourceSearch()
			{

			}
			public TableSourceSearch(ViewController_RegionSearch owner, string sSearchType)
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


					cell.UpdateCellRegionMaster(GetRegionMaster(), indexPath);
			
			
				return cell;
			}

			private List<Master.Region> GetRegionMaster()
			{

				return search.Active ? owner.objRegion : owner.objRegionSearch;

			}

		
		}

	}
}

