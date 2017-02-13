using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.IO;
using AVFoundation;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;

namespace JewelsExchange.iOS
{
	public abstract class BubbleCell : UITableViewCell
	{
		public UIImageView BubbleImageView { get; private set; }
		public UILabel MessageLabel { get; private set; }
	
		//public UIButton AudioDownloadButton { get; private set; }
		public UIButton AudioPlayButton { get; private set; }
		//public UIButton AudioStopButton { get; private set; }

		ChatViewController objChat;

			
		//public string sAudioFileName;
		//public string sImageFileName;

		public UIButton ImageAttachment { get; private set; }

		public UIImage BubbleImage { get; set; }
		public UIImage BubbleHighlightedImage { get; set; }

		Message msg;

		AVAudioPlayer player = null;
		NSUrl songURL;



		public Message Message {
			get {
				return msg;
			}
			set {
				msg = value;
				BubbleImageView.Image = BubbleImage;
				BubbleImageView.HighlightedImage = BubbleHighlightedImage;

				if (msg.MsgType == "Demand")
				{
					MessageLabel.Text = msg.Text + "\n" + "\n";
					if (msg.AudioFileName != "")
					{
						AudioPlayButton.Hidden = false;
						string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

						string localPath = Path.Combine(documentsPath, msg.AudioFileName);
						if (File.Exists(localPath) == true)
						{
							AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);

						}
						else
						{
							AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/DownloadSmall.png"), UIControlState.Normal);
						}
					}
					if (msg.ImgFileName != "")
					{
						ImageAttachment.Hidden = false;
						ImageAttachment.SetBackgroundImage(UIImage.FromFile("Final Image/AttachmentSmall.png"), UIControlState.Normal);
						//ImageAttachment.Hidden = false;
						//string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

						//string localPath = Path.Combine(documentsPath, msg.ImgFileName);
						//if (File.Exists(localPath) == true)
						//{
						//	ImageAttachment.SetBackgroundImage(UIImage.FromFile("noimg"), UIControlState.Normal);
						//}
						//else
						//{
						//	ImageAttachment.SetBackgroundImage(UIImage.FromFile(msg.ImgFileName), UIControlState.Normal);
						//}
					}
				}
				else
				{
					MessageLabel.Text = msg.Text;
				}

				MessageLabel.UserInteractionEnabled = true;
				BubbleImageView.UserInteractionEnabled = false;
			}
		}

		public BubbleCell (IntPtr handle)
			: base (handle)
		{
			Initialize ();
		}

		public BubbleCell ()
		{
			Initialize ();
		}
		//public BubbleCell(ChatViewController objChat)
		//{
		//	this.objChat = objChat;
		//}

		[Export ("initWithStyle:reuseIdentifier:")]
		public BubbleCell (UITableViewCellStyle style, string reuseIdentifier)
			: base (style, reuseIdentifier)
		{
			Initialize ();
		}

		void Initialize ()
		{
			BubbleImageView = new UIImageView {
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			MessageLabel = new UILabel {
				TranslatesAutoresizingMaskIntoConstraints = false,
				Lines = 0,
				PreferredMaxLayoutWidth = 220f
			};
			AudioPlayButton = new UIButton
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				Hidden = true
			};
			ImageAttachment = new UIButton
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				Hidden = true,

				};

			//ImageAttachment = UIButton.FromType(UIButtonType.Custom);
			//ImageAttachment.Frame.Width  = new RectangleF(100, 100, 60, 50);
			ImageAttachment.TouchUpInside += delegate
			{
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				//sAudioFileName = msg.AudioFileName;
				string localPath = Path.Combine(documentsPath, msg.ImgFileName);
				if (File.Exists(localPath) == true)
				{
					ChatOn.objMyChat().ChatImageNotification(msg.ImgFileName);

					//NSObject sender = new NSObject();
					//ViewController_Test controller = .Storyboard.InstantiateViewController("ViewController_Test") as ViewController_Test;
					//UINavigationController nav =new UINavigationController();
					//nav.PushViewController(ViewControlle, true);

					//ViewController_Test controller = objChat.Storyboard.InstantiateViewController("ViewController_Test") as ViewController_Test;
					//objChat.NavigationController.PushViewController(controller, true);


					//var storyboard = UIStoryboard.FromName("Main", null);
					//ViewController_Test controller = storyboard.InstantiateViewController("ViewController_Test") as ViewController_Test;
					//UINavigationController nav = new UINavigationController();
					//nav.PushViewController(controller, true);

					//nav.PerformSegue("ShowImage", sender);
				//	ImageAttachment.SetBackgroundImage(UIImage.FromFile("Attach1.png"), UIControlState.Normal);
				//}
				//else
				//{
				//	LoadDownloadImageFile(msg.ImgFileName);

				}
			};


			AudioPlayButton.TouchUpInside += delegate
			{
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				//sAudioFileName = msg.AudioFileName;
				string localPath = Path.Combine(documentsPath, msg.AudioFileName);
				if (File.Exists(localPath) == true)
				{
					try
					{
						if (player == null)
						{
							AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/StopSmall.png"), UIControlState.Normal);
							LoadAudioPlay(localPath);
						}
						else
						{
							if (player.Playing == true)
							{
								AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);
								player.Stop();
								player = null;
							}

						}
					}
					catch (Exception ex)
					{
						Console.Out.WriteLine(ex.StackTrace);
					}
				}
				else
				{
					LoadDownloadAudioFile(msg.AudioFileName);

				}
				//AudioStopButton.Hidden = false;
				//new UIAlertView("Touch1", "TouchUpInside handled", null, "OK", null).Show();
			};


			//AudioStopButton.TouchUpInside += delegate
			//{
			//	//new UIAlertView("Touch1", "TouchUpInside handled", null, "OK", null).Show();
			//	AudioStopButton.Hidden = true;
			//};
			//AudioDownloadButton.TouchUpInside += delegate
			//{
			//	new UIAlertView("Download", "TouchUpInside handled", null, "OK", null).Show();
			//};

			//AudioPlayButton = new UIButton
			//{
			//	TranslatesAutoresizingMaskIntoConstraints = false,
			//	Frame = new CoreGraphics.CGRect(160, 30, 30, 30),


			//};


			AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);
			//AudioStopButton.SetBackgroundImage(UIImage.FromFile("Final Image/StopSmall.png"), UIControlState.Normal);
			//AudioDownloadButton.SetBackgroundImage(UIImage.FromFile("Final Image/DownloadSmall.png"), UIControlState.Normal);

			ContentView.AddSubviews (BubbleImageView, MessageLabel,AudioPlayButton,ImageAttachment);//,AudioStopButton,AudioDownloadButton
		}

		private async void LoadDownloadAudioFile(string sAudioName)
		{
			var webClient = new WebClient();


			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//string localFilename = "AudioCheck.mp3";

			string localPath = Path.Combine(documentsPath, sAudioName);

			await webClient.DownloadFileTaskAsync(
							new Uri("http://service.jewelxchange.com/chatimages/Image/" + sAudioName),
							localPath);
			
			AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);
		}

		private async void LoadDownloadImageFile(string sImageName)
		{
			var webClient = new WebClient();


			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//string localFilename = "AudioCheck.mp3";

			string localPath = Path.Combine(documentsPath, sImageName);

			await webClient.DownloadFileTaskAsync(
							new Uri("http://service.jewelxchange.com/chatimages/Image/" + sImageName),
							localPath);

			ImageAttachment.SetBackgroundImage(UIImage.FromFile(sImageName), UIControlState.Normal);
		}
		private async void LoadAudioPlay(string sAudioPath)
		{
			await AudioPlay(sAudioPath);
		}


		private async Task AudioPlay(string sPath)
		{
			string filePath = sPath;//CreatePathToUserAccessibleFile(Resource_151.RecordingFolderName) + "/" + filename;
			AVAudioSession audioSession = AVAudioSession.SharedInstance();
			audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			audioSession.SetActive(true);
			songURL = new NSUrl(filePath);
			NSData data = NSData.FromFile(filePath);
			NSError err;
			player = new AVAudioPlayer(data, songURL.PathExtension, out err);
			player.FinishedPlaying += delegate
			{
				AudioPlayButton.SetBackgroundImage(UIImage.FromFile("Final Image/PlaySmall.png"), UIControlState.Normal);
				player.Stop();
				player = null;
			};//+= player_FinishedPlaying();
			player.PrepareToPlay();
			player.Play();
		}
		public override void SetSelected (bool selected, bool animated)
		{
			base.SetSelected (selected, animated);
			BubbleImageView.Highlighted = selected;
		}

		protected static UIImage CreateColoredImage (UIColor color, UIImage mask)
		{
			var rect = new CGRect (CGPoint.Empty, mask.Size);
			UIGraphics.BeginImageContextWithOptions (mask.Size, false, mask.CurrentScale);
			CGContext context = UIGraphics.GetCurrentContext ();
			mask.DrawAsPatternInRect (rect);
			context.SetFillColor (color.CGColor);
			context.SetBlendMode (CGBlendMode.SourceAtop);
			context.FillRect (rect);
			UIImage result = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();
			return result;
		}

		protected static UIImage CreateBubbleWithBorder (UIImage bubbleImg, UIColor bubbleColor)
		{
			bubbleImg = CreateColoredImage (bubbleColor, bubbleImg);
			CGSize size = bubbleImg.Size;

			UIGraphics.BeginImageContextWithOptions (size, false, 0);
			var rect = new CGRect (CGPoint.Empty, size);
			bubbleImg.Draw (rect);

			var result = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			return result;
		}



	}
}