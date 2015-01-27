using System;
using Common.Core.Application;
using MonoTouch.UIKit;
using Common.Data;
using Common.Data.Loaders;
using Common.Logging;
using Common.Core.Net;
using Mobile.Core.Application.States;
using System.Threading;
using System.Collections.Generic;

namespace Mobile.Core.Application
{
	public class MobileBeepApp : UIApplicationDelegate, IBeepApp
	{
		public static DataStore DataStore { get; set; }

		Logger Log = LogManager.Create("MobileBeepApp");

		public StateMachine StateMachine { get; private set; }
		public Framework Framework {get;private set;}

		private Thread UpdateThread;
		private ThreadWorker Worker;

		private List<ITickable> UpdateObjects = new List<ITickable> ();

		public MobileBeepApp ()
		{
			Worker = new ThreadWorker (Tick);
			UpdateThread = new Thread (Worker.Start);
			UpdateThread.Start ();

			Framework = new Framework ();
			StateMachine = new StateMachine ();

			Settings.AbsoluteDataPath = "/Users/donaldbellenger/Documents/BEEP-master/BEEP/BEEP/Data/";

		}


		public void StartStateMachine()
		{
			StateMachine.Add (new LoginState(this));
			StateMachine.Add (new LoadUserDataState (this));
			StateMachine.Add (new LoadStaticDataState (this));
			StateMachine.Add (new AwakeState (this));
			StateMachine.Add (new KillState (this));

			StateMachine.Start ();

			UpdateObjects.Add (StateMachine);

		}

		private void Tick()
		{
			foreach (var obj in UpdateObjects)
				obj.Tick ();
		}


	}
	public class ThreadWorker
	{
		private volatile bool running;
		private Action UpdateAction;

		public ThreadWorker(Action updateAction)
		{
			UpdateAction = updateAction;
		}

		public void Start()
		{
			running = true;
			while (running) {
				UpdateAction ();
				Thread.Sleep (10);
			}
		}
		public void Stop()
		{
			running = false;
		}
	}
}

