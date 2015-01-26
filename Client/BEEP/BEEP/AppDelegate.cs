using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Common.Data;
using Mobile.Core.Application;
using Mobile.UI;

namespace Mobile
{

	[Register ("AppDelegate")]
	public partial class AppDelegate : MobileBeepApp
	{
		// class-level declarations
		UIWindow window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			StartStateMachine ();
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var controller = new NavigationController ();
			controller.PushViewController (new RootViewController (), false);
			// If you have defined a root view controller, set it here:
			window.RootViewController = controller;
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

