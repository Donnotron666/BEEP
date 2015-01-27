using System;
using Common.Core.Application;
using Common.Core.Net.Requests;

namespace Mobile.Core.Application.States
{
	public class LoadUserDataState : AppState
	{
		private bool gotData = false;

		public LoadUserDataState (IBeepApp app) : base(app)
		{
		}


		public override bool IsComplete ()
		{
			return gotData;
		}

		public override void Start ()
		{
			gotData = false;
			var req = new PatchesForInstrumentRequest (this.App.Framework.UserId, OnPatchesSuccess, null);
			this.App.Framework.ExecuteRequest (req);
		}

		private void OnPatchesSuccess(PatchesForInstrumentResponse response)
		{
			gotData = true;
		}

		public override void End ()
		{

		}

	}
}

