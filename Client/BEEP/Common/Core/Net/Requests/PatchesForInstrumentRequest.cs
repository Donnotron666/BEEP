using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Common.Core.Net.Requests
{
	public class PatchesForInstrumentRequest : FrameworkRequest<PatchesForInstrumentResponse>
	{
		public PatchesForInstrumentRequest (string userId, Action<PatchesForInstrumentResponse> succCB, Action failCB) : base(succCB, failCB)
		{
			URI = String.Format ("user/{0}/patches", userId);
		}
	}

	public class PatchesForInstrumentResponse : FrameworkResponse
	{
		public List<Instrument> Instruments;

	}

	public class Instrument
	{
		public string DataId;
		public List<Patch> Patches;
	}

	public class Patch
	{
		public string PatchUTF;
		public string Name;
		[XmlIgnore()]
		public byte[] PatchData
		{
			get {
				return System.Text.Encoding.UTF8.GetBytes (PatchUTF);
			}
		}
	}


}

