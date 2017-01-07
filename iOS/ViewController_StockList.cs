using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;
using ToastIOS;
using System.Linq;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockList : UIViewController
	{
		partial void BtnFilterDone_TouchUpInside(UIButton sender)
		{
			loadData("AMSWHO01", sIsCloseOut, sRegionSelectionData, sWorkTypeSelectionData, sCategorySelectionData, sKaratSelectionData, 0, 5);
			pnlSearchFilter.Hidden = true;
		}


		partial void BtnSearchClose_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = true;
		}
			
		partial void BtnSearchDone_TouchUpInside(UIButton sender)
		{
			SetSearchData();
		}

		const string sRegionPH = "Region Search";
		const string sWorkTypePH = "WorkType Search";
		const string sCategoryPH = "Category Search";
		const string sKaratPH = "Karat Search";

		public string sIsCloseOut = "N";

		WebDataModel<Master.Region> objWSRegion = new WebDataModel<Master.Region>();
		public List<Master.Region> objRegion;
		public List<Master.Region> objRegionSearch;
		public string sRegionSelectionData = "";

		WebDataModel<Master.WorkType> objWSWorkType = new WebDataModel<Master.WorkType>();
		List<Master.WorkType> objWorkType;
		List<Master.WorkType> objWorkTypeSearch;
		public string sWorkTypeSelectionData = "";

		WebDataModel<Master.Category> objWSCategory = new WebDataModel<Master.Category>();
		List<Master.Category> objCategory;
		List<Master.Category> objCategorySearch;
		public string sCategorySelectionData = "";

		WebDataModel<Master.Karat> objWSKarat = new WebDataModel<Master.Karat>();
		List<Master.Karat> objKarat;
		List<Master.Karat> objKaratSearch;
		public string sKaratSelectionData = "";



		partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sRegionPH;
			if (sRegionSelectionData == "")
			{
				LoadRegionData("AMSWHO01", "GJ", 0);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
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
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		partial void BtnSearchWorkType_TouchUpInside(UIButton sender)
		{
			if (sRegionSelectionData == "")
			{
				Toast.MakeText("Select Region.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sWorkTypePH;
			if (sWorkTypeSelectionData == "")
			{
				LoadWorkTypeData("AMSWHO01", "GJ", 0, sRegionSelectionData);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadWorkTypeData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData)
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

		partial void BtnSearchCategory_TouchUpInside(UIButton sender)
		{

			if (sRegionSelectionData == "")
			{
				Toast.MakeText("Select Region.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			if (sWorkTypeSelectionData == "")
			{
				Toast.MakeText("Select WorkType.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sCategoryPH;
			if (sCategorySelectionData == "")
			{
				LoadCategoryData("AMSWHO01", "GJ", 0, sRegionSelectionData, sWorkTypeSelectionData);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadCategoryData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData, string sWorkType)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@WorkTypeCode", sRegionData);
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



		partial void BtnSearchKarat_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sKaratPH;
			if (sKaratSelectionData == "")
			{
				LoadKaratData("AMSWHO01", "GJ", 0);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
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

					for (i = 0; i <= objRegion.Count - 1; i++)
					{
						if (objRegion[i].bStatus == true)
						{
							if (sRegionSelectionData.Trim() == "")
							{
								sRegionSelectionData = objRegion[i].JewelRegionCode;
								txtRegion.Text = objRegion[i].JewelRegionName;
							}
							else
							{
								sRegionSelectionData = sRegionSelectionData + "," + objRegion[i].JewelRegionCode;
								txtRegion.Text = txtRegion.Text + "-" + objRegion[i].JewelRegionName;
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

					for (i = 0; i <= objWorkType.Count - 1; i++)
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
								txtWorkType.Text = txtWorkType.Text + "-" + objWorkType[i].WorkTypeName;

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
							if (sCategorySelectionData.Trim() == "")
							{
								sCategorySelectionData = objCategory[i].JewelCategoryCode;
								txtCategory.Text = objCategory[i].JewelCategoryName;
							}
							else
							{
								sCategorySelectionData = sCategorySelectionData + "," + objCategory[i].JewelCategoryCode;
								txtCategory.Text = txtCategory.Text + "-" + objCategory[i].JewelCategoryName;

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
							if (sKaratSelectionData.Trim() == "")
							{
								sKaratSelectionData = objKarat[i].JewelMetalKaratCode;
								txtKarat.Text = objKarat[i].JewelMetalKaratName;
							}
							else
							{
								sKaratSelectionData = sKaratSelectionData + "," + objKarat[i].JewelMetalKaratCode;
								txtKarat.Text = txtKarat.Text + "-" + objKarat[i].JewelMetalKaratName;

							}
						}
					}

					//txtWorkType.Text = sData;

					break;
			}
			pnlSearch.Hidden = true;
		}



		partial void BtnCloseFilter_TouchUpInside(UIButton sender)
		{
			pnlSearchFilter.Hidden = true;
		}

		partial void BtnFilter_TouchUpInside(UIButton sender)
		{
			pnlSearchFilter.Hidden = false;
			pnlSearchFilter.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);
		}


		WebDataModel<StockList> viewModel;
		List<StockList> localModels = new List<StockList>();

		//public string sKaratSelectionData = "";
		//public string sRegionSelectionData = "";
		//public string sWorkTypeSelectionData = "";
		//public string sCategorySelectionData = "";
		//public string sIsCloseOut = "";
		public bool isLoding = false;
		public string sComingFrom = "";

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
			TableViewSearch.EstimatedRowHeight = 100;
			TableViewSearch.Source = new TableSource(localModels, this);

			loadData("AMSWHO01", sIsCloseOut, sRegionSelectionData, sWorkTypeSelectionData, sCategorySelectionData, sKaratSelectionData, 0, 5);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			pnlSearchFilter.Hidden = true;
			Process.Hidden = true;

			pnlSearch.Hidden = true;
			pnlSearch.Frame = new CoreGraphics.CGRect(0, 0, 320, 506);


			viewModel = new WebDataModel<StockList>();
			InitializeTableView();
			if (sComingFrom == "Search")
			{
				btnFilter.Hidden = true;
				TableViewSearch.Frame = new CoreGraphics.CGRect(0, 64, 320, 504);
			}
			else if (sComingFrom == "Home")
			{
				btnFilter.Hidden = false;
				TableViewSearch.Frame = new CoreGraphics.CGRect(0, 89, 320, 479);
			}


			var Temp = new TableSourceSearch(this, sRegionPH);
			//TableViewStock.Source = Temp;
			var sdc = searchDisplayController;
			//sdc.SearchResultsSource = Temp;
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
											 where Data.WorkTypeName.ToUpper().Trim().Contains(text.ToUpper().Trim())
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
										  where Data.JewelMetalKaratName.ToUpper().Trim().Contains(text.ToUpper().Trim())
										  select Data).ToList();
					}



					TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
					TableViewStock.ReloadData();

				};

			//TableViewSearch.Scrolled += (sender, e) =>
			//	{
			//		loadData("AMSWHO01", "N", sRegionSelectionData, sWorkTypeSelectionData, sCategorySelectionData, sKaratSelectionData, 0, 5);
			//	};

		}

		public void LoadProcessStart()
		{
			Process.Hidden = false;
			Process.StartAnimating();

		}

		public void LoadProcessEnd()
		{
			Process.StopAnimating();
			Process.Hidden = true;

		}



		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

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

		public void loadData(string LoggedCompanyCode, string sCloseout, string sRegionData, string sWorkTypeData, string sCategoryData, string sKaratData, int StartRow, int EndRow)
		{
			if (isLoding == true)
			{
				return;
			}
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@isCloseOut", sCloseout);
			urlParam.Add("@JewelRegionCode", sRegionData);
			urlParam.Add("@WorkTypeCode", sWorkTypeData);
			urlParam.Add("@JewelCategoryCode", sCategoryData);
			urlParam.Add("@JewelMetalKaratCode", sKaratData);
			urlParam.Add("@StartRow", StartRow.ToString());
			urlParam.Add("@EndRow", EndRow.ToString());
			viewModel.GetWebDataTask(resultCompletion, _webFunction.GET_GOLD_STOCKS, urlParam);
		}


		void resultCompletion(ObservableCollection<StockList> wDatas)
		{
			List<StockList> mModels = new List<StockList>(wDatas);
			if (isLoding == true)
			{
				if (mModels.Count == 0)
				{
					LoadProcessEnd();
					Toast.MakeText("No More Data.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Bottom).SetBgRed(30).Show();
					return;
				}

				localModels.AddRange(mModels);
			}
			else
			{
				localModels = mModels;
			}
			TableViewSearch.Source = new TableSource(localModels, this);

			TableViewSearch.ReloadData();
			isLoding = false;
			LoadProcessEnd();
			//Add(table);
		}

	//}





	public class TableSourceSearch : UITableViewSource
	{
		ViewController_StockList owner;
		private UISearchDisplayController search;
		//List<ResultJewelry> models;
		//List<ResultJewelry> modelsSearch;
		private string sSearchType = "";
		string CellIdentifier = "TableCell";

		public TableSourceSearch()
		{

		}
		public TableSourceSearch(ViewController_StockList owner, string sSearchType)
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

			return  owner.objRegionSearch;//search.Active ? owner.objRegion :

		}

		private List<Master.WorkType> GetWorkTypeMaster()
		{

			return  owner.objWorkTypeSearch;//search.Active ? owner.objWorkType :



		}
		private List<Master.Category> GetCategoryMaster()
		{

			return  owner.objCategorySearch;//search.Active ? owner.objCategory :


		}
		private List<Master.Karat> GetKaratMaster()
		{

			return  owner.objKaratSearch;//search.Active ? owner.objKarat :


		}
	}

	//--------


	public class TableSource : UITableViewSource
	{
		ViewController_StockList owner;
		//public event EventHandler<SongSelectedEventArgs> SongSelected;
		List<StockList> models;
		string CellIdentifier = "TableCell";

		public TableSource(List<StockList> models, ViewController_StockList owner)
		{
			this.models = models;
			this.owner = owner;
		}

		//public override void Scrolled(UIScrollView scrollView)
		//{
		//			UIAlertView alert = new UIAlertView()
		//			{
		//				Title = "alert title",
		//				Message = "this is a simple alert"
		//			};
		//	alert.AddButton("OK");
		//	alert.Show();

		//	// load more bottom
		//	//float height = (float)scrollView.Frame.Size.Height;
		//	//float distanceFromBottom = (float)(scrollView.ContentSize.Height - scrollView.ContentOffset.Y);

		//	//if (distanceFromBottom < height )
		//	//{
		//	//	// reload data here
		//	//}

		//}
		public override void Scrolled(UIScrollView scrollView)
		{
			//          Globals.refreshView.DidScroll ();
			//Console.WriteLine("TV Scrolled!");
			//if (models.Count == scrollView.v
			if (owner.isLoding == true)
			{
				return;
			}
			float height = (float)scrollView.Frame.Size.Height;
			float distanceFromBottom = (float)(scrollView.ContentSize.Height - scrollView.ContentOffset.Y);

			if (distanceFromBottom < height)
			{
				owner.LoadProcessStart();
				//Toast.MakeText("Loding...", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Bottom ).SetBgRed(30).Show();
				owner.loadData("AMSWHO01", owner.sIsCloseOut, owner.sRegionSelectionData, owner.sWorkTypeSelectionData, owner.sCategorySelectionData, owner.sKaratSelectionData, models.Count, models.Count + 5);
				//owner.loadData("AMSWHO01", "N", "100", "100", "100", "109", models.Count , models.Count + 5);
				owner.isLoding = true;
			}

		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			//UIAlertController okAlertController = UIAlertController.Create("Row Selected", models[indexPath.Row].JewelBaseDescName , UIAlertControllerStyle.Alert);
			//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			//owner.PresentViewController(okAlertController, true, null);

			var index = indexPath.Row;

			ViewController_StockDetails controller = owner.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
			controller.sStockNumber = models[indexPath.Row].StockNumber;
			controller.sCompanyCode = models[indexPath.Row].CompanyCode;


			//controller.indexPath = indexPath;

			//ViewController_StockDetails vs = new ViewController_StockDetails();

			owner.NavigationController.PushViewController(controller, true);

			tableView.DeselectRow(indexPath, true);


		}


		//public override int  GetItemViewType(int position)
		//{
		//	return mModels[position] == null ? VIEW_TYPE_LOADING : VIEW_TYPE_ITEM;//base.GetItemViewType(position);
		//}


		//public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		//{
		//	if (holder is ResultViewHolder)
		//	{
		//		ResultJewelry model = mModels[position];
		//		ResultViewHolder exholder = (ResultViewHolder)holder;
		//		exholder.bind(model, holder.ItemView.Context);
		//	}
		//	else if (holder is LoadingViewHolder)
		//	{
		//		LoadingViewHolder loadingViewHolder = (LoadingViewHolder)holder;
		//		loadingViewHolder.progressBar.Indeterminate = true;
		//	}
		//}

		//public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		//{
		//	if (viewType == VIEW_TYPE_ITEM)
		//	{
		//		View itemView = mInflater.Inflate(Resource.Layout.row_result, parent, false);
		//		return new ResultViewHolder(itemView);
		//	}
		//	else if (viewType == VIEW_TYPE_LOADING)
		//	{
		//		View itemView = mInflater.Inflate(Resource.Layout.layout_loading_item, parent, false);
		//		//            View view = LayoutInflater.from(MainActivity.this).inflate(R.layout.layout_loading_item, parent, false);
		//		return new LoadingViewHolder(itemView);
		//	}
		//	return null;
		//}
		//---------------------------
		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			if (models == null)
			{
				//var rect = new CoreGraphics.CGRect(0, 0, tableView.Bounds.Width, tableView.Bounds.Height);

				UIImageView iv = new UIImageView(tableView.Bounds);
				iv.Image = UIImage.FromBundle("Tick1");
				iv.ContentMode = UIViewContentMode.Center;

				tableView.BackgroundView = iv;

				return 0;
			}
			else
			{
				UIView.Animate(0.5, () =>
				{
					if (tableView.BackgroundView != null)
					{
						tableView.BackgroundView.Alpha = 0.0f;
						tableView.BackgroundView = null;
					}
				});

				return 1;
			}

		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (models == null)
			{
				return 0;
			}
			else if (models.Count == 0)
			{
				return 0;
			}
			else {
				return models.Count;
			}
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
			var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell ??
					 new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier) as TableCell;
			if (cell != null)
			{
				cell.UpdateCell(models, UIImage.FromFile("User.png"), indexPath);
				return cell;
			}
			else
			{
				return null;
			}
		}


	}

}


}

