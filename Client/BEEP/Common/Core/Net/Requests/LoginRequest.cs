using System;
using System.Linq;

namespace Common.Core.Net.Requests
{

	public class LoginRequest : FrameworkRequest<LoginResponse>
	{

		public static string COOKIE_ID = "Set-Cookie";

		public LoginRequest (Action<LoginResponse> successCB, Action failCB) : base (successCB, failCB)
		{
			this.URI = "auth";
		}

	}

	public class LoginResponse : FrameworkResponse
	{
		public string userId;
		public string persona;
	}
}



