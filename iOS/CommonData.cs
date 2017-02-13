using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ToastIOS;
namespace JewelsExchange.iOS
{
	public class CommonData
	{
		public CommonData()
		{
		}
		//public static string mCompanyName { get; set; }

		public static string sCon = "aldlajsf";

		public static void MessageBox(string sMsg)
		{
			Toast.MakeText(sMsg, Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
		}

		public static async void FTPUpload(string sFileName, string sFilePath)
		{
			await Upload(sFileName, sFilePath);

		}

		public static async Task Upload(string sFileName, string sFilePath)
		{
			string ftpHost = "ftp://jewelsxchange.com/chatImages/StockImages/" + sFileName;

			string ftpUser = "jxchngservice.mark.com|jxchngservice@mark.com";

			string ftpPassword = "daw00d@js";

			//string ftpfullpath = "ftp://myserver.com/testme123.jpg";

			FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpHost);

			//userid and password for the ftp server  

			ftp.Credentials = new NetworkCredential(ftpUser, ftpPassword);

			ftp.KeepAlive = true;
			ftp.UseBinary = true;
			ftp.Method = WebRequestMethods.Ftp.UploadFile;
			ftp.UsePassive = false;

			FileStream fs = File.OpenRead(sFilePath);//storedAudioPath + fileName + Common.EXTN_AUDIO);

			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);

			fs.Close();

			System.IO.Stream ftpstream = ftp.GetRequestStream();
			ftpstream.Write(buffer, 0, buffer.Length);
			ftpstream.Close();
			ftpstream.Flush();
		}
	}
}
