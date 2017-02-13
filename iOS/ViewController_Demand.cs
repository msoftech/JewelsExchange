using System;
using UIKit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using JewelsExchange.Webservices;
using ToastIOS;
using System.Linq;
using System.IO;
using KBCustomActionSheet;
using AVFoundation;
using IQAudioRecorderController;
using CoreGraphics;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
//using IQAudioRecorderController;

namespace JewelsExchange.iOS
{
	public partial class ViewController_Demand : UIViewController
	{
		UIImagePickerController imagePicker;
		UIScrollView scrollView;
		bool bAudioProcess = false;
		RecordAudioService ras = new RecordAudioService();
		bool bTimeProgress = false ;
		int iMint = 0;
		int iMaxAudioDuration = 5;
		private int _duration = 0;

		Byte[] myByteArray;
		string sImageBase16 = "";
		string sImageName = "";
		string sImagePath = "";

		string sAudioBase16 = "";
		string sAudioName = "";
		string sAudioPath = "";

		const string sRegionPH = "Region Search";
		const string sWorkTypePH = "WorkType Search";
		const string sCategoryPH = "Category Search";
		const string sKaratPH = "Karat Search";

		public string sBusinessType = "Gold Jewelry";

		WebDataModel<Master.Region> objWSRegion = new WebDataModel<Master.Region>();
		public List<Master.Region> objRegion;
		public List<Master.Region> objRegionSearch;
		public string sRegionSelectionData = "";

		WebDataModel<Master.WorkType> objWSWorkType = new WebDataModel<Master.WorkType>();
		List<Master.WorkType> objWorkType;
		List<Master.WorkType> objWorkTypeSearch;
		public string sWorkTypeSelectionData = "";

		WebDataModel<Master.Category> objWSCategory = new WebDataModel<Master.Category>();
		List<Master.Category> objCategory;
		List<Master.Category> objCategorySearch;
		public string sCategorySelectionData = "";

		WebDataModel<Master.Karat> objWSKarat = new WebDataModel<Master.Karat>();
		List<Master.Karat> objKarat;
		List<Master.Karat> objKaratSearch;
		public string sKaratSelectionData = "";

		WebDataModel<VerifyOTP> objWSDemand = new WebDataModel<VerifyOTP>();
		bool isImage = false;

		UIImage originalImage;

		public ViewController_Demand() : base("ViewController_Demand", null)
		{

		}

		public ViewController_Demand(IntPtr ptr) : base(ptr)
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
		//	pnlSearchFilter.Hidden = true;
			pnlSearch.Hidden = true;
			pnlSearch.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);
			//imgAttach.Hidden = true;
			//lblTime.Hidden = true;
			btnDelete.Hidden = true;
			btnPlay.Hidden = true;

			lblTime1.Hidden = true;
			lblTime2.Hidden = true;

			imgAttach.Hidden = true;
			lblTime3.Hidden = true;
			//UIButton btnPlay = new UIButton();
			//UIButton btnStop= new UIButton(); 
			//UIButton  btnDelete = new UIButton();
			//UIView pnlAudio = new UIView();

			this.Title = "Demand - " + NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Receiver").ToString();
			this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Back"
			, UIBarButtonItemStyle.Plain, (sender, args) =>
			{
				if (btnSend.Enabled == true)
				{
					NavigationController.PopViewController(true);
				}
				else
				{

				}
			}), true);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		
		}


		partial void BtnPlay_TouchUpInside(UIButton sender)
		{
			ManualAudioRecord();
			//Record();
		}

		partial void BtnDelete_TouchUpInside(UIButton sender)
		{
			File.Delete(sAudioPath);
			Toast.MakeText("Audio File Deleted.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			lblTime1.Hidden = true;
			lblTime2.Hidden = true;
			lblTime3.Hidden = true;
			lblTime2.Text  = "";
			lblTime3.Text = "";
			imgAttach.Hidden = true;
			btnDelete.Hidden = true;
			return;
		}

		private async void LoadAudioPlay()
		{
			await AudioPlay();
		}
		AVAudioPlayer player = null;
		NSUrl songURL;
		private async Task AudioPlay()
		{
			string filePath = sAudioPath;//CreatePathToUserAccessibleFile(Resource_151.RecordingFolderName) + "/" + filename;
			AVAudioSession audioSession = AVAudioSession.SharedInstance();
			audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			audioSession.SetActive(true);
			songURL = new NSUrl(filePath);
			NSData data = NSData.FromFile(filePath);
			NSError err;
			player = new AVAudioPlayer(data, songURL.PathExtension, out err);
			player.FinishedPlaying += delegate
			{
				btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);
				player.Stop();
				player = null;
			};//+= player_FinishedPlayi
			player.PrepareToPlay();
			player.Play();
		}

		private void player_FinishedPlaying()
		{

		}

		private void ManualAudioRecord()
		{
			if (imgAttach.Hidden == false)
			{
				//Toast.MakeText("Already Audio Recored.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				if (File.Exists(sAudioPath) == true)
				{
					try
					{
						if (player == null)
						{
							btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Pause.png"), UIControlState.Normal);
							LoadAudioPlay();
						}
						else
						{
							if (player.Playing == true)
							{
								btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Play.png"), UIControlState.Normal);
								player.Stop();
								player = null;
							}
							else
							{
								btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Pause.png"), UIControlState.Normal);
								player.Play();
							}
						}
					}
					catch (Exception ex)
					{
						Console.Out.WriteLine(ex.StackTrace);
					}
				}
				return;
			}
			if (bAudioProcess== false )
			{
				
				if (ras.InitializeRecordService() == true)
				{
					bAudioProcess = true;
					btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Pause.png"), UIControlState.Normal);
					lblTime1.Hidden = false;
					lblTime2.Hidden = false;
					iMint = 0;
					bTimeProgress = true;
					StartTimer();
					if (ras.Record("") == true)
					{
						Toast.MakeText("Audio recording...", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
					}
					else
					{
						Toast.MakeText("Record cancelled", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
						btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Play.png"), UIControlState.Normal);
						bTimeProgress = false;
					}
				}
			}

			else
			{
				AudioStop();
			}
		}

		private void AudioStop()
		{
			bAudioProcess = false;
			btnPlay.SetBackgroundImage(UIImage.FromFile("Final Image/Play.png"), UIControlState.Normal);
			lblTime1.Hidden = true;
			lblTime2.Hidden = true;
			btnDelete.Hidden = false;
			imgAttach.Hidden = false;
			lblTime3.Hidden = false;
			lblTime3.Text = lblTime2.Text;
			lblTime2.Text = "";
			byte[] result;
			result = ras.StopRecord();
			sAudioPath = ras._Audiopath;
			sAudioName = ras._AudioFileName;
			var fileData = NSUrl.FromFilename(sAudioPath);
			sAudioBase16 = Convert.ToBase64String(result);
			bTimeProgress = false;
		}

		public async void StartTimer()
		{
			_duration = 0;
			// tick every second while game is in progress
			while (bTimeProgress)
			{
				await Task.Delay(1000);
				_duration++;
				if (iMint < 0)
				{
				//lblTime.Text = "OTP Expired";
					//btnResent.Hidden = false;
				//btnOTPVerify.Hidden = true;
				//	return;
				}
				//string s = TimeSpan.FromSeconds(_duration).ToString(@"mm\:ss");
				lblTime2.Text =  iMint.ToString("00") + " : " + _duration.ToString("00");
				if (_duration == 60)
				{
					_duration = 0;
					iMint++;
				}
				if (iMint == iMaxAudioDuration - 1)
				{
					AudioStop();
				}
			}
		}


		//private async void Record()
		//{
		//	var colors = new UIColor[] { UIColor.Green, UIColor.Red, UIColor.Orange };
		//	var result1 = await IQAudioRecorderViewController.ShowDialogTask(this, colors);
		//	if (!string.IsNullOrWhiteSpace(result1))
		//	{
		//		Toast.MakeText("File recorded", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
		//		byte[] FileByte = File.ReadAllBytes(result1);

		//		sAudioPath = result1;
		//		sAudioBase16 = Convert.ToBase64String(FileByte);

		//		sAudioName = "Aud" + "Kannan" + DateTime.Now.ToString("yyyyMMddHHmmss");//NSUserDefaults.StandardUserDefaults.StringForKey("JewelsExchangeName").ToString();

		//		imgAttach.Hidden = false;
		//		lblTime1.Hidden = false;

		//	}
		//	else
		//	{
				
		//		Toast.MakeText("Record cancelled", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
		//	}

		//}

			
		partial void BtnAttach_TouchUpInside(UIButton sender)
		{
			KBActionSheet actionSheet = new KBActionSheet();
			actionSheet.Title = "A thing needs to be done.\nAre you sure you want to do it?";
			actionSheet.AddButtonWithTitle("Camera", () => { 
				
				imagePicker = new UIImagePickerController();
			 isImage = false ;
				imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);

				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;

				NavigationController.PresentModalViewController(imagePicker, true);
			});
			actionSheet.AddButtonWithTitle("Gallery", () =>
			{
				//actionSheet.Dispose();
				imagePicker = new UIImagePickerController();
				isImage = false;
				imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;
				//var ss = imageView.Accessibi

				NavigationController.PresentModalViewController(imagePicker, true);
			});
			actionSheet.AddDestructiveButtonWithTitle("Audio", () =>
			{
				btnPlay.Hidden = false;
				//Record();
			});



			actionSheet.Style = KBActionSheetStyle.Light ;
			actionSheet.ShowFromView(btnAttach, this.View);
		}


	

		partial void BtnSend_TouchUpInside(UIButton sender)
		{
			btnSend.Enabled = false;
			if (sAudioName != "")
			{
				LoadAudioData();
			}
			else if (isImage ==true)
			{
				LoadImageData();
			}
			else 
			{
				LoadSendData();
			}
		}

		private void LoadSendData()
		{
			
			var urlParam = new Dictionary<string, string>();

			urlParam.Add("@Karat", sKaratSelectionData);
			urlParam.Add("@StockNumber", txtStockNo.Text);
			urlParam.Add("@SizeOrQty", txtSize.Text.Trim());
			urlParam.Add("@WeightRange", txtWeight.Text.Trim());
			urlParam.Add("@SpecialInstruction", txtSpecial.Text .Trim());
			urlParam.Add("@Stamping", txtStamping.Text.Trim() );
			urlParam.Add("@BullionType", sBusinessType);
			urlParam.Add("@JewelRegionCode", sRegionSelectionData);
			urlParam.Add("@WorkType", sWorkTypeSelectionData);
			urlParam.Add("@JewelCategory", sCategorySelectionData);
			urlParam.Add("@JewelBaseDescName", txtBaseDescription.Text );
			urlParam.Add("@DemandImg", sImageName);
			urlParam.Add("@DemandAudio", sAudioName);
			urlParam.Add("@SenderJId",NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString());
			urlParam.Add("@ReceiverJId", NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Receiver").ToString());
			urlParam.Add("@Status", "0");
			urlParam.Add("@Platform", "IOS");
			objWSDemand.GetWebDataTask(resultSendCompletion, _webFunction.GET_Save_Demand, urlParam);
		}

		void resultSendCompletion(ObservableCollection<VerifyOTP> wDatas)
		{

			if (wDatas == null)
			{ ChatOn.objMyChat().ChatDemondNotification("Demond :\n" + LoadDemandData(), sAudioPath, sImagePath);
				return;
			}
			string res = wDatas[0].Result.ToString();
			if (res == "True")
			{
				ChatOn.objMyChat().SendMessage((int)NSUserDefaults.StandardUserDefaults.IntForKey("Chat_Receiver_QuickBoxID"), "Demand");
				ChatOn.objMyChat().ChatDemondNotification("Demond :\n" + LoadDemandData(),sAudioPath,sImagePath );
				btnSend.Enabled = true;
				//NavigationController.DismissModalViewController
				//mnuStockMenu.BackBarButtonItem.to
				this.NavigationController.PopViewController(true);//	DismissViewControllerAsync(true);
				                    
			}
			else
			{
				Toast.MakeText("OTP Timeout.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}

		private string LoadDemandData()
		{

			string sData = "";
			if (!string.IsNullOrWhiteSpace(txtStockNo.Text))
			{
				sData += "Stock No. : " + txtStockNo.Text.Trim() + "\n";  
			}
			if (!string.IsNullOrWhiteSpace(txtSize.Text))
			{
				sData += "Size/Qty : " + txtSize.Text.Trim() + "\n";
			}	
			if (!string.IsNullOrWhiteSpace(txtWeight.Text))
			{
				sData += "Weight : " + txtWeight.Text.Trim() + "\n";
			}
			if (!string.IsNullOrWhiteSpace(txtSpecial.Text))
			{
				sData += "Special : " + txtSpecial.Text.Trim() + "\n";
			}







			return sData;
		}

	

		public byte[] ResizeImage(UIImage originalImage, double maxWidth, double maxHeight)
		{
		//	UIImage originalImage = originalImage;// ImageFromByteArray(imageData);


			double width = 300, height = 300;

			double maxAspect = (double)maxWidth / (double)maxHeight;
			double aspect = (double)originalImage.Size.Width / (double)originalImage.Size.Height;

			if (maxAspect > aspect && originalImage.Size.Width > maxWidth)
			{
				//Width is the bigger dimension relative to max bounds
				width = maxWidth;
				height = maxWidth / aspect;
			}
			else if (maxAspect <= aspect && originalImage.Size.Height > maxHeight)
			{
				//Height is the bigger dimension
				height = maxHeight;
				width = maxHeight * aspect;
			}

			return originalImage.Scale(new SizeF((float)width, (float)height)).AsJPEG().ToArray();
		}
		public static UIImage ImageFromByteArray(byte[] data)
		{
			if (data == null)
			{
				return null;
			}

			UIImage image;
			try
			{
				image = new UIImage(NSData.FromArray(data));
			}
			catch (Exception e)
			{
				Console.WriteLine("Image load failed: " + e.Message);
				return null;
			}
			return image;
		}

		private void LoadImageData()
		{


			new System.Threading.Thread(new System.Threading.ThreadStart(() =>
			{
				CommonData.FTPUpload(sImageName, sImagePath);
			})).Start();


			LoadSendData();

			// byte[] ReImageData = ResizeImage(originalImage, 400, 400);
			// sImageBase16 = Convert.ToBase64String(ReImageData);


			//sImageName = "Img" + NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString() + DateTime.Now.ToString("yyyyMMddHHmmss");

			//string[] sParam = objWSDemand.arrSplitString(sImageBase16 , 10);
			//var urlParam = new Dictionary<string, string>();
			//urlParam.Add("@FileString1", sParam[0]);
			//urlParam.Add("@FileString2", sParam[1]);
			//urlParam.Add("@FileString3", sParam[2]);
			//urlParam.Add("@FileString4", sParam[3]);
			//urlParam.Add("@FileString5", sParam[4]);
			//urlParam.Add("@FileString6", sParam[5]);
			//urlParam.Add("@FileString7", sParam[6]);
			//urlParam.Add("@FileString8", sParam[7]);
			//urlParam.Add("@FileString9", sParam[8]);
			//urlParam.Add("@FileString10", sParam[9]);
			//urlParam.Add("@AudFileName", sImageName);
			//urlParam.Add("@FileMode", "Image");
			//objWSDemand.GetWebDataTask(resultImageCompletion, _webFunction.GET_Save_Attachment, urlParam);


		}

		void resultImageCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			string res = wDatas[0].Result.ToString();
			if (res == "True")
			{
				LoadSendData();
			}
			else
			{
				Toast.MakeText("OTP Timeout.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

			}
		}

		private void LoadAudioData()
		{

			new System.Threading.Thread(new System.Threading.ThreadStart(() =>
			{
				CommonData.FTPUpload(sAudioName, sAudioPath);
			})).Start();




			if (isImage == true)
			{
				LoadImageData();
			}
			else {
				LoadSendData();
			}

			//string ftpHost = "ftp://jewelsxchange.com/chataudios/audio/" + sAudioName;

			//string ftpUser = "jxchngservice.mark.com|jxchngservice@mark.com";

			//string ftpPassword = "daw00d@js";

			////string ftpfullpath = "ftp://myserver.com/testme123.jpg";

			//FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpHost);

			////userid and password for the ftp server  

			//ftp.Credentials = new NetworkCredential(ftpUser, ftpPassword);

			//ftp.KeepAlive = true;
			//ftp.UseBinary = true;
			//ftp.Method = WebRequestMethods.Ftp.UploadFile;
			//ftp.UsePassive = false;

			//FileStream fs = File.OpenRead(sAudioPath);//storedAudioPath + fileName + Common.EXTN_AUDIO);

			//byte[] buffer = new byte[fs.Length];
			//fs.Read(buffer, 0, buffer.Length);

			//fs.Close();

			//System.IO.Stream ftpstream = ftp.GetRequestStream();
			//ftpstream.Write(buffer, 0, buffer.Length);
			//ftpstream.Close();
			//ftpstream.Flush();


			//string[] sParam = objWSDemand.arrSplitString(sAudioBase16 ,10);
			//var urlParam = new Dictionary<string, string>();
			//urlParam.Add("@FileString1", sParam[0]);
			//urlParam.Add("@FileString2", sParam[1]);
			//urlParam.Add("@FileString3", sParam[2]);
			//urlParam.Add("@FileString4", sParam[3]);
			//urlParam.Add("@FileString5", sParam[4]);
			//urlParam.Add("@FileString6", sParam[5]); 
			//urlParam.Add("@FileString7", sParam[6]);
			//urlParam.Add("@FileString8", sParam[7]);
			//urlParam.Add("@FileString9", sParam[8]);
			//urlParam.Add("@FileString10",sParam[9]);
			//urlParam.Add("@AudFileName", sAudioName );
			//urlParam.Add("@FileMode", "Audio");
			//objWSDemand.GetWebDataTask(resultAudioCompletion, _webFunction.GET_Save_Attachment , urlParam);
		}

		void resultAudioCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			if (wDatas == null){ return;}

			string res = wDatas[0].Result.ToString();
			if (res == "True")
			{
				if (isImage == true)
				{
					LoadImageData();
				}
				else {
					LoadSendData();
				}
			}
			else
			{
				Toast.MakeText("OTP Timeout.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
			}
		}


		partial void TabControl_Selection(UISegmentedControl sender)
		{
			var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
			if (selectedSegmentId == 0)
			{
				//pnlStock.Hidden = false;
				//pnlCloseout.Hidden = true;
				sBusinessType = "Gold Jewelry";
			}
			else
			{
				//pnlStock.Hidden = true;
				//pnlCloseout.Hidden = false;
				sBusinessType = "Diamond Jewelry";
			}
		}



		//partial void BtnMoreFilter_TouchUpInside(UIButton sender)
		//{
		//	pnlSearchFilter.Hidden = false;
		//	pnlSearchFilter.Frame = new CoreGraphics.CGRect(0, 250, 317, 314);
		//}


		//Start
		partial void BtnSearchClose_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = true;
		}

		//partial void BtnSearchDone_TouchUpInside(UIButton sender)
		//{
		//	SetSearchData();
		//}





		partial void BtnSearchRegion_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sRegionPH;
			if (sRegionSelectionData == "")
			{
				//LoadRegionData("AMSWHO01", "GJ", 0);//Apply "Chat_Receiver"
				LoadRegionAllData();
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadRegionAllData() 
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@BullionTypeCode", "Gold Jewelry");
		
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_MASTER_ALLREGION, urlParam);
		}

		private void LoadRegionData(string LoggedCompanyCode, string sBType, int closeoutPrice)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			objWSRegion.GetWebDataTask(resultRegionCompletion, _webFunction.GET_MASTER_REGION, urlParam);
		}

		void resultRegionCompletion(ObservableCollection<Master.Region> wDatas)
		{
			List<Master.Region> mModels = new List<Master.Region>(wDatas);
			objRegion = mModels;
			objRegionSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		partial void BtnSearchWorkType_TouchUpInside(UIButton sender)
		{
			if (sRegionSelectionData == "")
			{
				Toast.MakeText("Select Region.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sWorkTypePH;
			if (sWorkTypeSelectionData == "")
			{
				LoadWorkTypeData("AMSWHO01", "GJ", 0, sRegionSelectionData);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadWorkTypeData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@RegionCode", sRegionData);
			objWSWorkType.GetWebDataTask(resultWorkTypeCompletion, _webFunction.GET_MASTER_WORKTYPE, urlParam);
		}

		void resultWorkTypeCompletion(ObservableCollection<Master.WorkType> wDatas)
		{
			List<Master.WorkType> mModels = new List<Master.WorkType>(wDatas);
			objWorkType = mModels;
			objWorkTypeSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		partial void BtnSearchCategory_TouchUpInside(UIButton sender)
		{

			if (sRegionSelectionData == "")
			{
				Toast.MakeText("Select Region.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			if (sWorkTypeSelectionData == "")
			{
				Toast.MakeText("Select WorkType.", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
				return;

			}
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sCategoryPH;
			if (sCategorySelectionData == "")
			{
				LoadCategoryData("AMSWHO01", "GJ", 0, sRegionSelectionData, sWorkTypeSelectionData);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadCategoryData(string LoggedCompanyCode, string sBType, int closeoutPrice, string sRegionData, string sWorkType)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			urlParam.Add("@WorkTypeCode", sRegionData);
			urlParam.Add("@Region", sWorkType);
			objWSCategory.GetWebDataTask(resultCategoryCompletion, _webFunction.GET_MASTER_CATEGORY, urlParam);
		}

		void resultCategoryCompletion(ObservableCollection<Master.Category> wDatas)
		{
			List<Master.Category> mModels = new List<Master.Category>(wDatas);
			objCategory = mModels;
			objCategorySearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}



		partial void BtnSearchKarat_TouchUpInside(UIButton sender)
		{
			pnlSearch.Hidden = false;
			txtSearchBar.Placeholder = sKaratPH;
			if (sKaratSelectionData == "")
			{
				LoadKaratData("AMSWHO01", "GJ", 0);
			}
			else
			{
				TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
				TableViewStock.ReloadData();
			}
		}

		private void LoadKaratData(string LoggedCompanyCode, string sBType, int closeoutPrice)
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode", LoggedCompanyCode);
			urlParam.Add("@BusinessType", sBType);
			urlParam.Add("@CloseOutPrice", closeoutPrice.ToString());
			objWSKarat.GetWebDataTask(resultKaratCompletion, _webFunction.GET_MASTER_KARAT, urlParam);
		}

		void resultKaratCompletion(ObservableCollection<Master.Karat> wDatas)
		{
			List<Master.Karat> mModels = new List<Master.Karat>(wDatas);
			objKarat = mModels;
			objKaratSearch = mModels;
			TableViewStock.Source = new TableSourceSearch(this, txtSearchBar.Placeholder.Trim());
			TableViewStock.ReloadData();
		}

		public void SetSearchData()
		{
			int i = 0;
			switch (txtSearchBar.Placeholder)
			{
				case sRegionPH:
					sRegionSelectionData = "";
					//sWorkTypeSelectionData = "";
					//sCategorySelectionData = "";
					//sKaratSelectionData = "";

					for (i = 0; i <= objRegion.Count - 1; i++)
					{
						if (objRegion[i].bStatus == true)
						{
							if (sRegionSelectionData.Trim() == "")
							{
								sRegionSelectionData = objRegion[i].JewelRegionCode;
								txtRegion.Text = objRegion[i].JewelRegionName;
							}
							else
							{
								sRegionSelectionData =  objRegion[i].JewelRegionCode;
								txtRegion.Text = objRegion[i].JewelRegionName;
							}
						}
					}
					//txtRegion.Text = sRegionSelectionData;
					//txtKarat.Text = "";
					//txtCategory.Text = "";
					//txtWorkType.Text = "";
					break;
				case sWorkTypePH:

					sWorkTypeSelectionData = "";
					//sCategorySelectionData = "";
					//sKaratSelectionData = "";

					for (i = 0; i <= objWorkType.Count - 1; i++)
					{
						if (objWorkType[i].bStatus == true)
						{
							if (sWorkTypeSelectionData.Trim() == "")
							{
								sWorkTypeSelectionData = objWorkType[i].WorkTypeName;
								txtWorkType.Text = objWorkType[i].WorkTypeName;
							}
							else
							{
								sWorkTypeSelectionData =  objWorkType[i].WorkTypeName;
								txtWorkType.Text =  objWorkType[i].WorkTypeName;

							}
						}
					}

					//txtWorkType.Text = sData;
					//txtKarat.Text = "";
					//txtCategory.Text = "";
					break;
				case sCategoryPH:

					//sCategorySelectionData = "";
					//sKaratSelectionData = "";

					for (i = 0; i <= objCategory.Count - 1; i++)
					{
						if (objCategorySearch[i].bStatus == true)
						{
							if (sCategorySelectionData.Trim() == "")
							{
								sCategorySelectionData = objCategory[i].JewelCategoryName;
								txtCategory.Text = objCategory[i].JewelCategoryName;
							}
							else
							{
								sCategorySelectionData =  objCategory[i].JewelCategoryName;
								txtCategory.Text = objCategory[i].JewelCategoryName;

							}
						}
					}

					//txtWorkType.Text = sData;
					txtKarat.Text = "";

					break;
				case sKaratPH:

					sKaratSelectionData = "";

					for (i = 0; i <= objKaratSearch.Count - 1; i++)
					{
						if (objKaratSearch[i].bStatus == true)
						{
							if (sKaratSelectionData.Trim() == "")
							{
								sKaratSelectionData = objKarat[i].JewelMetalKaratName;
								txtKarat.Text = objKarat[i].JewelMetalKaratName;
							}
							else
							{
								sKaratSelectionData =  objKarat[i].JewelMetalKaratName;
								txtKarat.Text =  objKarat[i].JewelMetalKaratName;

							}
						}
					}

					//txtWorkType.Text = sData;

					break;
			}
			pnlSearch.Hidden = true;
		}



		//partial void BtnCloseFilter_TouchUpInside(UIButton sender)
		//{
		//	pnlSearchFilter.Hidden = true;
		//}

		//partial void BtnFilter_TouchUpInside(UIButton sender)
		//{
		//	pnlSearchFilter.Hidden = false;
		//	pnlSearchFilter.Frame = new CoreGraphics.CGRect(0, 62, 320, 506);
		//}
		//End


		//partial void BtnCamara_TouchUpInside(UIButton sender)
		//{
		//	imagePicker = new UIImagePickerController();

		//	imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
		//	imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);

		//	imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
		//	imagePicker.Canceled += Handle_Canceled;

		//	NavigationController.PresentModalViewController(imagePicker, true);
		//}



		//partial void BtnAdd_TouchUpInside(UIButton sender)
		//{
		//	imagePicker = new UIImagePickerController();

		//	imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
		//	imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

		//	imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
		//	imagePicker.Canceled += Handle_Canceled;

		//	NavigationController.PresentModalViewController(imagePicker, true);
		//}



		private void Handle_Canceled(object sender, EventArgs e)
		{
			imagePicker.DismissModalViewController(true);
		}

		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			
			switch (e.Info[UIImagePickerController.MediaType].ToString())
			{
				case "public.image":
					Console.WriteLine("Image selected");
					isImage = true;
					break;
				case "public.video":
					Console.WriteLine("Video selected");
					break;
			}

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine("Url:" + referenceURL.ToString());

			// if it was an image, get the other image info
			if (isImage)
			{
				// get the original image
				 originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if (originalImage != null)
				{
					// do something with the image
					imageView.Image = originalImage; // display

					var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					sImageName = "Img" + NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
					string jpgFilename = System.IO.Path.Combine(documentsDirectory, sImageName); // hardcoded filename, overwritten each time
					if (File.Exists(jpgFilename) == true)
					{
						File.Delete(jpgFilename);
					}
					sImagePath  = jpgFilename;

					NSData imgData = originalImage.AsJPEG();
					NSError err = null;
					if (imgData.Save(jpgFilename, false, out err))
					{
						Console.WriteLine("Image selected");
					}
				}

				UIImage editedImage = e.Info[UIImagePickerController.EditedImage] as UIImage;
				if (editedImage != null)
				{
					// do something with the image
					Console.WriteLine("got the edited image");
					imageView.Image = editedImage;
				}
			}

			// dismiss the picker
			imagePicker.DismissModalViewController(true);
		}

		public class TableSourceSearch : UITableViewSource
		{
			ViewController_Demand owner;
			private UISearchDisplayController search;
			//List<ResultJewelry> models;
			//List<ResultJewelry> modelsSearch;
			private string sSearchType = "";
			string CellIdentifier = "TableCell";

			public TableSourceSearch()
			{

			}
			public TableSourceSearch(ViewController_Demand owner, string sSearchType)
			{
				//this.models = models;
				//this.modelsSearch = this.models;
				this.owner = owner;
				search = owner.searchDisplayController;
				this.sSearchType = sSearchType;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{

				if (sSearchType == sRegionPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetRegionMaster()[indexPath.Row].bStatus;
					this.GetRegionMaster()[indexPath.Row].bStatus = !this.GetRegionMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
					owner.SetSearchData();
				}
				else if (sSearchType == sWorkTypePH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetWorkTypeMaster()[indexPath.Row].bStatus;
					this.GetWorkTypeMaster()[indexPath.Row].bStatus = !this.GetWorkTypeMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
					owner.SetSearchData();
				}
				else if (sSearchType == sCategoryPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetCategoryMaster()[indexPath.Row].bStatus;
					this.GetCategoryMaster()[indexPath.Row].bStatus = !this.GetCategoryMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
					owner.SetSearchData();
				}
				else if (sSearchType == sKaratPH)
				{
					UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
					cell.Selected = !this.GetKaratMaster()[indexPath.Row].bStatus;
					this.GetKaratMaster()[indexPath.Row].bStatus = !this.GetKaratMaster()[indexPath.Row].bStatus;
					tableView.ReloadData();
					owner.SetSearchData();
				}

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


				if (sSearchType == sRegionPH)
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
				else if (sSearchType == sWorkTypePH)
				{
					if (GetWorkTypeMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetWorkTypeMaster().Count;
					}
				}
				else if (sSearchType == sCategoryPH)
				{
					if (GetCategoryMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetCategoryMaster().Count;
					}
				}
				else
				{
					if (GetKaratMaster() == null)
					{
						return 0;
					}
					else
					{
						return GetKaratMaster().Count;
					}
				}



				//return modelsSearch.Count;
			}
			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 40;
			}


			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell;

				if (sSearchType == sRegionPH)
				{
					cell.UpdateCellRegionMaster(GetRegionMaster(), indexPath);
				}
				else if (sSearchType == sWorkTypePH)
				{
					cell.UpdateCellWorkTypeMaster(GetWorkTypeMaster(), indexPath);
				}
				else if (sSearchType == sCategoryPH)
				{
					cell.UpdateCellCategoryMaster(GetCategoryMaster(), indexPath);
				}
				else if (sSearchType == sKaratPH)
				{
					cell.UpdateCellKaratMaster(GetKaratMaster(), indexPath);
				}

				return cell;
			}

			private List<Master.Region> GetRegionMaster()
			{

				return owner.objRegionSearch;//search.Active ? owner.objRegion :

			}

			private List<Master.WorkType> GetWorkTypeMaster()
			{

				return owner.objWorkTypeSearch;//search.Active ? owner.objWorkType :



			}
			private List<Master.Category> GetCategoryMaster()
			{

				return owner.objCategorySearch;//search.Active ? owner.objCategory :


			}
			private List<Master.Karat> GetKaratMaster()
			{

				return owner.objKaratSearch;//search.Active ? owner.objKarat :


			}
		}

		public class RecordAudioService //: IRecordAudioService
		{
			AVAudioRecorder _recorder;
			NSError _error;
			NSUrl _url;
			NSDictionary _settings;
			bool _isRecord = false;
			public  string _Audiopath;
			public string _AudioFileName;
			public bool InitializeRecordService()
			{
				return InitializeRecordService("");


			}

			public bool InitializeRecordService(string path = "")
			{
				var audioSession = AVAudioSession.SharedInstance();
				var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
				if (err != null)
				{
					Console.WriteLine("audioSession: {0}", err);
					return false;
				}
				err = audioSession.SetActive(true);
				if (err != null)
				{
					Console.WriteLine("audioSession: {0}", err);
					return false;
				}

				//Declare string for application temp path and tack on the file extension
				if (path.Length == 0)
				{
					
					path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//Path.GetTempPath();
				}

				_AudioFileName = "Aud" + NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".wav";//string.Format("audio{0}.wav", DateTime.Now.ToString("yyyyMMddHHmmss"));
				string audioFilePath = Path.Combine(path, _AudioFileName);

				Console.WriteLine("Audio File Path: " + audioFilePath);
				_Audiopath = audioFilePath;

				_url = NSUrl.FromFilename(audioFilePath);
				//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
				NSObject[] values = new NSObject[]
				{
				NSNumber.FromFloat (44100.0f), //Sample Rate
                NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM  ), //AVFormat
                NSNumber.FromInt32 (2), //Channels
                NSNumber.FromInt32 (16), //PCMBitDepth
                NSNumber.FromBoolean (false), //IsBigEndianKey
                NSNumber.FromBoolean (false) //IsFloatKey
				};

				//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
				NSObject[] keys = new NSObject[]
				{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVLinearPCMBitDepthKey,
				AVAudioSettings.AVLinearPCMIsBigEndianKey,
				AVAudioSettings.AVLinearPCMIsFloatKey
				};

				//Set Settings with the Values and Keys to create the NSDictionary
				_settings = NSDictionary.FromObjectsAndKeys(values, keys);

				//Set recorder parameters
				_recorder = AVAudioRecorder.Create(_url, new AudioSettings(_settings), out _error);

				//Set Recorder to Prepare To Record


				return _recorder.PrepareToRecord();
			}

			public bool Record(string path)
			{

				if (_recorder == null || _isRecord)
				{
					return false;
				}

				if (!InitializeRecordService(path))
				{
					return false;
				}

				_recorder.Record();
				_isRecord = true;
				return true;
			}

			public bool IsRecording()
			{
				return _isRecord;
			}

			public byte[] StopRecord()
			{
				if (_recorder == null || !_isRecord)
				{
					return default(byte[]);
				}

				_recorder.Stop();
				_isRecord = false;


				byte[] FileByte = File.ReadAllBytes(_Audiopath);
				//		string base16 = Convert.ToBase64String(FileByte);

				//var bytes = default(byte[]);
				//using (var streamReader = new StreamReader(_path))
				//{
				//	using (var memstream = new MemoryStream())
				//	{
				//		streamReader.BaseStream.CopyTo(memstream);
				//		bytes = memstream.ToArray();

				//	}
				//}

				//File.Delete(_Audiopath);

				return FileByte;

			}

		}


	}




}

