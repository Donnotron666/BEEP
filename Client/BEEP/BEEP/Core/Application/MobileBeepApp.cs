using System;
using Common.Core.Application;
using MonoTouch.UIKit;
using Common.Data;
using Common.Data.Loaders;
using Common.Logging;
using Common.Core.Net;
using Mobile.Core.Application.States;

namespace Mobile.Core.Application
{
	public class MobileBeepApp : UIApplicationDelegate, IBeepApp
	{
		public static DataStore DataStore { get; set; }

		Logger Log = LogManager.Create("MobileBeepApp");

		public StateMachine StateMachine { get; private set; }
		public Framework Framework {get;private set;}

		public MobileBeepApp ()
		{

			Framework = new Framework ();
			StateMachine = new StateMachine ();

			Settings.AbsoluteDataPath = "/Users/donaldbellenger/Documents/BEEP-master/BEEP/BEEP/Data/";

		}

		public void StartStateMachine()
		{
			StateMachine.Add (new LoginState(this));
			StateMachine.Add (new LoadStaticDataState (this));
			StateMachine.Add (new LoadUserDataState (this));
			StateMachine.Add (new AwakeState (this));
			StateMachine.Add (new KillState (this));

			StateMachine.Start ();

		}

	}
}

