using System;

namespace Common.Core.Application
{
	public abstract class AppState
	{
		protected IBeepApp App;
		public AppState (IBeepApp inApp)
		{
			App = inApp;
		}
		public abstract bool IsComplete();
		public abstract void Start();
		public abstract void End ();
	}
}

