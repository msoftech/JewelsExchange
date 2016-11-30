using System;
namespace JewelsExchange.Droid
{
	public class NavDrawerItem
	{
		private Boolean showNotify;
		private String title;

		public NavDrawerItem()
		{
		}

		public NavDrawerItem(Boolean showNotify, String title)
		{
			this.showNotify = showNotify;
			this.title = title;
		}

		public Boolean isShowNotify()
		{
			return showNotify;
		}

		public void setShowNotify(Boolean showNotify)
		{
			this.showNotify = showNotify;
		}

		public String getTitle()
		{
			return title;
		}

		public void setTitle(String title)
		{
			this.title = title;
		}
	}
}
