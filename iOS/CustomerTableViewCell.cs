using System;

using Foundation;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class CustomerTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("CustomerTableViewCell");
		public static readonly UINib Nib;

		static CustomerTableViewCell()
		{
			Nib = UINib.FromName("CustomerTableViewCell", NSBundle.MainBundle);
		}

		protected CustomerTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

	}
}
