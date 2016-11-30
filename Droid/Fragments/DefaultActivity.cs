
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

			var view = inflater.Inflate(Resource.Layout.layout_recyclerview, container, false);
			viewModel = new WebDataModel<ResultJewelry>();

			mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
			if (mRecyclerView != null)
			{
				mRecyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager(Activity);

				var onScrollListener = new XamarinRecyclerViewOnScrollListener(layoutManager);
				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) =>
				{
					Toast.MakeText(this.Context, "click esgesdg ewsdg weg ", ToastLength.Short).Show();
				};

				mRecyclerView.AddOnScrollListener(onScrollListener);

				mRecyclerView.SetLayoutManager(layoutManager);

				List<ResultJewelryModel> mModels = new List<ResultJewelryModel>();


				        //for (String movie : MOVIES) {
				        //    mModels.add(new ResultJewelryModel(movie));
				        //}

				//foreach (string movie in MOVIES)
				//{
				//	mModels.Add(new ResultJewelryModel(movie));
				//}
				 //viewModel.GetWebDataTask("http://montemagno.com/monkeys.json");

				//ObservableCollection<ResultJewelry> wDatas = viewModel.wDatas;


				//mAdapter = new ResultJewelryAdapter(view.Context, mModels, mRecyclerView);
				//mRecyclerView.SetAdapter(mAdapter);


			}
			return view;
		}

		private void loadData(String LoggedCompanyCode, int StartRow, int EndRow, String closeout, Boolean showProgressMiddle) {

			string functionName = "_getGoldStockListJSON";

			//await viewModel.GetWebDataTask("http://montemagno.com/monkeys.json");
		
		}
		}
	}

