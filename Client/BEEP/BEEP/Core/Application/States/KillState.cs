﻿using System;
using Common.Core.Application;

namespace Mobile.Core.Application.States
{
	public class KillState : AppState
	{
		public KillState (IBeepApp app) : base(app)
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

