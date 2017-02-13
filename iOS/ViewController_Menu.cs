using System;
using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Menu : UIViewController
	{
		UIWindow window;
		//public static event EventHandler RowHeight = delegate { };
		//public override UIWindow Window
		//{
		//	get;
		//	set;
		//}
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
			window = new UIWindow(UIScreen.MainScreen.Bounds);


			//var contentController = (ContentController)Storyboard.InstantiateViewController("ContentController");

			//ContentButton.TouchUpInside += (o, e) =>
			//{
			//	if (NavController.TopViewController as ContentController == null)
			//		NavController.PushViewController(contentController, false);
			//	SidebarController.CloseMenu();
			//};

			//table = new UITableView(View.Bounds); // defaults to Plain style
			//NSUserDefaults.StandardUserDefaults.StringForKey(("Retails", "UserType");
			//string[] tableItems = new string[] { "Home Screen", "Search Jewelery", "Chat", "Message Board", "Inventory", "Add Gold Jewelery", "Add Diamonds Jewelery", "My Stock", "Setting", "Favourite Member", "Other Settings" };

			if (NSUserDefaults.StandardUserDefaults.StringForKey("UserType").ToString() == "Retails")
			{
				txtName.Text = NSUserDefaults.StandardUserDefaults.StringForKey("UserName").ToString();
				NSUserDefaults.StandardUserDefaults.SetString(txtName.Text, "Chat_Sender");
				txtType.Text = "Retailer";
				string[] tableItems = new string[] { "Chat","Setting",  "Other Settings" };
				table.Source = new TableSource(this, tableItems);
			}
			else
			{
				txtName.Text = NSUserDefaults.StandardUserDefaults.StringForKey("ContactPerson").ToString();
				NSUserDefaults.StandardUserDefaults.SetString(txtName.Text, "Chat_Sender");
				if (txtName.Text.Trim() == "")
				{
					txtName.Text = NSUserDefaults.StandardUserDefaults.StringForKey("UserName").ToString();
				}

				txtType.Text = "WholeSaller";
				string[] tableItems = new string[] { "Home Screen", "Search Jewelery", "Chat", "Message Board", "Inventory", "Add Gold Jewelery", "Add Diamonds Jewelery", "My Stock", "Setting", "Favourite Member" ,"Other Settings" };
				table.Source = new TableSource(this, tableItems);
			}

			//Add(table);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void callStock(string sSelectedName)
		{
			UINavigationController ctrl = new UINavigationController();
			if (sSelectedName == "Home Screen")
			{
				ViewController_Home  controller = this.Storyboard.InstantiateViewController("ViewController_Home") as ViewController_Home;
				ctrl.PushViewController(controller, true);
			}
			else if (sSelectedName == "Chat")
			{
				ViewController_ChatList controller = this.Storyboard.InstantiateViewController("ViewController_ChatList") as ViewController_ChatList;
				ctrl.PushViewController(controller, true);
			}
			else
			{
				ViewController_Stock controller = this.Storyboard.InstantiateViewController("ViewController_Stock_menu") as ViewController_Stock;
				ctrl.PushViewController(controller, true);
			}
				
			window.RootViewController = ctrl;
			window.MakeKeyAndVisible();
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
			ViewController_Menu owner;

			public TableSource(ViewController_Menu owner,string[] items)
			{
				TableItems = items;
				this.owner = owner;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{

				//UIAlertController okAlertController = UIAlertController.Create("Row Selected", models[indexPath.Row].JewelBaseDescName , UIAlertControllerStyle.Alert);
				//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				//owner.PresentViewController(okAlertController, true, null);
				try
				{
					//NSObject sender = new NSObject();
					//owner.PerformSegue("CallHome", sender);
					string sSelectedMenuName = TableItems[indexPath.Row].ToString();


					owner.callStock(sSelectedMenuName);
					//UINavigationController ctrl = new UINavigationController();
					//ViewController_Home controller = owner.Storyboard.InstantiateViewController("ViewController_Home") as ViewController_Home;
					//ctrl.PushViewController(controller, true);
					//owner.RootViewController = ctrl;
					//window.MakeKeyAndVisible();

					//var index = indexPath.Row;

					//ViewController_Stock controller = owner.Storyboard.InstantiateViewController("ViewController_Stock_menu") as ViewController_Stock;
					////controller.sStockNumber = models[indexPath.Row].StockNumber;
					////controller.sCompanyCode = models[indexPath.Row].CompanyCode;


					////controller.indexPath = indexPath;

					////ViewController_StockDetails vs = new ViewController_StockDetails();

					//owner.NavigationController.PushViewController(controller, true);

					//tableView.DeselectRow(indexPath, true);
				}
				catch (Exception ex)
				{
					Console.Write(ex.ToString());
				}

			}
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return TableItems.Length;
			}
			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 35;
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

