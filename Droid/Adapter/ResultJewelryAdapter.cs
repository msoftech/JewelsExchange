using System;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using System.Collections;

namespace JewelsExchange.Droid
{
	public class ResultJewelryAdapter : RecyclerView.Adapter{

		private readonly LayoutInflater mInflater;
		private readonly List<ResultJewelryModel> mModels;
		private readonly int VIEW_TYPE_ITEM = 0;
		private readonly int VIEW_TYPE_LOADING = 1;
		private OnLoadMoreListener mOnLoadMoreListener;

		private Boolean isLoading;
		private int visibleThreshold = 5;
		private int lastVisibleItem, totalItemCount;

		public ResultJewelryAdapter(Context context, List<ResultJewelryModel> models, RecyclerView mRecyclerView)
		{
			mInflater = LayoutInflater.From(context);
			mModels = new  List<ResultJewelryModel>(models);
			//LinearLayoutManager linearLayoutManager = (LinearLayoutManager)mRecyclerView.GetLayoutManager();
			//mrecyclerView.AddOnScrollListener(onScrollListener);
		}

		public override int GetItemViewType(int position)
		{
			return mModels[position] == null ? VIEW_TYPE_LOADING : VIEW_TYPE_ITEM;//base.GetItemViewType(position);
		}

		public override int ItemCount
		{
			get
			{
				return mModels == null ? 0 : mModels.Count;
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			if (holder is ResultViewHolder) {
				ResultJewelryModel model = mModels[position];
				ResultViewHolder exholder = (ResultViewHolder)holder;
				exholder.bind(model, holder.ItemView.Context);
			}else if (holder is LoadingViewHolder) {
				LoadingViewHolder loadingViewHolder = (LoadingViewHolder)holder;
				loadingViewHolder.progressBar.Indeterminate = true;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			if (viewType == VIEW_TYPE_ITEM)
			{
				View itemView = mInflater.Inflate(Resource.Layout.row_result, parent, false);
				return new ResultViewHolder(itemView);
			}
			else if (viewType == VIEW_TYPE_LOADING)
			{
				View itemView = mInflater.Inflate(Resource.Layout.layout_loading_item, parent, false);
				//            View view = LayoutInflater.from(MainActivity.this).inflate(R.layout.layout_loading_item, parent, false);
				return new LoadingViewHolder(itemView);
			}
			return null;
		}

	}
}
