namespace JewelsExchange.iOS
{
	public class Message
	{
		public MessageType Type { get; set; }
		public string Text { get; set; }

		public string MsgId { get; set; }
		public string SenderJid { get; set; }
		public string ReceiverJid { get; set; }
		public string Messages { get; set; }
		public string MsgType { get; set; }
		public string AudioFileName { get; set; }
		public string ImgFileName { get; set; }
		public string CreatedDate { get; set; }
		public string Status { get; set; }
		public string Platform { get; set; }
		public string IsReceive { get; set; }
	}
}

