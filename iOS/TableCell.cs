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
			const string sRegionPH = "Region Search";
		const string sWorkTypePH = "WorkType Search";
		const string sCategoryPH = "Category Search";
		const string sKaratPH = "Karat Search";

		public TableCell(IntPtr handle) : base(handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
		}

		public void UpdateCell(List<ResultJewelry> models, UIImage image, NSIndexPath indexPath)
		{
			img_profile.Image = image;
			lbl1.Text = models[indexPath.Row].JewelBaseDescName;
			lbl2.Text = "Kannan";

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
