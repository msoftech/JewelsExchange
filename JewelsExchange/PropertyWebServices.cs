using System;
namespace JewelsExchange.Webservices
{
	
		public class ResultJewelry
		{
			public string mCompanyName { get; set; }
			public string mKarat { get; set; }
			public string mWeightGms { get; set; }
			public string mCurrency { get; set; }
			public string mJewelCategoryName { get; set; }
			public string mJewelBaseDescName { get; set; }
			public string mEmail { get; set; }
			public string mPrice { get; set; }
			public string mStockNo { get; set; }
			public string mCompanyCode { get; set; }

		}

	public class GetDataFromWebservice
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }
		public string Image { get; set; }
		public int Population { get; set; }

	}

}
