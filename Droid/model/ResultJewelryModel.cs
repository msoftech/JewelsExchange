using System;
namespace JewelsExchange.Droid
{
	public class ResultJewelryModel{
	
		private String mCompanyName;
		private String mKarat;
		private String mWeightGms;
		private String mCurrency;
		private String mPrice;
		private String mJewelCategoryName;
		private String mJewelBaseDescName;
		private String mEmail;
		private String mStockNo;
		private String mCompanyCode;
		
		public ResultJewelryModel(String mEmail, String mCompanyName, String mKarat, String mWeightGms, String mCurrency, String mJewelCategoryName, String mJewelBaseDescName, String mPrice, String mStockNo, String mCompanyCode)
		{
			this.mCompanyName = mCompanyName;
			this.mKarat = mKarat;
			this.mWeightGms = mWeightGms;
			this.mCurrency = mCurrency;
			this.mJewelCategoryName = mJewelCategoryName;
			this.mJewelBaseDescName = mJewelBaseDescName;
			this.mEmail = mEmail;
			this.mPrice = mPrice;
			this.mStockNo = mStockNo;
			this.mCompanyCode = mCompanyCode;
		}

		public ResultJewelryModel(String mJewelCategoryName)
		{
			
			this.mJewelCategoryName = mJewelCategoryName;
		}

		public String getCompanyName()
		{
			return mCompanyName;
		}
		public String getCompanyCode()
		{
			return mCompanyCode;
		}
		public String getStockNo()
		{
			return mStockNo;
		}
		public String getKarat()
		{
			return mKarat;
		}

		public String getWeightGms()
		{
			return mWeightGms;
		}

		public String getCurrency()
		{
			return mCurrency;
		}
		public String getPrice()
		{
			return mPrice;
		}

		public String getJewelCategoryName()
		{
			return mJewelCategoryName;
		}

		public String getJewelBaseDescName()
		{
			return mJewelBaseDescName;
		}
		public String getEmail()
		{
			return mEmail;
		}
	}
}
