using System;

namespace Common.Core.Net.Requests
{
	public abstract class FrameworkRequest
	{
		public string URI;
		public Action FailCallback;
		public Type ResponseType;

		public FrameworkRequest ()
		{
		}

		public virtual void OnSuccess(object response){}
	}

	public class FrameworkRequest<T> : FrameworkRequest where T : FrameworkResponse
	{
		public Action<T> SuccessCallback;

		public FrameworkRequest()
		{
			ResponseType = typeof(T);
		}


		public FrameworkRequest(Action<T> succCB, Action failCB)
		{
			ResponseType = typeof(T);
			this.SuccessCallback = succCB;
			this.FailCallback = failCB;
		}

		public virtual void OnSuccess (T response) {}
		public override void OnSuccess(object response)
		{
			OnSuccess (response as T);
			if(SuccessCallback != null)
				SuccessCallback (response as T);
		}
	}

	public class FrameworkResponse
	{
		public Framework Framework;
		public bool success;
		public System.Net.WebResponse Response; 
	}
}

