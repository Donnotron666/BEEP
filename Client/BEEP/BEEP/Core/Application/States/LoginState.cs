using System;
using Common.Core.Application;
using Common.Core.Net.Requests;

namespace Mobile.Core.Application.States
{
	public class LoginState : AppState
	{
		public LoginState (IBeepApp app) : base(app)
		{
		}


		public override bool IsComplete ()
		{
			return false;
		}

		public override void Start ()
		{
			var req = new LoginRequest ();
			App.Framework.ExecuteRequest (req);
		}

		public override void End ()
		{
		}

	}
}

