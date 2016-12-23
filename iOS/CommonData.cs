using System;
using ToastIOS;
namespace JewelsExchange.iOS
{
	public class CommonData
	{
		public CommonData()
		{
		}

		public void Msg(string sMsg)
		{
			Toast.MakeText(sMsg, Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
		}
	}
}
