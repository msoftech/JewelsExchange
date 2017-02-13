using System;
namespace JewelsExchange.iOS
{
	public class Chating
	{
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

	public class ChatRequest
	{
		public string CompanyName { get; set; }
		public string FirstName	 { get; set; }
		public string Phone3 { get; set; }
		public string Email { get; set; }
		public string CompanyType { get; set; }
		public string Result { get; set; }
		public string JewelsExchangeID { get; set; }
		public string QuickBoxID { get; set; }
	}
	//MOGUDOOM MOHAMED - TO CHECK THE SOURCE TREE CONTROL ON 13022017
}
