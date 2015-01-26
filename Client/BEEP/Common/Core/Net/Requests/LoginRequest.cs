using System;

namespace Common.Core.Net.Requests
{
	public class LoginRequest : WebRequest
	{
		public LoginRequest ()
		{
			this.URI = "auth";
		}


	}
}

