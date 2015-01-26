using System;
using Common.Core.Net.Requests;
using System.Net;

using System.Xml.Serialization;
using System.Linq;
using WebRequest = System.Net.WebRequest;
using Common.Logging;

namespace Common.Core.Net
{
	public class Framework
	{
		public string SessionToken;
		public string UserId;
		
		private Logger Log = LogManager.Create ("Framework");

		public Framework ()
		{
		}

		public void ExecuteRequest(FrameworkRequest req)
		{
			var http = WebRequest.Create ("http://localhost:9000/" + req.URI);
			var response = http.GetResponse ();
		
			var ser = new XmlSerializer (req.ResponseType);
			FrameworkResponse responseObj = ser.Deserialize (response.GetResponseStream()) as FrameworkResponse;
			responseObj.Response = response;
			responseObj.Framework = this;
			req.OnSuccess (responseObj);

		}


	}
}

