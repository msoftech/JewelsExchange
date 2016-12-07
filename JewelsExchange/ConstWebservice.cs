﻿using System;
namespace JewelsExchange
{
	public class _webFunction
	{
		private static string WEBSERVICE = "http://service.jewelxchange.com/service1.asmx/";
		//
		public  static readonly string LOGIN_VALIDATE = WEBSERVICE + "_validateLogin";
		public static readonly string GET_GOLD_STOCKS = WEBSERVICE + "_getGoldStockListJSON";//"_getGoldStockList";
		public static readonly string GET_GOLD_DETAILS = WEBSERVICE + "_getGoldStockDetail";
//	public static final String GET_MASTER_DETAILS = "_getStockMasters";
		public static readonly string GET_MASTER_REGION = WEBSERVICE + "_FetchRegionRequestedCompany";
		public static readonly string GET_MASTER_WORKTYPE = WEBSERVICE + "_FetchWorkTypeRequestedCompany";

	}

	public class Common
	{
		
		//private static readonly string WEBSERVICE = "http://service.jewelxchange.com/service1.asmx/";

	}

}
