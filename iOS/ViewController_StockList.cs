﻿using System;
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

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			viewModel = new WebDataModel<ResultJewelry>();

			List<ResultJewelry> localModels = new List<ResultJewelry>();
			//localModels.Add(null);
			table.Source = new TableSource(localModels);
			loadData("AF MAN01", 0, 10, "n", false);
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

			table.Source = new TableSource(mModels);
			table.ReloadData();
			//Add(table);
		}


	}

	public class TableSource : UITableViewSource
	{

		List<ResultJewelry> models;
		string CellIdentifier = "TableCell";
		//string CellIdentifier = "GrowCell";
		//public TableSource(string[] items)
		//{
		//	TableItems = items;
		//}

		public TableSource(List<ResultJewelry> models)
		{
			this.models = models;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = models[indexPath.Row].JewelBaseDescName; //TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ //cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); 
			  //cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
				cell = new UITableViewCell(UITableViewCellStyle.Value1 , CellIdentifier);
			}

			//var cell = tableView.DequeueReusableCell(CellID, indexPath) as GrowRowTableCell;

			cell.TextLabel.Text = item;
			cell.DetailTextLabel.Text = models[indexPath.Row].StockNumber;// tableItems[indexPath.Row].SubHeading;
			cell.ImageView.Image = UIImage.FromBundle("User");// UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageName);
			//cell.RowHeight = UITableView.AutomaticDimension;
			//cell.EstimatedRowHeight = new nfloat(105.0);
			//cell.RowHeight += (object sender, EventArgs e) =>

			return cell;
		}


	}
}
