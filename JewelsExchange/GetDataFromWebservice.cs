using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace JewelsExchange.Webservices
{
	//public class GetDataFromWebservice
	//{
	//	public string Name { get; set; }
	//	public string Location { get; set; }
	//	public string Details { get; set; }
	//	public string Image { get; set; }
	//	public int Population { get; set; }

	//}
	//public class GetDataFromWebservice2
	//{
	//	public string arsha { get; set; }
	//	public string Location { get; set; }
	//	public string Details { get; set; }
	//	public string Image { get; set; }
	//	public int Population { get; set; }

	//}

	public class WebDataModel<T> {
		//public ObservableCollection<GetDataFromWebservice> wDatas { get; } = new ObservableCollection<GetDataFromWebservice>();

		//public List<Dictionary<string, string>> resultListMap { get; } = new List<Dictionary<string, string>>();

		//public ObservableCollection<GetDataFromWebservice> wDatas { get; } = new ObservableCollection<GetDataFromWebservice>();


		//public ObservableCollection<T> wDatas { get; } = new ObservableCollection<T>();


		public async  void GetWebDataTask(TaskCompletedDelegate delegateResult,String url,Dictionary<string,string> urlParam = null)
		{
			try
			{
				if (urlParam != null) { 
					
					var enumerator = urlParam.GetEnumerator();
					int firstParam = 0;
					while (enumerator.MoveNext())
					{
						var pair = enumerator.Current;
						if (firstParam == 0)
							url += "?" + pair.Key.Replace("@", "") + "=" + pair.Value;
						else
							url += "&" + pair.Key.Replace("@", "") + "=" + pair.Value;
						
						firstParam += 1;
					}
					//url = "?" + url.Substring(1);
				}
				url = url.Replace(" ", "%20");
				
				var client = new HttpClient();
				var json =  await client.GetStringAsync(url);
				//var items = JsonConvert.DeserializeObject<List<GetDataFromWebservice>>(json);
				//json = json.Replace("{Table:","");
				//json = json.Remove(json.Length - 1);

				var items = JsonConvert.DeserializeObject<List<T>>(json); //ResultJewelryMd

				ObservableCollection<T> wDatas = new ObservableCollection<T>();
				foreach (var item in items)
					wDatas.Add(item);
				//UIApplication sa;
				delegateResult(wDatas);
				//TaskDelegate invokeResul;
				//invokeResul = (TaskDelegate)this;
				//invokeResul.taskCompletionResult();

				//foreach (var item in items) {
				//	Dictionary<string, string> datamap = new Dictionary<string, string>();
				//	datamap.Add(item.);
				//	resultListMap.Add(datamap);
				//}
					
					
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				
			}
		}

		public delegate void TaskCompletedDelegate(ObservableCollection<T> wDatas);

		//public List<Type> hell(string json) {
		//	r  JsonConvert.DeserializeObject<List<ResultJewelryMd>>(json);

		//}




	}





}
