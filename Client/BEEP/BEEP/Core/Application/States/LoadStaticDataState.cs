using System;
using Common.Core.Application;
using Common.Data;
using Common.Logging;
using Common.Data.Loaders;

namespace Mobile.Core.Application.States
{
	public class LoadStaticDataState : AppState
	{
		public LoadStaticDataState (IBeepApp app): base(app)
		{

		}


		public override bool IsComplete ()
		{
			return false;
		}

		Logger Log = LogManager.Create("LoadStaticDataState");

		public override void Start ()
		{
			MobileBeepApp.DataStore = DataStore.Instance;
			Log.Log ("Loading Instrument Data");
			new XMLLoader<InstrumentData> ("Instruments.xml").LoadIntoDataStore(DataStore.Instance);

			Log.Log ("Loading Manufacturer Data");
			new XMLLoader<ManufacturerData> ("Manufacturers.xml").LoadIntoDataStore(DataStore.Instance);

			Log.Log ("{0} Items loaded into DataStore", DataStore.Instance.Count);
		}

		public override void End ()
		{
			throw new NotImplementedException ();
		}

	}
}

