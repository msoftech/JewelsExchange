using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using System.Linq;
using System.IO;
using System.Net.Http.Headers;

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
	class FileTransfer
	{
		public byte[] content;
		public string name;

		public FileTransfer(string name, byte[] content)
		{
			this.name = name;
			this.content = content;
		}
	}

	public class WebDataModel<T> {
		//public ObservableCollection<GetDataFromWebservice> wDatas { get; } = new ObservableCollection<GetDataFromWebservice>();

		//public List<Dictionary<string, string>> resultListMap { get; } = new List<Dictionary<string, string>>();

		//public ObservableCollection<GetDataFromWebservice> wDatas { get; } = new ObservableCollection<GetDataFromWebservice>();


		//public ObservableCollection<T> wDatas { get; } = new ObservableCollection<T>();


		public async  void GetWebDataTask(TaskCompletedDelegate delegateResult,String url,Dictionary<string,string> urlParam = null,Byte[] documentcontents = null)
		{
			try
				{
					url = url.Replace(" ", "%20");

					String json;

					var client = new HttpClient();
					if (urlParam != null)
					{
					var newDictionary = urlParam
					   .Select(x => new KeyValuePair<string, string>(x.Key.Replace("@", ""), x.Value))
					   .ToDictionary(x => x.Key, x => x.Value);
					
						var content = new FormUrlEncodedContent(newDictionary);
						var response = await client.PostAsync(url, content);

						json = await response.Content.ReadAsStringAsync();

					}
					else
						json = await client.GetStringAsync(url);

					var items = JsonConvert.DeserializeObject<List<T>>(json); //ResultJewelryMd

					ObservableCollection<T> wDatas = new ObservableCollection<T>();
					foreach (var item in items)
						wDatas.Add(item);
					delegateResult(wDatas);
				}
				catch (Exception ex)
				{
					delegateResult(null);
					Debug.WriteLine(ex);

				}

				
		}


		public async void UploadImage(String url,byte[] photoBytes)

		{
			//2
			var httpClient = new HttpClient();

			var content = new MultipartFormDataContent();

			var fileContent = new ByteArrayContent(photoBytes);

			//fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
			fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

			fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")

			{

				FileName = "image.jpg",

				Name = "file"

			};

			content.Add(fileContent);

			//await _httpClient.PostAsync(ApiConfiguration.UploadUri, content);
			await httpClient.PostAsync(url, content);
			//2



			//3

		


			//3










			//1
			//var httpClient = new HttpClient();
			//httpClient.DefaultRequestHeaders.TransferEncodingChunked = true;

			//var content = new MultipartFormDataContent();
			//var imageContent = new StreamContent(new FileStream("my_path.jpg", FileMode.Open, FileAccess.Read, FileShare.Read));
			//imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
			//content.Add(imageContent, "image", "image.jpg");

			//await httpClient.PostAsync(url, content);
			//1


		}

		private System.IO.Stream Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
		{
			HttpContent stringContent = new StringContent(paramString);
			HttpContent fileStreamContent = new StreamContent(paramFileStream);
			HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
			using (var client = new HttpClient())
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(stringContent, "param1", "param1");
				formData.Add(fileStreamContent, "file1", "file1");
				formData.Add(bytesContent, "file2", "file2");
				var response = client.PostAsync(actionUrl, formData).Result;
				if (!response.IsSuccessStatusCode)
				{
					return null;
				}
				return response.Content.ReadAsStreamAsync().Result;
			}
		}
		public delegate void TaskCompletedDelegate(ObservableCollection<T> wDatas);

		public String[] arrSplitString(String strLong, int totalSplit)
		{
			String[] arrStr = new String[totalSplit];
			int iSingleLength = (strLong.Length) / totalSplit;
			int iStringLength = 0;
			for (int i = 0; i < totalSplit; i++)
			{
				if (i == totalSplit - 1)
				{
					arrStr[i] = strLong.Substring(iStringLength, strLong.Length - iStringLength);
					break;
				}
				else {
					arrStr[i] = strLong.Substring(iStringLength, iSingleLength);
					iStringLength += iSingleLength;
				}
			}
			return arrStr;
		}



	}





}
