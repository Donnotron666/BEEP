using System;
using System.Collections.Generic;
using Common.Logging;

namespace Common.Core.Application
{
	public class StateMachine : ITickable
	{
		Logger Log = LogManager.Create("StateMachine");

		private List<AppState> States = new List<AppState>();
		private int StateIndex = 0;

		private AppState CurrentState { get { return States [StateIndex]; } }

		public StateMachine ()
		{

		}
		public void Add(AppState state)
		{
			States.Add (state);
		}
		public void Start()
		{
			StateIndex = 0;
			CurrentState.Start ();
		}


		public void Tick()
		{
			if (CurrentState.IsComplete ()) {
				CurrentState.End ();

				StateIndex++;
				if (CurrentState != null) {
					CurrentState.Start ();
				} else {
					Log.Log ("Ran into a null state, this is really bad!");
				}
			}
		}
	}
}

