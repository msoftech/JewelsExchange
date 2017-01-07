using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using JewelsExchange.Webservices;

namespace JewelsExchange.iOS
{
   partial class TableCell : UITableViewCell
	{
		 public const string Identifier = "Reuse";


		public TableCell(IntPtr handle) : base(handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
		}

		public void UpdateCell(List<StockList> models, UIImage image, NSIndexPath indexPath)
		{
			img_profile.Image = image;
			lbl1.Text = models[indexPath.Row].JewelCategoryName;
			lbl2.Text = models[indexPath.Row].JewelBaseDescName;
			lbl3.Text = models[indexPath.Row].JewelRegionName;

			lbl4.Text = "$ " + models[indexPath.Row].CloseOutPrice;
			lbl5.Text = models[indexPath.Row].CompanyName;
			lbl6.Text = models[indexPath.Row].JewelMetalKaratName;
			lbl7.Text = models[indexPath.Row].WeightGms + " gm";
			lbl8.Text = "Making : " + models[indexPath.Row].MakingChargesPerGm +"/gm";



		}

		public void UpdateCellMenu(string[] models, NSIndexPath indexPath)
		{
			if (models[indexPath.Row].ToString() == "Add Gold Jewelery" || models[indexPath.Row].ToString() =="Add Diamonds Jewelery" || models[indexPath.Row].ToString() == "My Stock"
			   || models[indexPath.Row].ToString() == "Favourite Member" || models[indexPath.Row].ToString() == "Other Settings")
			{
				lblMenu.Frame = new CoreGraphics.CGRect(70, 5, 250, 27);
				imgMenu.Frame = new CoreGraphics.CGRect(32, 12,20, 20);
			}
				lblMenu.Text = models[indexPath.Row].ToString();
			//"Search Jewelery", "Chat", "Message Board", "Inventory", "Add Gold Jewelery", "Add Diamonds Jewelery","My Stock","Setting","Favourite Member","Other Settings" 
		
			imgMenu.Image = UIImage.FromBundle(models[indexPath.Row].ToString().Trim());


   		}

		public void UpdateCellRegionMaster(List<Master.Region> models, NSIndexPath indexPath)
		{
				lblSearchDetails.Text = models[indexPath.Row].JewelRegionName ;
					if (!models[indexPath.Row].bStatus)
					{
						imgStatus.Image = UIImage.FromFile("Tick1_un.png");
					}
					else
					{
						imgStatus.Image = UIImage.FromBundle("Tick1.png");
					}
			}

		public void UpdateCellHomeRegionMaster(List<Master.Region> models, NSIndexPath indexPath)
		{
			lblSearchDetails.Text = models[indexPath.Row].JewelRegionName;
			if (!models[indexPath.Row].bStatus)
			{
				imgStatus.Image = UIImage.FromFile("Tick1_un.png");
			}
			else
			{
				imgStatus.Image = UIImage.FromBundle("Tick1.png");
			}

		}

		public void UpdateCellCountryMaster(List<Master.Country > models, NSIndexPath indexPath)
		{
			lblSearchDetails.Text = models[indexPath.Row].CountryName ;
			imgFlag.Image = UIImage.FromFile ("Flag/"+ models[indexPath.Row].CountryCode + ".png");
			//if (!models[indexPath.Row].bStatus)
			//{
			//	imgStatus.Image = UIImage.FromFile("Tick1_un.png");
			//}
			//else
			//{
			//	imgStatus.Image = UIImage.FromBundle("Tick1.png");
			//}
 		}

		public void UpdateCellWorkTypeMaster(List<Master.WorkType> models, NSIndexPath indexPath)
		{
			lblSearchDetails.Text = models[indexPath.Row].WorkTypeName;
			if (!models[indexPath.Row].bStatus)
			{
				imgStatus.Image = UIImage.FromFile("Tick1_un.png");
			}
			else
			{
				imgStatus.Image = UIImage.FromBundle("Tick1.png");
			}
		}
		public void UpdateCellCategoryMaster(List<Master.Category> models, NSIndexPath indexPath)
		{
			lblSearchDetails.Text = models[indexPath.Row].JewelCategoryName ;
			if (!models[indexPath.Row].bStatus)
			{
				imgStatus.Image = UIImage.FromFile("Tick1_un.png");
			}
			else
			{
				imgStatus.Image = UIImage.FromBundle("Tick1.png");
			}
		}
		public void UpdateCellKaratMaster(List<Master.Karat> models, NSIndexPath indexPath)
		{
			lblSearchDetails.Text = models[indexPath.Row].JewelMetalKaratName;
			if (!models[indexPath.Row].bStatus)
			{
				imgStatus.Image = UIImage.FromFile("Tick1_un.png");
			}
			else
			{
				imgStatus.Image = UIImage.FromBundle("Tick1.png");
			}
		}}

		

	}
