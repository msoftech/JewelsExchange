using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Foundation;
using JewelsExchange.Webservices;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ViewController_ChatList : UIViewController
	{




		WebDataModel<ChatRequest> viewModel = new WebDataModel<ChatRequest>();


		partial void BtnSendChatRequest_TouchUpInside(UIButton sender)
		{
			SendChatRequest();
		}

		partial void BtnIDSearch_TouchUpInside(UIButton sender)
		{
			if (string.IsNullOrWhiteSpace(txtJewelsExchangeID.Text))
			{
				CommonData.MessageBox("JewelXchange ID should not be empty.");
				return;
			}
			loadExchangeIDDetails();
		}


		public void loadExchangeIDDetails()
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@FromJewelXchangeId",NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString());
			urlParam.Add("@Mode", "");
			urlParam.Add("@ToJewelXchangeId",txtJewelsExchangeID.Text.Trim());
			urlParam.Add("@Platform", "");
			viewModel.GetWebDataTask(resultLoadCompletion, _webFunction.GET_ChatRequest, urlParam);
		}

		void resultLoadCompletion(ObservableCollection<ChatRequest> wDatas)
		{
			if (wDatas==null) return;

			if (wDatas[0].Result == "False")
			{
				CommonData.MessageBox("Invalid ID.");
				return;
			}
			if (wDatas[0].Result == "Already")
			{
				CommonData.MessageBox("This ID already in ur list.");
				return;
			}
			if (wDatas[0].Result == "True")
				{
				txtCompanyName.Text = wDatas[0].CompanyName ;
				txtContactName.Text = wDatas[0].FirstName;
				txtEmailID.Text = wDatas[0].Email;
				txtPhone.Text = wDatas[0].Phone3;
				txtType.Text = wDatas[0].CompanyType;
				lblJewelXchangeID.Text = wDatas[0].JewelsExchangeID;
				lblQuickBoxID.Text = wDatas[0].QuickBoxID;
				txtJewelsExchangeID.Text = string.Empty;
			}
		}

		public void SendChatRequest()
		{
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@FromJewelXchangeId",NSUserDefaults.StandardUserDefaults.StringForKey("Chat_Sender").ToString()); 
			urlParam.Add("@Mode", "Insert");
			urlParam.Add("@ToJewelXchangeId", lblJewelXchangeID.Text.Trim());
			urlParam.Add("@Platform", "IOS");
			viewModel.GetWebDataTask(resultSendCompletion, _webFunction.GET_ChatRequest, urlParam);
		}
		void resultSendCompletion(ObservableCollection<ChatRequest> wDatas)
		{
			if (wDatas == null) return;

			if (wDatas[0].Result == "True")
			{
					ChatOn.objMyChat().SendMessage(Convert.ToInt32(lblQuickBoxID.Text), "ChatRequest");
				txtCompanyName.Text = "";
				txtContactName.Text = "";
				txtEmailID.Text = "";
				txtPhone.Text = "";
				txtType.Text = "";
				lblJewelXchangeID.Text = "";
				lblQuickBoxID.Text = string.Empty;
				txtJewelsExchangeID.Text = string.Empty;
				pnlChatRequest.Hidden = true;

				//ChatOn.objMyChat().ChatDemondNotification("Demond :\n");
			}
		}
		partial void UIButton12884_TouchUpInside(UIButton sender)
		{
			
			this.PerformSegue("TempChat", sender);
		}

		//UIScrollView scroll_View;


		//partial void BtnHomeSearch12_TouchUpInside(UIButton sender)
		//{
		//	NSUserDefaults.StandardUserDefaults.SetString("Kannan", "Chat_Receiver");
		//	this.PerformSegue("12", sender);
		//}

		public ViewController_ChatList() : base("ViewController_ChatList", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			NSUserDefaults.StandardUserDefaults.SetString("Shiddic", "Chat_Receiver");
			NSUserDefaults.StandardUserDefaults.SetString("KannanJEN", "Chat_Sender");

			NSUserDefaults.StandardUserDefaults.SetInt(23066602, "Chat_Receiver_QuickBoxID");
			NSUserDefaults.StandardUserDefaults.SetInt(23160095, "Chat_Sender_QuickBoxID");
			NSUserDefaults.StandardUserDefaults.SetString("Kannan@1234", "Chat_Sender_QuickBoxID_Password");
			//NSUserDefaults.StandardUserDefaults.SetString("123456789", "Chat_Sender_QuickBoxID_Password");

			//CommonData.mCompanyName = "Kannan";


			//NSUserDefaults.StandardUserDefaults.SetString("KannanJEN", "Chat_Receiver");
			//NSUserDefaults.StandardUserDefaults.SetString("Shiddic", "Chat_Sender");

			//NSUserDefaults.StandardUserDefaults.SetInt(23160095, "Chat_Receiver_QuickBoxID");
			//NSUserDefaults.StandardUserDefaults.SetInt(23066602, "Chat_Sender_QuickBoxID");
			////NSUserDefaults.StandardUserDefaults.SetString("Kannan@1234", "Chat_Sender_QuickBoxID_Password");
			//NSUserDefaults.StandardUserDefaults.SetString("123456789", "Chat_Sender_QuickBoxID_Password");
			this.Title = "Chat List";
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>
				  {
					  //NSObject CallSender = new NSObject();
					  //this.PerformSegue("CallDemand", CallSender);
				pnlChatRequest.Hidden = false;

				  })
				  , true);

			pnlChatRequest.Hidden = true;
			pnlChatRequest.Frame = new CoreGraphics.CGRect(0, NavigationController.NavigationBar.Frame.Height+25, View.Frame.Width, View.Frame.Height - NavigationController.NavigationBar.Frame.Height+25);

		}

		public ViewController_ChatList(IntPtr ptr) : base(ptr)
		{
			initialize();
		}

		private void initialize()
		{
			// do your initialization here
			//MOGUDOOM MOHAMED - TO CHECK THE SOURCE TREE CONTROL ON 13022017
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

