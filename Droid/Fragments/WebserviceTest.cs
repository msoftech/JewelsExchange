
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JewelsExchange.Webservices;

namespace JewelsExchange.Droid
{
	[Activity(Label = "WebserviceTest")]
	public class WebserviceTest : Activity
	{
		WebDataModel<GetDataFromWebservice> viewModel;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.test_webservice);
			viewModel = new WebDataModel<GetDataFromWebservice>();

			var btnGetData = FindViewById<Button>(Resource.Id.getData);
			var listview = FindViewById<ListView>(Resource.Id.listView);
			btnGetData.Click += async delegate {
				{
					btnGetData.Enabled = false;

					await viewModel.GetWebDataTask(resultCompletion,"http://montemagno.com/monkeys.json");

					//ObservableCollection<ResultJewelry> wDatas = viewModel.wDatas;
					ObservableCollection<GetDataFromWebservice> wDatas = viewModel.wDatas;

					//var items = JsonConvert.DeserializeObject<List<object>>(json);

					//var dictionary = JsonConvert.DeserializeObject<List<KeyValuePair<int, string>>>("")
					//			 .ToDictionary(x => x.Key, y => y.Value);

					listview.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,
																Android.Resource.Id.Text1,
					                                            viewModel.wDatas.Select(m => $"{m.Name} - from {m.Location}").ToArray());
					
					btnGetData.Enabled = true;
				}
			};
			// Create your application here
		}

		void resultCompletion(ObservableCollection<GetDataFromWebservice> wDatas) {
			Console.WriteLine("asfadsf");
		}
	}
}
