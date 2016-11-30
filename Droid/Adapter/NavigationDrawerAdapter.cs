
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace JewelsExchange.Droid
{
	
	public class NavigationDrawerAdapter : RecyclerView.Adapter //<NavigationDrawerAdapter.MyViewHolder>
	{
		List<NavDrawerItem> data = new List<NavDrawerItem>();
		private LayoutInflater inflater;
		private Context context;

		public NavigationDrawerAdapter(Context context, List<NavDrawerItem> data)
		{
			this.context = context;
			inflater = LayoutInflater.From(context);
			this.data = data;
		}

		public override int ItemCount => data.Count;
		//{
		//	get
		//	{
		//		//throw new NotImplementedException();
		//		 data.Count()
		//	}
		//}

		 class MyViewHolder : RecyclerView.ViewHolder
		{
			//public TextView title;
			public TextView title { get; private set; }

		public MyViewHolder(View itemView): base(itemView)
		{
			//base.(itemView);
			//title = (TextView)itemView.findViewById(R.id.title);
			title = itemView.FindViewById<TextView>(Resource.Id.title);
		}
	}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			//throw new NotImplementedException();

			NavDrawerItem current = data[position];

			MyViewHolder myHolder = holder as MyViewHolder;
			//myHolder.title.setText(current.getTitle());
			myHolder.title.Text = current.getTitle();
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			throw new NotImplementedException();

		}
	}
}
