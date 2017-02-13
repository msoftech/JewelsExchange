using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

using Quickblox.Sdk;
using Quickblox.Sdk.Modules.ChatModule.Models;
using Quickblox.Sdk.Modules.ChatXmppModule;
using Quickblox.Sdk.Modules.UsersModule.Requests;
using UIKit;

namespace JewelsExchange.iOS
{
	public partial class ChatOn
	{
		private static ChatOn _objChat;
		private static QuickbloxClient _quickbloxClient;
		private int _UserID;
		private String _Passwd;
		private IncomingMsgDelegate objDelgIncoming;
		private IncomingDemondMsgDelegate objDelgDemondIncoming;
		private IncomingDemondMsgDelegate_ChatImage objDelgDemondIncoming_ChatImage;

		private ErrorDelegate objErrorDel;
		public string sUserID = "";
		private ChatOn()
		{
			Quickblox.Sdk.Platform.QuickbloxPlatform.Init();

		}
		//public static class ApplicationKeys
		//{
		//    //public const int ApplicationId = 52677;
		//    //public const string AuthorizationKey = "4dWHHgGWXYz8FZq";
		//    //public const string AuthorizationSecret = "BTFsj7Rtt27DAmT";
		//    //public const string ApiBaseEndpoint = "http://api.quickblox.com";
		//    //public const string ChatEndpoint = "chat.quickblox.com";
		//    //public const string ChatMucEndpoint = "muc." + ChatEndpoint;

		//    const int applicationId = 52677;
		//    const String authKey = "Hp9zVxgqNg-hbwV";
		//    const String authSecret = "ee4vhYTVf5SBpTB";
		//    const string ApiBaseEndpoint = "https://api.quickblox.com";
		//    const string ChatEndpoint = "chat.quickblox.com";
		//    const string ChatMucEndpoint = "muc." + ChatEndpoint;

		//}


		public static ChatOn objMyChat()
		{
			if (_objChat == null)
				_objChat = new ChatOn();


			//InitializeQBoxClient();

			return _objChat;

		}


		public async Task InitializeQBoxClient()
		{

			if (_quickbloxClient == null)
			{
				const int applicationId = 52677;
				const String authKey = "Hp9zVxgqNg-hbwV";
				const String authSecret = "ee4vhYTVf5SBpTB";
				const string ApiBaseEndpoint = "https://api.quickblox.com";
				const string ChatEndpoint = "chat.quickblox.com";
				const string ChatMucEndpoint = "muc." + ChatEndpoint;

				_quickbloxClient = new QuickbloxClient(applicationId, authKey, authSecret,
														  ApiBaseEndpoint, ChatEndpoint);
				//if (reIntialize)
				//{
				try
				{
					var sessionResponse = await _quickbloxClient.AuthenticationClient.CreateSessionBaseAsync();
					Console.WriteLine(sessionResponse.StatusCode);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
				//    }
				//    else{
				//        var sessionResponse = _quickbloxClient.AuthenticationClient.CreateSessionBaseAsync();
				//        Console.WriteLine(sessionResponse);
				//}



				//return sessionResponse.StatusCode;
			}

			//return (System.Net.HttpStatusCode)_quickbloxClient.AuthenticationClient.GetSessionAsync().Status;
			//else if (quickbloxClient.)

			//return quickbloxClient;
		}

		public async Task<bool> CreateNewUser(String mail, String name, String passwd)//TaskCompletedDelegate delegateResult,
		{

			var userSignUpRequest = new UserSignUpRequest
			{
				User = new UserRequest()
				{
					Email = mail,//"jinga@email.com",
					FullName = name,
					Password = passwd
				}
			};

			var response = await _quickbloxClient.UsersClient.SignUpUserAsync(userSignUpRequest);// (userSignUpRequest);
																								 //Console.WriteLine(response.StatusCode);

			if (response.StatusCode == HttpStatusCode.Created)
			{
				sUserID = response.Result.User.Id.ToString();
				return true;
			}
			else
			{
				sUserID = "";
				return false;
			}

		}

		//public async Task<bool> CreateNewUser(String mail, String name, String passwd)
		//{

		//	var userSignUpRequest = new UserSignUpRequest
		//	{
		//		User = new UserRequest()
		//		{
		//			Email = mail,//"jinga@email.com",
		//			FullName = name,
		//			Password = passwd
		//		}
		//	};

		//	var response = await _quickbloxClient.UsersClient.SignUpUserAsync(userSignUpRequest);// (userSignUpRequest);
		//																						 //Console.WriteLine(response.StatusCode);

		//	if (response.StatusCode  == HttpStatusCode.Created)
		//		//response.Result.User.Id 
		//		return true;
		//	else
		//		return false;

		//}

		public async void LoginUser(int UserID, String Passwd)
		{

			if (_quickbloxClient == null || _quickbloxClient.Token == null)
				InitializeQBoxClient();
			else if (_isServerConnected() == false)
			{
				objErrorDel("Chat Login Failed. No Internet Connection");
				//Toast.MakeText(ctx, "Chat Login Failed. No Internet Connection", ToastLength.Short).Show();
				return;
			}

			Console.WriteLine(_quickbloxClient.Token);
			this._UserID = UserID;
			this._Passwd = Passwd;
			if (_quickbloxClient.ChatXmppClient.IsConnected == false)
			{
				await _quickbloxClient.ChatXmppClient.Connect(UserID, Passwd);
				_quickbloxClient.ChatXmppClient.MessageReceived += EventMessageReceived;
			}

		}
		public bool isConnected()
		{

			if (_quickbloxClient == null || _quickbloxClient.Token == null || _quickbloxClient.ChatXmppClient.IsConnected == false)
			{
				return false;
			}
			else
				return true;

		}
		private void _ReLoginconnect()
		{
			LoginUser(_UserID, _Passwd);
			//await _quickbloxClient.ChatXmppClient.Connect(_UserID, _Passwd);
			//return conn.
			//quickbloxClient.ChatXmppClient.MessageReceived += EventMessageReceived;
		}
		public void VeryfyConnection()
		{
			LoginUser(_UserID, _Passwd);
			//await _quickbloxClient.ChatXmppClient.Connect(_UserID, _Passwd);
			//return conn.
			//quickbloxClient.ChatXmppClient.MessageReceived += EventMessageReceived;
		}

		private bool _isServerConnected()
		{
			if (_quickbloxClient.Token == null)
				return false;
			else
				return true;
		}
		//quickbloxClient.ChatXmppClient.MessageReceived += (object sender, MessageEventArgs messageEventArgs)=> {
		//            Console.WriteLine(messageEventArgs.Message);
		//        };

		void EventMessageReceived(object sender, MessageEventArgs messageEventArgs)
		{
			Console.WriteLine(messageEventArgs.Message);

			String dialogID = messageEventArgs.Message.ChatDialogId;
			Console.WriteLine(dialogID);
			objDelgIncoming(messageEventArgs);

			//_quickbloxClient.ChatClient.;
		}


		public void ChatDemondNotification(string sMsg,string sAudioPath,string sImagePath)
		{
			objDelgDemondIncoming(sMsg,sAudioPath,sImagePath );
		}

		public void ChatImageNotification(string sImageName)
		{
			objDelgDemondIncoming_ChatImage(sImageName);
		}

		public void SendMessage(int ToUserID, String Msg)
		{

			//var dialogName = "New room";
			//DialogType dialogType = DialogType.Group;
			//var userIds = new List<int>() { .... };
			//var dialogResponse = await quickbloxClient.ChatClient.CreateDialogAsync(dialogName, dialogType, userIds);



			//var privateChatManager = _quickbloxClient.ChatXmppClient.Get (ToUserID,"53db8798535c125e8e000902");
			//privateChatManager.MessageReceived += (object sender, MessageEventArgs messageEventArgs)=>{
			//    // This event was fired only for current private dialog
			//};

			try
			{
				if (_quickbloxClient.ChatXmppClient.IsConnected == false)
				{
					_ReLoginconnect();
				}
				if (_quickbloxClient.ChatXmppClient.IsConnected == true)
				{
					//_quickbloxClient.ChatXmppClient.SendMessage(ToUserID, Msg);
					//var extraParamsList = new List<System.Xml.Linq.XElement>();
					//extraParamsList.Add(new System.Xml.Linq.XElement((System.Xml.Linq.XName)"save_to_history", 1));

					_quickbloxClient.ChatXmppClient.SendMessage(ToUserID, Msg);

				}
				else
					objErrorDel("Please Check your Internet Connection");
				//Toast.MakeText(ctx, "Please Check your Internet Connection", ToastLength.Long).Show();
				//extraParamsList.Add(new System.Xml.Linq.XElement((System.Xml.Linq.XName)"send_to_chat", 1));
				//extraParamsList.Add(new System.Xml.Linq.XElement((System.Xml.Linq.XName)"message_text", Msg));
				//var extraParams = new System.Xml.Linq.XElement((System.Xml.Linq.XName)"msgm", extraParamsList.ToArray());
				//_quickbloxClient.ChatXmppClient.SendMessage(ToUserID, Msg, extraParams, null, null, Xmpp.Im.MessageType.Normal);
				//var dialogName = "PrivateRoom";
				//var dialog = await _quickbloxClient.ChatClient.CreateDialogAsync(dialogName, DialogType.Private, ""+ToUserID);

				//var privateChatManager = _quickbloxClient.ChatXmppClient.Get (ToUserID,"53db8798535c125e8e000902");

				//var privateManager =
				//    App.QbProvider.GetXmppClient()
				//        .GetPrivateChatManager(selectedUsers.First().Id, dialog.Id);

				//_quickbloxClient.a
				//var encodedMessage = System.Net.WebUtility.UrlEncode(Msg);
				//var privateChatManager = _quickbloxClient.ChatXmppClient.GetPrivateChatManager(ToUserID, dialog.Result.Id);


				//privateChatManager.SendMessage(Msg);
			}
			catch (Exception ex)
			{
				objErrorDel("No Internet Connection");
			}
		}

		public void initilizeDeligateIncoming(IncomingMsgDelegate objDelgIncoming, ErrorDelegate ErrorDel)
		{
			this.objDelgIncoming = objDelgIncoming;
			this.objErrorDel = ErrorDel;
		}

		public void initilizeDemondDeligateIncoming(IncomingDemondMsgDelegate objDelgDemondIncoming)
		{
			this.objDelgDemondIncoming = objDelgDemondIncoming;
		
		}

		public void initilizeDemondDeligateIncoming_ChatImage(IncomingDemondMsgDelegate_ChatImage objDelgDemondIncoming_ChatImage)
		{
			this.objDelgDemondIncoming_ChatImage = objDelgDemondIncoming_ChatImage;

		}

		public delegate void IncomingMsgDelegate(MessageEventArgs messageEventArgs);
		public delegate void IncomingDemondMsgDelegate(string DemandMsg,string DemandAudioPath,string demandImagePath);
		public delegate void IncomingDemondMsgDelegate_ChatImage(string ImageName);

		public delegate void ErrorDelegate(String txt);

	}
}

