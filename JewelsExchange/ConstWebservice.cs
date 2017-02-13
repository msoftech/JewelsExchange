using System;
namespace JewelsExchange
{
	public class _webFunction
	{
		private static string WEBSERVICE = "http://service.jewelxchange.com/service1.asmx/";
		//abc
		public  static readonly string LOGIN_VALIDATE = WEBSERVICE + "_validateLogin";


//	public static final String GET_MASTER_DETAILS = "_getStockMasters";



		//Master
		public static readonly string GET_MASTER_REGION = WEBSERVICE + "_FetchRegionRequestedCompany";
		public static readonly string GET_MASTER_WORKTYPE = WEBSERVICE + "_FetchWorkTypeRequestedCompany";
		public static readonly string GET_MASTER_CATEGORY = WEBSERVICE + "_FetchCategoryRequestedCompany";
		public static readonly string GET_MASTER_KARAT = WEBSERVICE + "_FetchKaratRequestedCompany";
		public static readonly string GET_MASTER_ALLREGION = WEBSERVICE + "JewelRegionMaster";
		public static readonly string GET_MASTER_ALLCATEGORY = WEBSERVICE + "JewelCategoryMaster";

		//Stock Search from Master
		public static readonly string GET_GOLD_STOCKS = WEBSERVICE + "_getGoldStockList";
		public static readonly string GET_GOLD_DETAILS = WEBSERVICE + "_getGoldStockDetail";



		public static readonly string GET_OTP = WEBSERVICE + "LoginORVerifyLogin";
		public static readonly string GET_CHK_XName = WEBSERVICE + "CheckJewelXchangeName";
		public static readonly string GET_Save_Retail = WEBSERVICE + "RegistrationFromMobile";
		public static readonly string GET_Save_CompRule = WEBSERVICE + "InsertBTCatRegionForCompany";
		public static readonly string GET_Save_ChkCompData = WEBSERVICE + "CheckCmpnyEmailExists";
		public static readonly string GET_Save_SaveImage = WEBSERVICE + "_storeFiles";
		public static readonly string GET_Save_Attachment = WEBSERVICE + "StoreImgAud";


		public static readonly string TEMP_CHAT = WEBSERVICE + "TempChat";
		public static readonly string GET_Save_Demand = WEBSERVICE + "_InsertDemandAttachment";
		public static readonly string GET_ChatRequest = WEBSERVICE + "UserChatRequest";
	}

	public class Common
	{
		
		//private static readonly string WEBSERVICE = "http://service.jewelxchange.com/service1.asmx/";

	}

}
