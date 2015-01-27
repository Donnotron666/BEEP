using System;
using Common.Core.Application;
using Common.Core.Net.Requests;

namespace Mobile.Core.Application.States
{
	public class LoginState : AppState
	{
		private bool didLogin = false;

		public LoginState (IBeepApp app) : base(app)
		{
		}


		public override bool IsComplete ()
		{
			return didLogin;
		}

		public override void Start ()
		{
			didLogin = false;
			var req = new LoginRequest (OnLoginSucc, null);
			App.Framework.ExecuteRequest(req);
		}

		private void OnLoginSucc(LoginResponse response)
		{
			response.Framework.InitUserSerssion(
				response.userId,
				response.Response.Headers [LoginRequest.COOKIE_ID]
			);
			didLogin = true;
		}

		public override void End ()
		{
		}

	}
}

