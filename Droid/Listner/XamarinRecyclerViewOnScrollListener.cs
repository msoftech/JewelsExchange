﻿using System;
using Android.Support.V7.Widget;

namespace JewelsExchange.Droid
{
	public class XamarinRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
	{
		public delegate void LoadMoreEventHandler(object sender, EventArgs e);
		public event LoadMoreEventHandler LoadMoreEvent;

		private LinearLayoutManager LayoutManager;

		public XamarinRecyclerViewOnScrollListener(LinearLayoutManager layoutManager)
		{
			LayoutManager = layoutManager;
		}

		public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			base.OnScrolled(recyclerView, dx, dy);

			var visibleItemCount = recyclerView.ChildCount;
			var totalItemCount = recyclerView.GetAdapter().ItemCount;
			var pastVisiblesItems = LayoutManager.FindFirstVisibleItemPosition();

			if ((visibleItemCount + pastVisiblesItems) >= totalItemCount)
			{
				LoadMoreEvent(this, null);
			}
		}
	}
}