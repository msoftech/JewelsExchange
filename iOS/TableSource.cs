using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{

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
				cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
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
