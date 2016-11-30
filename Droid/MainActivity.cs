using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Views;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Content;
using Android;


namespace JewelsExchange.Droid
{
	//Arshadkr
	[Activity(Label = "MainActivity")]
	public class MainActivity : AppCompatActivity
	{
		DrawerLayout drawerLayout;
		NavigationView navigationView;
		//int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			//WebserviceTest.OnCreate(base, savedInstanceState);
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			//var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			//SetSupportActionBar(toolbar);
			//SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			//SupportActionBar.SetDisplayShowTitleEnabled(false);
			//SupportActionBar.SetHomeButtonEnabled(true);
			//SupportActionBar.SetHomeAsUpIndicator(Resource.Mipmap.Icon);
			//drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			//navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			//Enable support action bar to display hamburger
			SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_arrow_back);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

			navigationView.NavigationItemSelected += (sender, e) =>
			{
				e.MenuItem.SetChecked(true);
				//react to click here and swap fragments or navigate
				itemSelected();
				drawerLayout.CloseDrawers();
			};
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			

			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					//fragment = new DefaultActivity();
					drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
					return true;
			}
			//if (fragment != null)
			//{
			//	FragmentManager fragmentManager = getSupportFragmentManager();
			//	int backStackCount = getSupportFragmentManager()
			//			.getBackStackEntryCount();
			//}



			return base.OnOptionsItemSelected(item);
		}

		private void itemSelected()
		{
			Fragment fragment;
			Android.Support.V4.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction();
			DefaultActivity childFragment = new DefaultActivity();
			fragmentTransaction.Replace(Resource.Id.container_body, childFragment);
			fragmentTransaction.AddToBackStack(null);
			fragmentTransaction.Commit();
		}
	}
}


	//lalal


	//	public class MainActivity : AppCompatActivity
	//	{
	//		DrawerLayout drawerLayout;
	//		NavigationView navigationView;
	//		protected override void OnCreate(Bundle bundle)
	//		{
	//			base.OnCreate(bundle);
	//			SetContentView(Resource.Layout.Main);
	//			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
	//			SetSupportActionBar(toolbar);
	//			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
	//			SupportActionBar.SetDisplayShowTitleEnabled(false);
	//			SupportActionBar.SetHomeButtonEnabled(true);
	//			SupportActionBar.SetHomeAsUpIndicator(Resource.Mipmap.Icon);
	//			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
	//			navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
	//		}
	//		public override bool OnOptionsItemSelected(IMenuItem item)
	//		{
	//			switch (item.ItemId)
	//			{
	//				case Android.Resource.Id.Home:
	//					drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
	//					return true;
	//			}
	//			return base.OnOptionsItemSelected(item);
	//		}
	//	}
	//}


	//looo
