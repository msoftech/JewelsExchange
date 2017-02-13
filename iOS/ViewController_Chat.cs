using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using AVFoundation;
using JewelsExchange.Webservices;
using KBCustomActionSheet;
using Quickblox.Sdk.Modules.ChatXmppModule;
using ToastIOS;
using UIKit;
using System.IO;
using AudioToolbox;
using System.Net;
using AVKit;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Net.Http;



//[assembly: Dependency(typeof(AudioService))]
namespace JewelsExchange.iOS
{
	public partial class ViewController_Chat : UIViewController//,IRecordAudioService
	{

		public ViewController_Chat() : base("ViewController_Chat", null)
		{

		}

		public ViewController_Chat(IntPtr ptr) : base(ptr)
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
			chatinit();
			//subb();
			//return;
				

			int myUserID = (int)NSUserDefaults.StandardUserDefaults.IntForKey("Chat_Sender_QuickBoxID");
			String myPassword = NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender_QuickBoxID_Password").ToString();


			ChatOn.objMyChat().initilizeDeligateIncoming(onMessageReceiveStatus, onErrorMessage);
			ChatOn.objMyChat().initilizeDemondDeligateIncoming(onMessageReceiveDemondStatus);
			ChatOn.objMyChat().LoginUser(myUserID, myPassword);


		}

		private async void chatinit()
		{
			await ChatOn.objMyChat().InitializeQBoxClient();
		}

		void onMessageReceiveDemondStatus(string sMsg,string sAudioPath,string sImagePath)
		{

			loadmsg("D",sMsg,sAudioPath,sImagePath );

		}


		void onMessageReceiveStatus(MessageEventArgs messageEventArgs)
		{

			loadmsg("R");

		}

		void onErrorMessage(String error)
		{
			Toast.MakeText(error, Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();

		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}


		partial void UIButton12675_TouchUpInside(UIButton sender)
		{
			//DependencyService.Get().Play_Pause("http://www.montemagno.com/sample.mp3");




			//AVPlayer avp;
			//AVPlayerViewController avpvc;


			//AVAudioSession avSession = AVAudioSession.SharedInstance();

			//avSession.SetCategory(AVAudioSessionCategory.Playback);

			//NSError activationError = null;
			//avSession.SetActive(true, out activationError);
			//if (activationError != null)
			//	Console.WriteLine("Could not activate audio session {0}", activationError.LocalizedDescription);
			

			//var url1 = NSUrl.FromString("http://johnnygold.com/music/croctears.mp3");
			//avp = new AVPlayer(url1);
			//avpvc = new AVPlayerViewController();



			//avpvc.Player = avp;
			//AddChildViewController(avpvc);
			//View.AddSubview(avpvc.View);
			//avpvc.View.Frame = View.Frame;
			//avpvc.ShowsPlaybackControls = true;
			//if (avp.Status == AVPlayerStatus.ReadyToPlay)
			//{
			//	avp.Play();
			//}
			//System.IO.files
			//return;

			//App.AudioManager.

			//SystemSound.FromFile("http://service.jewelxchange.com/chataudios/audio/AudKannan20170130172409.mp3");

			//LoadDownload();
			this.PerformSegue("34", sender);
			//Console.Write("Text");
		}

		string localPath = "";
		private async void LoadDownload()
		{

			if (localPath != "")
			{
				if (File.Exists(localPath) == true)
				{

					//2

					try
					{
						AVAudioPlayer player=null;
						NSUrl songURL;
						if (player == null)
						{
							String filePath = localPath;//CreatePathToUserAccessibleFile(Resource_151.RecordingFolderName) + "/" + filename;
							AVAudioSession audioSession = AVAudioSession.SharedInstance();
							audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
							audioSession.SetActive(true);
							songURL = new NSUrl(filePath);
							NSData data = NSData.FromFile(filePath);
							NSError err;
							player = new AVAudioPlayer(data, songURL.PathExtension, out err);
							//player.FinishedPlaying += player_FinishedPlaying;
							player.PrepareToPlay();
							player.Play();
						}
						else
						{
							if (player.Playing == true)
							{
								player.Pause();
							}
							else
							{
								player.Play();
							}
						}
					}
					catch (Exception ex)
					{
						Console.Out.WriteLine(ex.StackTrace);
					}
					//2



				}
				return;
			}




			var webClient = new WebClient();


				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				string localFilename = "AudioCheck.mp3";
				
				localPath = Path.Combine(documentsPath, localFilename);

		
				await webClient.DownloadFileTaskAsync(
								new Uri("http://service.jewelxchange.com/chataudios/audio/AudioCheck.mp3"),
								localPath);



				if (File.Exists(localPath) == true)
				{

				}




		
		}
		partial void BtnSend_TouchUpInside(UIButton sender)
		{
			if (txtmsg.Text == "")
			{
				return;
			}
			ChatOn.objMyChat().SendMessage((int)NSUserDefaults.StandardUserDefaults.IntForKey("Chat_Receiver_QuickBoxID"), txtmsg.Text );
			SaveSendData();
			loadmsg("S");

		}

		//TableSource adapter;
		WebDataModel<Chating> viewModel = new WebDataModel<Chating>();
		WebDataModel<VerifyOTP> objWbService = new WebDataModel<VerifyOTP>();

		List<Chating> localModels = new List<Chating>();
		bool isloading = false;


		//partial void BtnUser_TouchUpInside(UIButton sender)
		//{
		//	subb();
		//}

		private async void subb()
		{
			await ChatOn.objMyChat().CreateNewUser("kannan1ashogan@gmail.com", "Kannan1Ashogan", "Kannan@1234");
			string ss = ChatOn.objMyChat().sUserID;

		}

		public void SaveSendData()
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@SenderJId", NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString());
			urlParam.Add("@ReceiverJId", NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Receiver").ToString());
			urlParam.Add("@Messages", txtmsg.Text);
			//urlParam.Add("@MsgType", "Text");
			urlParam.Add("@AudioFileName", "");
			urlParam.Add("@ImgFileName", "");
			urlParam.Add("@Status", "0");
			urlParam.Add("@Platform", "IOS");
			objWbService.GetWebDataTask(resultSaveCompletion, _webFunction.TEMP_CHAT, urlParam);
		}

		void resultSaveCompletion(ObservableCollection<VerifyOTP> wDatas)
		{
			if (wDatas[0].Result == "True")
			{
				Console.Write("Saved");
			}
			else
			{
				Console.Write("Not Saved");
			}


		}
		private void loadmsg(string stype,string sDemandMsg = "",string sDemandAudioPath ="",string sDemandImagePath ="")
		{
			try
			{
				if (stype == "R")
				{
					loadData();
					//return;
				}
				else if (stype == "S")
				{
					List<Chating> tModels = new List<Chating>();

					Chating temp = new Chating();
					temp.MsgType = "Text";
					temp.IsReceive = "False";
					temp.Messages = txtmsg.Text ;

					tModels.Add(temp);

					localModels.AddRange(tModels);

					TableViewStock.Source = new TableSource(this);
					TableViewStock.ReloadData();

					ScrollToLastMsg();

				}
				else if (stype == "D")
				{
					List<Chating> tModels = new List<Chating>();

					Chating temp = new Chating();
					temp.MsgType = "Demand";
					temp.Messages = "Demond Details : " + "/n" + sDemandMsg;
					temp.IsReceive = "False";
					temp.AudioFileName = sDemandAudioPath;
					temp.ImgFileName = sDemandImagePath;

					tModels.Add(temp);

					localModels.AddRange(tModels);

					TableViewStock.Source = new TableSource(this);
					TableViewStock.ReloadData();

					ScrollToLastMsg();

				}

			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
			isloading = false;
		}

		private void ScrollToLastMsg()
		{
			//var path = NSIndexPath.FromRowSection(TableViewStock.NumberOfRowsInSection(0) - 1, TableViewStock.NumberOfSections() - 1);
			//TableViewStock.ScrollToRow(path, UITableViewScrollPosition.Bottom, false);
		}

		public void loadData()
		{
			
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@SenderJId", NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Receiver").ToString());
			urlParam.Add("@ReceiverJId", NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString());
			urlParam.Add("@Messages", "");
			//urlParam.Add("@MsgType", "");
			urlParam.Add("@AudioFileName", "");
			urlParam.Add("@ImgFileName", "");
			urlParam.Add("@Status", "");
			urlParam.Add("@Platform", "");
		
			viewModel.GetWebDataTask(resultCompletion, _webFunction.TEMP_CHAT, urlParam);
		}


		void resultCompletion(ObservableCollection<Chating> wDatas)
		{
			List<Chating> mModels = new List<Chating>(wDatas);
			//mModels[0].MsgType = "Text";
			//mModels[0].
			if (localModels.Count == 0)
			{
				localModels.AddRange(mModels);
			}
			else
			{
				localModels.AddRange(mModels);
			}

			InvokeOnMainThread(() => { 
			TableViewStock.Source = new TableSource(this);

				TableViewStock.ReloadData();
				ScrollToLastMsg();
			});


		}

		public class TableSource : UITableViewSource
		{
			ViewController_Chat owner;
			//public event EventHandler<SongSelectedEventArgs> SongSelected;
			string CellIdentifier = "TableCell";

			public TableSource(ViewController_Chat owner)
			{
				this.owner = owner;
			}

			//public void addVal(List<Chating> listModel) {
			//	localModels.AddRange(listModel);
			
			//}

			//public override void Scrolled(UIScrollView scrollView)
			//{
			//	//          Globals.refreshView.DidScroll ();
			//	//Console.WriteLine("TV Scrolled!");
			//	//if (models.Count == scrollView.v
			//	if (owner.isLoding == true)
			//	{
			//		return;
			//	}
			//	float height = (float)scrollView.Frame.Size.Height;
			//	float distanceFromBottom = (float)(scrollView.ContentSize.Height - scrollView.ContentOffset.Y);

			//	if (distanceFromBottom < height)
			//	{
			//		owner.LoadProcessStart();
			//		//Toast.MakeText("Loding...", Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Bottom ).SetBgRed(30).Show();
			//		owner.loadData("AMSWHO01", owner.sIsCloseOut, owner.sRegionSelectionData, owner.sWorkTypeSelectionData, owner.sCategorySelectionData, owner.sKaratSelectionData, models.Count, models.Count + 5);
			//		//owner.loadData("AMSWHO01", "N", "100", "100", "100", "109", models.Count , models.Count + 5);
			//		owner.isLoding = true;
			//	}

			//}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{


				//var index = indexPath.Row;

				//ViewController_StockDetails controller = owner.Storyboard.InstantiateViewController("ViewController_StockDetails") as ViewController_StockDetails;
				//controller.sStockNumber = models[indexPath.Row].StockNumber;
				//controller.sCompanyCode = models[indexPath.Row].CompanyCode;


				//owner.NavigationController.PushViewController(controller, true);

				//tableView.DeselectRow(indexPath, true);


			}


			public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
			{
				return true;
			}

			//public override nint NumberOfSections(UITableView tableView)
			//{
			//	if (models == null)
			//	{
			//		//var rect = new CoreGraphics.CGRect(0, 0, tableView.Bounds.Width, tableView.Bounds.Height);

			//		UIImageView iv = new UIImageView(tableView.Bounds);
			//		iv.Image = UIImage.FromBundle("Tick1");
			//		iv.ContentMode = UIViewContentMode.Center;

			//		tableView.BackgroundView = iv;

			//		return 0;
			//	}
			//	else
			//	{
			//		UIView.Animate(0.5, () =>
			//		{
			//			if (tableView.BackgroundView != null)
			//			{
			//				tableView.BackgroundView.Alpha = 0.0f;
			//				tableView.BackgroundView = null;
			//			}
			//		});

			//		return 1;
			//	}

			//}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				//if (models == null)
				//{
				//	return 0;
				//}
				//else if (models.Count == 0)
				//{
				//	return 0;
				//}
				//else {
					return owner.localModels.Count;
				//}
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 100;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier) as TableCell ??
						 new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier) as TableCell;
				if (cell != null)
				{
					cell.UpdateChatCell(owner.localModels, indexPath);
					return cell;
				}
				else
				{
					return null;
				}
			}


		}//End tablesource class



		public class RecordAudioService //: IRecordAudioService
		{
			AVAudioRecorder _recorder;
			NSError _error;
			NSUrl _url;
			NSDictionary _settings;
			bool _isRecord = false;
			string _path;

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
					path = Path.GetTempPath();
				}

				string fileName = string.Format("audio{0}.wav", DateTime.Now.ToString("yyyyMMddHHmmss"));
				string audioFilePath = Path.Combine(path, fileName);

				Console.WriteLine("Audio File Path: " + audioFilePath);
				_path = audioFilePath;

				_url = NSUrl.FromFilename(audioFilePath);
				//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
				NSObject[] values = new NSObject[]
				{
				NSNumber.FromFloat (44100.0f), //Sample Rate
                NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM), //AVFormat
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


				var bytes = default(byte[]);
				using (var streamReader = new StreamReader(_path))
				{
					using (var memstream = new MemoryStream())
					{
						streamReader.BaseStream.CopyTo(memstream);
						bytes = memstream.ToArray();

					}
				}

				File.Delete(_path);

				return bytes;

			}

		}



	
	//Start Audio Class
	public class AudioService : IAudio
	{
		int clicks = 0;
			NSError err;
		public AudioService() { }
		AVPlayer player;
		public bool Play_Pause(string url)
		{
			if (clicks == 0)
			{
				//this.player = new AVAudioPlayer(NSUrl.FromString(url), "mp3", out err);
					this.player = new AVPlayer();
				this.player = AVPlayer.FromUrl(NSUrl.FromString(url));
				this.player.Play();
				clicks++;
			}
			else if (clicks % 2 != 0)
			{
				this.player.Pause();
				clicks++;

			}
			else {
				this.player.Play();
				clicks++;
			}
			return true;

		}

		public bool Stop(bool val)
		{
			if (player != null)
			{
				player.Dispose();
				clicks = 0;
			}
			return true;
		}
	}



	public interface IAudio
	{
		bool Play_Pause(string url);
		bool Stop(bool val);
	}

	//End Audio Class
		}
}

