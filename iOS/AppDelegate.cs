﻿using System;
using Foundation;
using Quickblox.Sdk.Modules.ChatXmppModule;
using ToastIOS;
using UIKit;

namespace JewelsExchange.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;// = new UIWindow(UIScreen.MainScreen.Bounds);
			
		//public static event EventHandler RowHeight = delegate { };
		public override UIWindow Window
		{
			get;
			set;
		}


		void onMessageReceiveStatus(MessageEventArgs messageEventArgs)
		{
		}

		void onErrorMessage(String error)
		{
			//Toast.MakeText(this, error, ToastLength.Short).Show();
			Toast.MakeText(error, Toast.LENGTH_SHORT).SetUseShadow(true).SetFontSize(13).SetGravity(ToastGravity.Center).SetBgRed(30).Show();
		}

		//UINavigationController navController;
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			
			window = new UIWindow(UIScreen.MainScreen.Bounds);

		var storyboard = UIStoryboard.FromName("Main", null);
		
			NSUserDefaults.StandardUserDefaults.SetBool(false, "LoggedIn");


 			if (NSUserDefaults.StandardUserDefaults.BoolForKey("LoggedIn") == false)
			{

				NSUserDefaults.StandardUserDefaults.SetString("", "CompletedStep");

				if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep") == null || NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep") == "")
				{
					//ViewController_Ins_Agree controller = storyboard.InstantiateViewController("ViewController_Ins_Agree") as ViewController_Ins_Agree;
					ViewController_Ins_Register controller = storyboard.InstantiateViewController("ViewController_Ins_RegisterWhole") as ViewController_Ins_Register;
					//ViewController_Chat controller = storyboard.InstantiateViewController("ViewController_Chat") as ViewController_Chat;
					//ViewController_Ins_Types controller = storyboard.InstantiateViewController("ViewController_Ins_Types_WW") as ViewController_Ins_Types;

					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}

				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep") == "Agree")
				{
					ViewController_Ins_Types controller = storyboard.InstantiateViewController("ViewController_Ins_Types") as ViewController_Ins_Types;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}

				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep").ToString() == "Types")
				{
					ViewController_Ins_Contact controller = storyboard.InstantiateViewController("ViewController_Ins_Contact") as ViewController_Ins_Contact;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep").ToString() == "Contact")
				{
					//ViewController_Ins_OTP controller = storyboard.InstantiateViewController("ViewController_Ins_OTP") as ViewController_Ins_OTP;
					ViewController_Ins_Contact controller = storyboard.InstantiateViewController("ViewController_Ins_Contact") as ViewController_Ins_Contact;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep").ToString() == "OTP")
				{
					ViewController_Ins_Details controller = storyboard.InstantiateViewController("ViewController_Ins_Details") as ViewController_Ins_Details;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep").ToString() == "Details")
				{
					ViewController_Ins_Register controller = storyboard.InstantiateViewController("ViewController_Ins_Register") as ViewController_Ins_Register;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}
				else if (NSUserDefaults.StandardUserDefaults.StringForKey("CompletedStep").ToString() == "CompanyRegistered")
				{
					ViewController_Ins_Types controller = storyboard.InstantiateViewController("ViewController_Ins_Types_WW") as ViewController_Ins_Types;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}

				else
				{
					ViewController_Ins_Agree controller = storyboard.InstantiateViewController("ViewController_Ins_Agree") as ViewController_Ins_Agree;
					window.RootViewController = controller;
					window.MakeKeyAndVisible();
				}
			
			}
			else
			{
				//UINavigationController ctrl = new UINavigationController();
				//ViewController_Home controller = storyboard.InstantiateViewController("ViewController_Home") as ViewController_Home;
				//ctrl.PushViewController(controller, true);
				//window.RootViewController = ctrl;
				//window.MakeKeyAndVisible();

				//UINavigationController ctrl = new UINavigationController();
				//ViewController_Home controller = storyboard.InstantiateViewController("ViewController_Home") as ViewController_Home;
				ViewController_Stock controller = storyboard.InstantiateViewController("ViewController_Stock_menu") as ViewController_Stock;
			//	ctrl.PushViewController(controller, true);
				window.RootViewController = controller;//ctrl;
				window.MakeKeyAndVisible();
			}
			return true;
		}



		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

