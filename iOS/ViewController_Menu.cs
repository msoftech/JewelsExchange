using System;
using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Menu : UIViewController
	{
		public ViewController_Menu() : base("ViewController_Menu", null)
		{
		}

		public ViewController_Menu(IntPtr ptr) : base(ptr)
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


			//var contentController = (ContentController)Storyboard.InstantiateViewController("ContentController");

			//ContentButton.TouchUpInside += (o, e) =>
			//{
			//	if (NavController.TopViewController as ContentController == null)
			//		NavController.PushViewController(contentController, false);
			//	SidebarController.CloseMenu();
			//};

			//table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] { "Search Jewelery", "Chat", "Message Board", "Inventory", "Add Gold Jewelery", "Add Diamonds Jewelery","My Stock","Setting","Favourite Member","Other Settings" };
			table.Source = new TableSource(tableItems);
			//Add(table);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		public class TableSource : UITableViewSource
		{

			string[] TableItems;
			string CellIdentifier = "TableCell";

			public TableSource(string[] items)
			{
				TableItems = items;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return TableItems.Length;
			}
			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 40;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{

				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
				//string item = TableItems[indexPath.Row];
				cell.UpdateCellMenu(TableItems, indexPath);
				return cell;



				//UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
				//string item = TableItems[indexPath.Row];

				////---- if there are no cells to reuse, create a new one
				//if (cell == null)
				//{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

				//cell.TextLabel.Text = item;

				//return cell;







				////var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;
				//var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell ??
				//		 new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier) as TableCell;
				//if (cell != null)
				//{
				//	cell.UpdateCell(models, UIImage.FromFile("User.png"), indexPath);
				//	return cell;
				//}
				//else
				//{
				//	return null;
				//}
			}


		}
	}



}

