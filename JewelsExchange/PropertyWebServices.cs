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
	public class SentOTP
	{
		public string RandomNumber { get; set; }
		public string Date { get; set; }

	}

	public class VerifyOTP
	{
		public string Result { get; set; }

	}
	public class Master
	{
		public class Region
		{
			public string JewelRegionCode { get; set; }
			public string JewelRegionName { get; set; }
			public bool bStatus { get; set; }
		}

		public class WorkType
		{
			public string WorkTypeCode { get; set; }
			public string WorkTypeName { get; set; }
			public bool bStatus { get; set; }
		}

		public class Category
		{
			public string JewelCategoryCode { get; set; }
			public string JewelCategoryName { get; set; }
			public bool bStatus { get; set; }
		}

		public class Karat
		{
			public string JewelMetalKaratCode { get; set; }
			public string JewelMetalKaratName { get; set; }
			public bool bStatus { get; set; }
		}

		public class Country
		{
			public string CountryCode { get; set; }
			public string CountryName { get; set; }
			public string PhoneCode { get; set; }
			public bool bStatus { get; set; }
		}

	}

	public class StockList
	{
		public string rn { get; set; }
		public string FavouriteCompany { get; set; }
		public string CompanyName { get; set; }
		public string GoldJewelryStockCode { get; set; }
		public string CompanyCode { get; set; }
		public string JewelBaseDescCode { get; set; }
		public string JewelSubDescCode { get; set; }
		public string StockNumber { get; set; }
		public string Karat { get; set; }
		public string IsMixedKarat { get; set; }
		public string WeightGms { get; set; }

		public string Currency { get; set; }
		public string MakingChargesApplicable { get; set; }
		public string MakingChargesPerGm { get; set; }
		public string MakingChargesRetailer { get; set; }
		public string MetalLossPercent { get; set; }
		public string CloseOutPrice { get; set; }
		public string Reason { get; set; }
		public string Remarks { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedDate { get; set; }
		public string CreatedBy { get; set; }

		public string UpdatedBy { get; set; }
		public string CurrencyName { get; set; }
		public string JewelRegionName { get; set; }
		public string WorkTypeName { get; set; }
		public string JewelCategoryName { get; set; }
		public string JewelBaseDescName { get; set; }
		public string JewelSubDescName { get; set; }
		public string JewelMetalKaratName { get; set; }
		public string CloseOutResonName { get; set; }
	
	}
	public class StockDetails
	{
		public string GoldJewelryStockCode { get; set; }
		public string CompanyCode { get; set; }
		public string JewelBaseDescCode { get; set; }
		public string JewelSubDescCode { get; set; }
		public string StockNumber { get; set; }
		public string Karat { get; set; }
		public string IsMixedKarat { get; set; }
		public string WeightGms { get; set; }
		public string Currency { get; set; }

		public string MakingChargesApplicable { get; set; }
		public string MakingChargesPerGm { get; set; }
		public string MakingChargesRetailer { get; set; }
		public string MetalLossPercent { get; set; }
		public string CloseOutPrice { get; set; }
		public string Reason { get; set; }
		public string Remarks { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedDate { get; set; }

		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public string BullionType { get; set; }
		public string CompanyName { get; set; }
		public string UserName { get; set; }
		public string CurrencyName { get; set; }
		public string Mobile { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }

		public string JewelRegionName { get; set; }
		public string WorkTypeName { get; set; }
		public string JewelCategoryName { get; set; }
		public string JewelBaseDescName { get; set; }
		public string JewelSubDescName { get; set; }
		public string JewelMetalKaratName { get; set; }
	
	}
	//static class urlService { public static string WEBSERVICE { private get; set; }}

}
