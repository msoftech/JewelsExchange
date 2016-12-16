using System;
using UIKit;



namespace JewelsExchange.iOS
{
	public class CustomCell:UITableViewCell
	{
		public CustomCell(IntPtr handle):base(handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
		}
		public void UpdateCell(string name,UIImage image)
		{
			img_profile.image = image;
			lbl_name.text = name;
	}
}
