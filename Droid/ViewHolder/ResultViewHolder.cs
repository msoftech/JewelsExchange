using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

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


		public void bind(ResultJewelryModel model, Context ctx)
		{
			tvCategory.Text = model.getJewelCategoryName();
			//tvSubCategory.Text = model.getJewelBaseDescName();
			////tvPlace.setText(model.get());
			//tvPrice.Text = "$" + model.getPrice();
			//tv_carrat.Text = model.getKarat();
			//tv_gm.Text = model.getWeightGms();
		}
	}
}
