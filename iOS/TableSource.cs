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
		ViewController_StockList owner;

		List<ResultJewelry> models;
		string CellIdentifier = "TableCell";

		public TableSource(List<ResultJewelry> models,ViewController_StockList owner)
		{
			this.models = models;
			this.owner = owner;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			var index = indexPath.Row;

			ViewController_StockDetails controller = owner.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
			controller.models  = models;
			controller.indexPath = indexPath;

			owner.NavigationController.PushViewController(controller,true);

			tableView.DeselectRow(indexPath, true);

		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return models.Count;
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
			cell.UpdateCell(models, UIImage.FromFile("User.png"), indexPath);
			return cell;
		}

	}

}
