using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using JewelsExchange.Webservices;
using System.IO;
using System.Net;
using AVFoundation;

namespace JewelsExchange.iOS
{
   partial class TableCell : UITableViewCell
	{
		partial void BtnDownloadSender_TouchUpInside(UIButton sender)
		{
			AudioDownload(lblAudioPath.Text );
		}

		private async void AudioDownload(string sAudioName)
		{
			var webClient = new WebClient();


			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string localPath;// = "AudioCheck.mp3";

			localPath = Path.Combine(documentsPath, sAudioName);


			await webClient.DownloadFileTaskAsync(
							new Uri("http://service.jewelxchange.com/chataudios/audio/"+ sAudioName ),
							localPath);//+".mp3"
		}


		AVAudioPlayer player;
		partial void BtnPlaySender_TouchUpInside(UIButton sender)
		{
			if (File.Exists(lblAudioPath.Text ) == true)
			{
				try
				{
					
					NSUrl songURL;
					if (player == null)
					{
						String filePath = lblAudioPath.Text;
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
						btnStopSender.Hidden = false;
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

			}
		}



		private async void LoadDownload()
		{
			var destination = Path.Combine(
				System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.ApplicationData),
					"music.mp3");

			await new WebClient().DownloadFileTaskAsync(

					new Uri("http://service.jewelxchange.com/chataudios/audio/AudKannan20170130172409.mp3"),
					destination);
		}
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

		public void UpdateChatCell(List<Chating> models,NSIndexPath indexPath)
		{
			//Demond
			//Image
			//Audio




			if (models[indexPath.Row].MsgType == "Text")
			{
				if (models[indexPath.Row].IsReceive == "False")
				{

					txtSender.Text = models[indexPath.Row].Messages;
					txtReceive.Hidden = true;
					txtReceive.Text = "";
				

				}
				else
				{
					txtReceive.Text = models[indexPath.Row].Messages;
					txtSender.Hidden = true;
					txtSender.Text = "";
				}
			}
			if (models[indexPath.Row].MsgType == "Demand")
			{
				if (models[indexPath.Row].IsReceive == "False")
				{

					txtSender.Text = models[indexPath.Row].Messages;

					//txtReceive.Hidden = true;
					//txtReceive.Text = ""
					if (models[indexPath.Row].AudioFileName != "")
					{
						lblAudioPath.Text = models[indexPath.Row].AudioFileName;
						btnPlaySender.Hidden = false;
					}
					else
					{
						lblAudioPath.Text = "";
					}
					txtReceive.Hidden = true;
					txtReceive.Text = "";

				}
				else
				{
					txtReceive.Text = models[indexPath.Row].Messages;
					if (models[indexPath.Row].AudioFileName != "")
					{
						lblAudioPath.Text = models[indexPath.Row].AudioFileName;
						btnDownloadReceive.Hidden = false;
					}
					else
					{
						lblAudioPath.Text = "";
					}
					txtSender.Hidden = true;
					txtSender.Text = "";
				}
			}


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
