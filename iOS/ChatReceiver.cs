using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IOS.Widget;
using Twilio.Common;
using Twilio.IPMessaging;

using 
namespace JewelsExchange.iOS
{
	public class ChatReceiver : Java.Lang.Object, IPMessagingClientListener, IChannelListener, ITwilioAccessManagerListener
	{
		ITwilioIPMessagingClient client;
		IChannel generalChannel;
		private static ChatReceiver objChat;
		Context ctx;
		IncomingMsgDelegate objDelgIncoming;

		//async Task<string> GetIdentity()
		//{
		//	var androidId = Android.Provider.Settings.Secure.GetString(ContentResolver,
		//						Android.Provider.Settings.Secure.AndroidId);

		//	// If you are using PHP it will be $"https://YOUR_TOKEN_SERVER_URL/token.php?device={androidId}"
		//	var tokenEndpoint = $"http://chat.jewelsxchange.com/token?device={androidId}";

		//	var http = new HttpClient();
		//	var data = await http.GetStringAsync(tokenEndpoint);

		//	var json = System.Json.JsonObject.Parse(data);

		//	var identity = json["identity"]?.ToString()?.Trim('"');
		//	this.ActionBar.Subtitle = $"Logged in as {identity}";
		//	var token = json["token"]?.ToString()?.Trim('"');

		//	return token;
		//}

		private ChatReceiver(Context ctx)
		{
			this.ctx = ctx;
			//initializeChat();
		}

		public static ChatReceiver objMyChat(Context ctx)
		{
			if (objChat == null)
				objChat = new ChatReceiver(ctx);

			return objChat;

		}

		public async void initializeChat()
		{

			TwilioIPMessagingSDK.SetLogLevel((int)Android.Util.LogPriority.Debug);

			if (!TwilioIPMessagingSDK.IsInitialized)
			{
				Console.WriteLine("Initialize");

				TwilioIPMessagingSDK.InitializeSDK(ctx, new InitListener
				{
					InitializedHandler = async delegate
					{
						await Setup();
					},
					ErrorHandler = err =>
					{
						Console.WriteLine(err.Message);
					}
				});
			}
			else {
				await Setup();
			}
		}

		public void initilizeDeligateIncoming(IncomingMsgDelegate objDelgIncoming)
		{
			this.objDelgIncoming = objDelgIncoming;
		}
		async Task<string> GetIdentity()
		{
			var androidId = Android.Provider.Settings.Secure.GetString(ctx.ContentResolver,
								Android.Provider.Settings.Secure.AndroidId);

			// If you are using PHP it will be $"https://YOUR_TOKEN_SERVER_URL/token.php?device={androidId}"
			var tokenEndpoint = $"http://chat.jewelsxchange.com/token?device={androidId}";

			var http = new HttpClient();
			var data = await http.GetStringAsync(tokenEndpoint);

			//var json = System.Json.JsonObject.Parse(data);
			var response = Newtonsoft.Json.JsonConvert.DeserializeObject<TwilioResponse>(data);

			//var identity = json["identity"]?.ToString()?.Trim('"');
			////this.ActionBar.Subtitle = $"Logged in as {identity}";
			//var token = json["token"]?.ToString()?.Trim('"');
			//Identity = response.Identity?.Trim('"') ?? string.Empty;

			return response?.Token?.Trim('"') ?? string.Empty;

			//return token;
		}

		async Task Setup()
		{
			var token = await GetIdentity();
			var accessManager = TwilioAccessManagerFactory.CreateAccessManager(token, this);
			client = TwilioIPMessagingSDK.CreateIPMessagingClientWithAccessManager(accessManager, this);

			client.Channels.LoadChannelsWithListener(new StatusListener
			{
				SuccessHandler = () =>
				{
					generalChannel = client.Channels.GetChannelByUniqueName("general");

					if (generalChannel != null)
					{
						generalChannel.Listener = this;
						JoinGeneralChannel();
					}
					else
					{
						CreateAndJoinGeneralChannel();
					}
				}
			});
		}

		public void OnTokenExpired(ITwilioAccessManager p0)
		{
			Console.WriteLine("token expired");
		}

		public void OnTokenUpdated(ITwilioAccessManager p0)
		{
			Console.WriteLine("token updated");
		}

		void JoinGeneralChannel()
		{
			generalChannel.Join(new StatusListener
			{
				SuccessHandler = () =>
				{
					Activity a = (Activity)ctx;
					a.RunOnUiThread(() =>
					   Toast.MakeText(ctx, "Joined general channel!", ToastLength.Short).Show());
				}
			});
		}

		void CreateAndJoinGeneralChannel()
		{
			var options = new Dictionary<string, Java.Lang.Object>();
			options["friendlyName"] = "General Chat Channel";
			options["ChannelType"] = ChannelChannelType.ChannelTypePublic;
			client.Channels.CreateChannel(options, new CreateChannelListener
			{
				OnCreatedHandler = channel =>
				{
					generalChannel = channel;
					channel.SetUniqueName("general", new StatusListener
					{
						SuccessHandler = () => { Console.WriteLine("set unique name successfully!"); }
					});
					this.JoinGeneralChannel();
				},
				OnErrorHandler = () => { }
			});
		}

		public void OnMessageAdd(IMessage message)
		{
			Console.WriteLine(message);
			objDelgIncoming(message);
			//adapter.AddMessage(message);
			//listView.SmoothScrollToPosition(adapter.Count - 1);
		}

		public void OnAttributesChange(string p0)
		{

		}

		public void OnChannelAdd(IChannel p0)
		{

		}

		public void OnChannelChange(IChannel p0)
		{

		}

		public void OnChannelDelete(IChannel p0)
		{

		}

		public void OnChannelHistoryLoaded(IChannel p0)
		{

		}

		public void OnError(IErrorInfo p0)
		{

		}

		public void OnUserInfoChange(IUserInfo p0)
		{

		}

		public void OnAttributesChange(IDictionary<string, string> p0)
		{

		}

		public void OnMemberChange(IMember p0)
		{

		}

		public void OnMemberDelete(IMember p0)
		{

		}

		public void OnMemberJoin(IMember p0)
		{

		}

		public void OnMessageChange(IMessage p0)
		{

		}

		public void OnMessageDelete(IMessage p0)
		{

		}

		public void OnTypingEnded(IMember p0)
		{

		}

		public void OnTypingStarted(IMember p0)
		{

		}

		public void OnError(ITwilioAccessManager p0, string p1)
		{

		}
		public delegate void IncomingMsgDelegate(IMessage message);
	}

	public class CreateChannelListener : ConstantsCreateChannelListener
	{
		public Action<IChannel> OnCreatedHandler { get; set; }
		public Action OnErrorHandler { get; set; }

		public override void OnCreated(IChannel channel)
		{
			OnCreatedHandler?.Invoke(channel);
		}

		public override void OnError(IErrorInfo errorInfo)
		{
			base.OnError(errorInfo);
		}
	}
}
