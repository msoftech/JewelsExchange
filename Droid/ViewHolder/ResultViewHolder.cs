using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Support.V4;
using Android.Views;
using Android.Widget;
using JewelsExchange.Webservices;

namespace JewelsExchange.Droid
{
	public class ResultViewHolder : RecyclerView.ViewHolder
	{
		private TextView tvCategory,tvSubCategory,tvPlace,tvPrice,tv_carrat,tv_gm;
		private	ImageView jwelImg;


		public ResultViewHolder(View itemView) : base(itemView)
			
		{
			tvCategory = itemView.FindViewById<TextView>(Resource.Id.tvCategory);
			jwelImg = itemView.FindViewById<ImageView>(Resource.Id.jwelImg);
			tvSubCategory = itemView.FindViewById<TextView>(Resource.Id.tvSubCategory);
			tvPlace = itemView.FindViewById<TextView>(Resource.Id.tvPlace);
			tvPrice = itemView.FindViewById<TextView>(Resource.Id.tvPrice);
			tv_carrat = itemView.FindViewById<TextView>(Resource.Id.tv_carrat);
			tv_gm = itemView.FindViewById<TextView>(Resource.Id.tv_gm);
		}


		public void bind(ResultJewelry model, Context ctx)
		{
			tvCategory.Text = model.JewelCategoryName;//model.getJewelCategoryName();
			tvSubCategory.Text = model.JewelBaseDescName;
			tv_carrat.Text = model.JewelMetalKaratName;
			tv_gm.Text = model.WeightGms;
			tvPrice.Text = model.CloseOutPrice;
			tvPlace.Text = model.JewelRegionName;
			//Glide.With(ctx).Load("Url")
			//	 .Placeholder(Resource.Drawable.ic_launcher)
			//	 .Into(jwelImg);
			((RelativeLayout)ItemView.FindViewById<RelativeLayout>(Resource.Id.clk_details)).Click += delegate
			{

				//Call Your Method When User Clicks The Button
				//Toast.MakeText(ctx, "click", ToastLength.Long).Show();
				MainActivity myActivity = (MainActivity)ItemView.Context;

				Android.Support.V4.App.FragmentTransaction fragmentTransaction =myActivity.SupportFragmentManager.BeginTransaction();
				FragmentFinaResult childFragment = new FragmentFinaResult();
				fragmentTransaction.Replace(Resource.Id.container_body, childFragment);
				fragmentTransaction.AddToBackStack(null);
				fragmentTransaction.Commit();
			};
		}
	}
}
