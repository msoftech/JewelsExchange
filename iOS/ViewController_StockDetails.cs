using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_StockDetails : UIViewController
	{

		public string sStockNumber;
		public string sCompanyCode;
		//public List<StockList> models;
	 //	public NSIndexPath indexPath;
		WebDataModel<StockDetails> viewModel;
		//List<StockList> localModels = new List<StockList>();

		public ViewController_StockDetails() : base("ViewController_StockDetails", null)
		{
		}
		public ViewController_StockDetails(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Loading.StartAnimating();
			//await Task.Delay(2000);

			viewModel = new WebDataModel<StockDetails>();
			loadData(sCompanyCode, sStockNumber);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void loadData(string LoggedCompanyCode, string StockNumber)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@StockNumber", StockNumber);
			viewModel.GetWebDataTask(resultCompletion, _webFunction.GET_GOLD_DETAILS , urlParam);
		}


		void resultCompletion(ObservableCollection<StockDetails> wDatas)
		{
			List<StockDetails> mModels = new List<StockDetails>(wDatas);
			if (mModels == null)
			{
				Loading.StopAnimating();
				Loading.Hidden = true;
				return;
			}
			if (mModels.Count == 0)
			{
				Loading.StopAnimating();
				Loading.Hidden = true;
				return;
			}
			imgProductImage.Image = UIImage.FromFile("User.png");
			lblCompany.Text = mModels[0].CompanyName;
			lblProductName.Text = mModels[0].JewelBaseDescName;
			lblCurrencyName.Text =mModels[0].CurrencyName;
			lbl111.Text =mModels[0].Karat;
			lbl222.Text =mModels[0].WeightGms;
			lblStock.Text = mModels[0].StockNumber;
			lblRegion.Text = mModels[0].JewelRegionName;
			lblCategory.Text = mModels[0].JewelCategoryName;
			lblBaseDesc.Text = mModels[0].JewelBaseDescName;
			lblKarat.Text = mModels[0].JewelMetalKaratName;
			lblWeight.Text = mModels[0].WeightGms;
			lblCurrency.Text =mModels[0].Currency;
			lblSellingPrice.Text = mModels[0].MakingChargesPerGm;
			lblCloseoutPrice.Text = mModels[0].MakingChargesApplicable;

			Loading.StopAnimating();
			Loading.Hidden = true;


			//lblStock.Text = models[indexPath.Row].JewelBaseDescName;
		}
	}
}

