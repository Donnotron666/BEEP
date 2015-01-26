using System;
using Common.Core.Application;

namespace Mobile.Core.Application.States
{
	public class AwakeState : AppState
	{
		public AwakeState (IBeepApp app) : base(app)
		{
		}


		public override bool IsComplete ()
		{
			return false;
		}

		public override void Start ()
		{
			throw new NotImplementedException ();
		}

		public override void End ()
		{
			throw new NotImplementedException ();
		}

	}
}

