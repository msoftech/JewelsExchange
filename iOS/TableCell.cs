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
		public void UpdateCell(List<ResultJewelry> models, UIImage image, NSIndexPath indexPath)
		{
			img_profile.Image = image;
			lbl_name.Text = models[indexPath.Row].JewelBaseDescName;
			lbl_Details.Text = "Kannan";
		}
	}
}