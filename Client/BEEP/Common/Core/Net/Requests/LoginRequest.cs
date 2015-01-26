using System;

namespace Common.Core.Net.Requests
{
	public class LoginRequest : FrameworkRequest<LoginResponse>
	{
		public LoginRequest ()
		{
			this.URI = "auth";
		}

		public override void OnSuccess(LoginResponse response)
		{
			response.Framework.UserId = response.userId;
			
		}

	}

	public class LoginResponse : FrameworkResponse
	{
		public string userId;
		public string persona;
	}
}



