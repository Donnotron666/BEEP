using System;
using Common.Core.Net.Requests;
using System.Net;

using BeepRequest = Common.Core.Net.Requests.WebRequest;
using WebRequest = System.Net.WebRequest;
using Common.Logging;

namespace Common.Core.Net
{
	public class Framework
	{
		public string SessionToken;
		private Logger Log = LogManager.Create ("Framework");

		public Framework ()
		{
		}

		public void ExecuteRequest(BeepRequest req)
		{
			var http = WebRequest.Create ("http://localhost:9000/" + req.URI);
			var response = http.GetResponse ();
			var dataStream = response.GetResponseStream ();
			int length = (int)response.ContentLength;
			byte[] readBuffer = new byte[length];
			dataStream.Read (readBuffer, 0, length);
			string result = System.Text.Encoding.UTF8.GetString (readBuffer);

			Log.Log (result);

		}


	}
}

