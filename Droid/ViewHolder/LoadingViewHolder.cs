using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace JewelsExchange.Droid
{
	public class LoadingViewHolder : RecyclerView.ViewHolder
	{
		public ProgressBar progressBar;

		public LoadingViewHolder(View itemView) : base(itemView)
		{
			
			progressBar = itemView.FindViewById<ProgressBar>(Resource.Id.progressBar1);
		}
	}
}
