using System;
namespace JewelsExchange.Webservices
{
	
		public class ResultJewelry
		{
			public string mCompanyName { get; set; }
			public string JewelMetalKaratName { get; set; }
			public string WeightGms { get; set; }
			public string mCurrency { get; set; }
			public string JewelCategoryName { get; set; }
			public string JewelBaseDescName { get; set; }
			public string mEmail { get; set; }
			public string CloseOutPrice { get; set; }
			public string StockNumber { get; set; }
			public string CompanyCode { get; set; }
			public string JewelRegionName { get; set; }

		}

	public class GetDataFromWebservice
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }
		public string Image { get; set; }
		public int Population { get; set; }

	}
	//static class urlService { public static string WEBSERVICE { private get; set; }}

}
