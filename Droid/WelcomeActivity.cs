
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace JewelsExchange.Droid
{
	[Activity(Theme = "@style/MyMaterialTheme",MainLauncher = true,Icon = "@drawable/ic_launcher", NoHistory = true)]
	public class WelcomeActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			//WebserviceTest.OnCreate(base, savedInstanceState);
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_welcome);
			//System.Threading.Thread.Sleep(3000); //Let's wait awhile...
			//this.StartActivity(typeof(MainActivity));
			Timer timer = new Timer();
			timer.Interval = 2000; // 3 sec.
			timer.AutoReset = false; // Do not reset the timer after it's elapsed
			timer.Elapsed += (object sender, ElapsedEventArgs e) =>
			{
				StartActivity(typeof(WebserviceTest));//StartActivity(typeof(MainActivity)); //StartActivity(typeof(WebserviceTest));
			};
			timer.Start();
		}

		//protected override void OnResume()
		//{
		//	base.OnResume();

		//	Task startupWork = new Task(async () =>
		//	{
		//		//Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
		//		await Task.Delay(2000);  // Simulate a bit of startup work.
		//								 //Log.Debug(TAG, "Working in the background - important stuff.");
		//	});

		//	startupWork.ContinueWith(t =>
		//	{
		//	//Log.Debug(TAG, "Work is finished - start Activity1.");
		//	StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		//	}, TaskScheduler.FromCurrentSynchronizationContext());

		//	startupWork.Start();
		//}
	}



}
