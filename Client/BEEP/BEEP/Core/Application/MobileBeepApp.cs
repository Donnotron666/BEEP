using System;
using Common.Core.Application;
using MonoTouch.UIKit;
using Common.Data;
using Common.Data.Loaders;
using Common.Logging;

namespace Mobile.Core.Application
{
	public class MobileBeepApp : UIApplicationDelegate, IBeepApp
	{
		public static DataStore DataStore { get; set; }

		Logger Log = LogManager.Create("MobileBeepApp");

		public MobileBeepApp ()
		{

			Settings.AbsoluteDataPath = "/Users/donaldbellenger/Documents/BEEP-master/BEEP/BEEP/Data/";

		}

		#region BeepApp implementation

		public void InitAllData()
		{

			DataStore = DataStore.Instance;
			Log.Log ("Loading Instrument Data");
			new XMLLoader<InstrumentData> ("Instruments.xml").LoadIntoDataStore(DataStore);

			Log.Log ("Loading Manufacturer Data");
			new XMLLoader<ManufacturerData> ("Manufacturers.xml").LoadIntoDataStore(DataStore);

			Log.Log ("{0} Items loaded into DataStore", DataStore.Count);	
		}

		public void InitUserSettings()
		{

		}

		public void LoadUserData()
		{

		}
		#endregion
	}
}

