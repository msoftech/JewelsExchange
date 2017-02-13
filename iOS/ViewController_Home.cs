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
	public partial class ViewController_Home : UIViewController
	{
		

		const string sRegionPH = "Region Search";
	
		private string sIsCloseOut = "N";

		private bool bMenu = false;

		WebDataModel<Master.Region> objWSRegion = new WebDataModel<Master.Region>();
		List<Master.Region> objRegion;
		List<Master.Region> objRegionSearch;
		private string sRegionSelectionData = "";

		//partial void UIButton9961_TouchUpInside(UIButton sender)
		//{
		//	ViewController_Test controller = this.Storyboard.InstantiateViewController("ViewController_Test") as ViewController_Test;
		//	this.NavigationController.PushViewController(controller, true);
		//}

		partial void BtnHomeSearch_TouchUpInside(UIButton sender)
		{
			SetSearchData();
		}

		public SidebarNavigation.SidebarController SidebarController { get; private set; }
		partial void BtnMenu_Activated(UIBarButtonItem sender)
		{
			var introController = (ViewController_Home)Storyboard.InstantiateViewController("ViewController_Home");
			var menuController = (ViewController_Menu)Storyboard.InstantiateViewController("ViewController_Menu");

			SidebarController = new SidebarNavigation.SidebarController(this, introController, menuController);
			SidebarController.MenuWidth = 220;
			SidebarController.ReopenOnRotate = false;
			SidebarController.MenuLocation = SidebarController.MenuLocations.Left;

			//if (SidebarController.IsOpen == false)
			//{
			SidebarController.ToggleMenu();
		}

		public ViewController_Home() : base("ViewController_Home", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//pnlSearchFilter.Hidden = true;
			//pnlSearch.Hidden = true;
			LoadRegionData("AMSWHO01", "GJ", 0);
			// Perform any additional setup after loading the view, typically from a nib.
		}
		public ViewController_Home(IntPtr p) : base(p)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	

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
			TableViewStock.Source = new TableSourceSearch(this, sRegionPH);
			TableViewStock.ReloadData();
		}

		public void CallStockList(string sRegion)
		{
			ViewController_StockList controller = this.Storyboard.InstantiateViewController("ViewController_StockList") as ViewController_StockList;
			controller.sRegionSelectionData = sRegion;
			controller.sWorkTypeSelectionData = "";
			controller.sCategorySelectionData = "";
			controller.sKaratSelectionData = "";
			controller.sIsCloseOut = this.sIsCloseOut;
			controller.sComingFrom = "Home";
			controller.objRegion = objRegion;
			controller.objRegionSearch = objRegionSearch;
			//controller.sRegionSelectionData = "100";
			//controller.sWorkTypeSelectionData = "100";
			//controller.sCategorySelectionData = "100";
			//controller.sKaratSelectionData = "109";

			this.NavigationController.PushViewController(controller, true);
		}

		public void SetSearchData()
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

			//string sRegion = this.GetRegionMaster()[indexPath.Row].JewelRegionCode;
			if (sRegionSelectionData != "")
			{
				CallStockList(sRegionSelectionData);
			}
			//txtRegion.Text = sRegionSelectionData;
			//txtKarat.Text = "";
			//txtCategory.Text = "";
			//txtWorkType.Text = "";
			//break;

		}
		public class TableSourceSearch : UITableViewSource
		{
			ViewController_Home owner;
			//private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			private string sSearchType = "";
			string CellIdentifier = "TableCell";
			int i;
			public TableSourceSearch()
			{

			}
			public TableSourceSearch(ViewController_Home owner, string sSearchType)
			{
				this.owner = owner;
				this.sSearchType = sSearchType;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
				cell.Selected = !this.GetRegionMaster()[indexPath.Row].bStatus;
				this.GetRegionMaster()[indexPath.Row].bStatus = !this.GetRegionMaster()[indexPath.Row].bStatus;
				tableView.ReloadData();
				//string sRegion = this.GetRegionMaster()[indexPath.Row].JewelRegionCode;
				//owner.CallStockList(sRegion);
			}

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
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 60;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
				cell.UpdateCellHomeRegionMaster(GetRegionMaster(), indexPath);
				if (i == 0)
				{
					i = 1;
					cell.BackgroundColor = UIColor.Gray;
				}
				else
				{
					i = 0;
						cell.BackgroundColor = UIColor.LightGray ;
				}

				return cell;
			}

			private List<Master.Region> GetRegionMaster()
			{
				return  owner.objRegionSearch;

			}
		
		}

	}
}

