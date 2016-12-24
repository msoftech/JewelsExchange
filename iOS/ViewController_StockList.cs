using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;
using ToastIOS;
namespace JewelsExchange.iOS
{
	public partial class ViewController_StockList : UIViewController
	{
		WebDataModel<StockList> viewModel;
		List<StockList> localModels = new List<StockList>();

		public string sKaratSelectionData = "";
		public string sRegionSelectionData = "";
		public string sWorkTypeSelectionData = "";
		public string sCategorySelectionData = "";
		public string sIsCloseOut = "";
		public bool isLoding = false;

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

			loadData("AMSWHO01", sIsCloseOut, sRegionSelectionData , sWorkTypeSelectionData , sCategorySelectionData,sKaratSelectionData  ,0,5);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Process.Hidden = true;
			viewModel = new WebDataModel<StockList>();
			InitializeTableView();
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

		public void loadData(string LoggedCompanyCode,string sCloseout,string sRegionData,string sWorkTypeData,string sCategoryData,string sKaratData, int StartRow, int EndRow)
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
			TableViewSearch.Source = new TableSource(localModels ,this);

			TableViewSearch.ReloadData();
			isLoding = false;
			LoadProcessEnd();
			//Add(table);
		}

}


	//--------
	

	public class TableSource : UITableViewSource
	{
		ViewController_StockList owner;
		//public event EventHandler<SongSelectedEventArgs> SongSelected;
		List<StockList> models;
		string CellIdentifier = "TableCell";

		public TableSource(List<StockList> models,ViewController_StockList owner)
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
		//			}; 		//	alert.AddButton("OK"); 		//	alert.Show();

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

				if (distanceFromBottom < height )
				{
				owner.LoadProcessStart();
					//Toast.MakeText("Loding...", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Bottom ).SetBgRed(30).Show();
					
					owner.loadData("AMSWHO01", "N", "100", "100", "100", "109", models.Count , models.Count + 5);
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

			owner.NavigationController.PushViewController(controller,true);

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
			if (models==null)
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
			else if (models.Count  == 0)
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

