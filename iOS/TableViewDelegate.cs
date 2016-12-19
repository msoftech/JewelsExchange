using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{

	//--------
	public  class TableViewDelegate : UITableViewDelegate
	{
		private List<string> list;

		public TableViewDelegate(List<string> list)
		{
			this.list = list;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			this.YourNavigationController.PushViewController(yourViewController, true);
		}
	}
	}

}
