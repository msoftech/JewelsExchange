
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using JewelsExchange.Webservices;
namespace JewelsExchange.Droid
{
	public class DefaultActivity : Fragment
	{
		private ResultJewelryAdapter mAdapter;
		private RecyclerView mRecyclerView;
		WebDataModel<ResultJewelry> viewModel;
		View view;
		Boolean isLoading = false;

			//private static string[] MOVIES = new String[]{
			//           "Black: Angel of Death",
			//           "20 Once Again",
			//           "Taken 3",
			//           "Tevar",
			//           "I",
			//           "Blackhat",
			//           "Spare Parts",
			//           "The Wedding Ringer",
			//           "Ex Machina",
			//           "Mortdecai",
			//           "Strange Magic",
			//           "The Boy Next Door",
			//           "The SpongeBob",
			//           "Kingsman",
			//           "Mystical Winter",
			//           "Project Almanac",
			//           "Yennai Arindhaal",
			//           "Shaun the Sheep",
			//           "Jupiter Ascending",
			//           "Old Fashioned",
			//           "A la mala",
			//           "Focus",
			//           "The Lazarus Effect",
			//           "Chappie",
			//           "Faults",
			//           "Road Hard",
			//           "Unfinished Business",
			//           "Cinderella",
			//           "NH10",
			//           "Run All Night",
			//           "X+Y",
			//           "Furious 7",
			//           "Danny Collins",
			//           "Do You Believe?",
			//           "Jalaibee",
			//           "The Divergent Series: Insurgent",
			//           "The Gunman",
			//           "Get Hard",
			//           "Home"
			//   };

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			view = inflater.Inflate(Resource.Layout.layout_recyclerview, container, false);
			viewModel = new WebDataModel<ResultJewelry>();

			mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
			if (mRecyclerView != null)
			{
				mRecyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager(Activity);

				var onScrollListener = new XamarinRecyclerViewOnScrollListener(layoutManager);
				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) =>
				{
					
					int totalItems = mRecyclerView.GetAdapter().ItemCount;
					loadData("AF MAN01", totalItems, (totalItems + 10), "n", false);
				};

				mRecyclerView.AddOnScrollListener(onScrollListener);

				mRecyclerView.SetLayoutManager(layoutManager);


				List<ResultJewelry> mModels = new List<ResultJewelry>();
				//ObservableCollection<ResultJewelry> wDatas = new ObservableCollection<ResultJewelry>();

				        //for (String movie : MOVIES) {
				        //    mModels.add(new ResultJewelryModel(movie));
				        //}

				//foreach (string movie in MOVIES)
				//{
				//	mModels.Add(new ResultJewelryModel(movie));
				//}
				 //viewModel.GetWebDataTask("http://montemagno.com/monkeys.json");

				//ObservableCollection<ResultJewelry> wDatas = viewModel.wDatas;


				mAdapter = new ResultJewelryAdapter(view.Context, mModels, mRecyclerView);
				mRecyclerView.SetAdapter(mAdapter);

				loadData("AF MAN01", 0, 10, "n", false);


			}
			return view;
		}

		private  void loadData(String LoggedCompanyCode, int StartRow, int EndRow, String closeout, Boolean showProgressMiddle) {


			if (isLoading == true) return;

			List<ResultJewelry> localModels = new List<ResultJewelry>();
			localModels.Add(null);
			mAdapter.addMany(localModels);
			mAdapter.NotifyItemInserted(mAdapter.ItemCount - 1);

			//string functionName = "_getGoldStockListJSON";
			isLoading = true;
			//await viewModel.GetWebDataTask("http://montemagno.com/monkeys.json");
			var urlParam = new Dictionary<string, string>();
			urlParam.Add("@CompanyCode",LoggedCompanyCode);
			urlParam.Add("@isCloseOut",closeout);
			urlParam.Add("@StartRow",StartRow.ToString());
			urlParam.Add("@EndRow",EndRow.ToString());

			 viewModel.GetWebDataTask(resultCompletion, _webFunction.GET_GOLD_STOCKS, urlParam);
		}

		void resultCompletion(ObservableCollection<ResultJewelry> wDatas)
		{
			if (wDatas == null)
				Toast.MakeText(this.Context, Resource.String.no_internet, ToastLength.Short).Show();
			else if (wDatas.Count == 0){
				mAdapter.removeLoadingView();
				isLoading = false;
				Toast.MakeText(this.Context, Resource.String.no_more_data, ToastLength.Short).Show();
			}

			else {
				mAdapter.removeLoadingView();

				List<ResultJewelry> mModels = new List<ResultJewelry>(wDatas);

				isLoading = false;

				if (mAdapter.ItemCount == 0)
				{
					mAdapter = new ResultJewelryAdapter(view.Context, mModels, mRecyclerView);
					mRecyclerView.SetAdapter(mAdapter);
				}
				else { 
					mAdapter.addMany(mModels);
					mAdapter.NotifyDataSetChanged();
					isLoading = false;
				}
			}
				
			}
			//Console.WriteLine("asfadsf");


			//mModels.add(new FirstActivityModel(valMap.get(Common.EMAIL), valMap.get(Common.COMPANY_NAME), valMap.get(Common.KARAT), valMap.get(Common.WEIGHT_GMS), valMap.get(Common.CURRENCY), valMap.get(Common.JEWELCATEGORYNAME), valMap.get(Common.JEWEKBASEDESCNAME), valMap.get(Common.MAKING_CHARGES_GM), valMap.get(Common.STOCK_NO), valMap.get(Common.COMPANYCODE)));



		}

		

	}

