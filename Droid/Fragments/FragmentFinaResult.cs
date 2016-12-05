
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;

namespace JewelsExchange.Droid
{
	public class FragmentFinaResult : Fragment
	{
		View v;
		CollapsingToolbarLayout collapsingToolbarLayout;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			v = inflater.Inflate(Resource.Layout.fragment_stock_details, container, false);
			collapsingToolbarLayout = v.FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar_layout);
			collapsingToolbarLayout.SetTitle("~");

			MainActivity myActivity = (MainActivity)v.Context;

			Toolbar rootToolbar = myActivity.FindViewById<Toolbar>(Resource.Id.toolbar);
			rootToolbar.Visibility = ViewStates.Gone;

			Toolbar toolbar = v.FindViewById<Toolbar>(Resource.Id.toolbar); //findViewById(R.id.toolbar);
			AppCompatActivity activity = (AppCompatActivity)myActivity;
			activity.SetSupportActionBar(toolbar);
			activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			activity.SupportActionBar.SetDisplayShowHomeEnabled(true);

			activity.SupportActionBar.SetHomeAsUpIndicator(getColoredArrow());

			//setHasOptionsMenu(true);

			return v;
		}

		private Drawable getColoredArrow()
		{ 
			Drawable arrowDrawable = Resources.GetDrawable(Resource.Drawable.abc_ic_ab_back_material); //abc_ic_ab_back_mtrl_am_alpha
			Drawable wrapped = DrawableCompat.Wrap(arrowDrawable);

			if (arrowDrawable != null && wrapped != null)
			{
				// This should avoid tinting all the arrows
				arrowDrawable.Mutate();
				DrawableCompat.SetTint(wrapped, Color.Gray);
			}
			return wrapped;
		}
	}
}
