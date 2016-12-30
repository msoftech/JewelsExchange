using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Foundation;
using JewelsExchange.Webservices;
using ObjCRuntime;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Ins_Contact : UIViewController
	{
		public string sRegionSelectionData = "";
		List<Master.Country> objCountry;
		List<Master.Country> objCountrySearch;
		WebDataModel<SentOTP> objWSRegion = new WebDataModel<SentOTP>();

	

		partial void BtnCountryClose_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = true;
		}


	

		partial void BtnSearchCountry_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = "Country";
			//if (sRegionSelectionData == "")
			//{
			//	LoadRegionData("AMSWHO01", "GJ", 0);
			//}
			//else
			//{
				TableViewStock.Source = new TableSourceSearch(this);
				TableViewStock.ReloadData();
			//}
		}



		partial void BtnContactNext_TouchUpInside(UIButton sender)
		{
			if (txtCountryName.Text.Trim() == "")
			{
				Toast.MakeText("Country Name Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			else if (txtPhoneCode.Text.Trim() == "")
			{
				Toast.MakeText("Phone Code Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
		

			else if (txtPhonenumber.Text == "")
			{

				Toast.MakeText("Phone Number Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			else if (Regex.IsMatch(txtPhonenumber.Text, "[^0-9.-]") )
			{
				Toast.MakeText("Wrong Phone Number.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}
			else if (txtEmailId.Text == "")
			{
				Toast.MakeText("Email ID Empty.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;
			}

			if (Regex.Match(txtEmailId.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success==false)
			{
				Toast.MakeText("Wrong Email ID", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;     
			}

			//LoadRegionData();

			NSUserDefaults.StandardUserDefaults.SetString("Contact", "CompletedStep");
			NSUserDefaults.StandardUserDefaults.SetString(txtCountryName.Text , "UserContryName");
			NSUserDefaults.StandardUserDefaults.SetString(txtPhoneCode.Text, "UserPhoneCode");
			NSUserDefaults.StandardUserDefaults.SetString(txtPhonenumber.Text, "UserPhoneNumber");
			NSUserDefaults.StandardUserDefaults.SetString(txtEmailId.Text, "UserEmailID");

			this.PerformSegue("CAllOTP", sender);
			//ViewController_Ins_OTP controller = this.Storyboard.InstantiateViewController("ViewController_Ins_OTP") as ViewController_Ins_OTP;
			//this.NavigationController.PushViewController(controller, true);
			//ToastIOS.Toast.MakeText(opt);
		}
	    
		private void LoadRegionData()//string LoggedCompanyCode, string sBType, int closeoutPrice
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@EmailId", txtEmailId.Text );
			urlParam.Add("@PhoneNumber", txtPhoneCode.Text + txtPhonenumber.Text);
			urlParam.Add("@OTPID", DeviceId);
			urlParam.Add("@OTP", string.Empty);
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_OTP , urlParam);
		}

		void resultRegionCompletion(ObservableCollection<SentOTP> wDatas)
		{
			List<SentOTP> mModels = new List<SentOTP>(wDatas);

			//ViewController_Ins_OTP controller = this.Storyboard.InstantiateViewController("ViewController_Ins_OTP") as ViewController_Ins_OTP;
			//this.NavigationController.PushViewController(controller, true);
		    //string opt = mModels[0].RandomNumber.ToString();
	    }
		public ViewController_Ins_Contact() : base("ViewController_Ins_Contact", null)
		{
		}

		public ViewController_Ins_Contact(IntPtr p) : base(p)
		{
		}
		public string DeviceId { get { return GetDeviceIdInternal(); } }
		private string GetDeviceIdInternal()
		{
			var id = default(string);
			id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			return id;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


		 	objCountrySearch =	LoadCountry();
			objCountry = objCountrySearch;
			pnlSearch.Hidden = true;
			pnlSearch.Frame = new CoreGraphics.CGRect(0, 50, 320, 518);

			//var Temp = new TableSourceSearch(this);
			//TableViewStock.Source = Temp;
			//var sdc = searchDisplayController;
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
					//string sSearchType = txtSearchBar.Placeholder.Trim();
					
						objCountrySearch = (from Data in objCountry 
										   where Data.CountryName .ToUpper().Trim().Contains(text.ToUpper().Trim())
										   select Data).ToList();
					
					TableViewStock.Source = new TableSourceSearch(this);
					TableViewStock.ReloadData();

				};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private List<Master.Country> LoadCountry()
		{
			List<Master.Country> con = new List<Master.Country>();

			string[,] sPhoneCode = new string[10, 2] 
			{ 
				{ "91", "IN"},
				{ "93" , "AF"},
				{ "355", "AL"},
				{ "213", "DZ"},
				{ "1"  , "AS"},
				{ "376", "AD"},
				{ "244", "AO"},
				{ "1"  , "AI"},
				{ "1"  , "AG"},
				{ "54" , "AR"}
			
			};

			for (int j = 0; j < NSLocale.ISOCountryCodes.Length; j++)
			{
				Master.Country Item = new Master.Country();
				Item.CountryCode = NSLocale.ISOCountryCodes[j].ToString();
				Item.CountryName = NSLocale.CurrentLocale.GetCountryCodeDisplayName(NSLocale.ISOCountryCodes[j].ToString());
				Item.PhoneCode = (from i in Enumerable.Range(0, sPhoneCode.GetLength(0))
								  where sPhoneCode[i, 1] == NSLocale.ISOCountryCodes[j].ToString()
								  select sPhoneCode[i, 0]).FirstOrDefault();
				Item.bStatus = false;
				con.Add(Item);
			}

			return con;
		}



	public class TableSourceSearch : UITableViewSource
		{
			ViewController_Ins_Contact owner;
			//private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			//private string sSearchType = "";
			string CellIdentifier = "TableCell";

			public TableSourceSearch()
			{

			}

			public TableSourceSearch(ViewController_Ins_Contact owner)//, string sSearchType
			{
				//this.models = models;
				//this.modelsSearch = this.models;
				this.owner = owner;
				//search = owner.searchDisplayController;
				//this.sSearchType = sSearchType;
			}


			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{

				owner.txtCountryName.Text = owner.objCountrySearch[indexPath.Row].CountryName;
				owner.txtPhoneCode.Text = owner.objCountrySearch[indexPath.Row].PhoneCode;
				owner.txtSearchBar.Text = "";
				owner.pnlSearch.Hidden = true;
				//UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
				//cell.Selected = !owner.objCountry[indexPath.Row].bStatus;
				//owner.objCountry[indexPath.Row].bStatus = !owner.objCountry[indexPath.Row].bStatus;
				//tableView.ReloadData();

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
				return 40;
			}


			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;

				cell.UpdateCellCountryMaster(GetRegionMaster(), indexPath);

				return cell;
			}

			private List<Master.Country > GetRegionMaster()
			{

				return  owner.objCountrySearch;

			}


		}


	}
}

