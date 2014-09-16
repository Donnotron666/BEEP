using System;

namespace Common.Data
{
	public class PatchData : BasicData
	{
		public string PatchName;
		public int SysExId;

		public PatchType TypeFlags;

		public PatchData ()
		{
		}
	}


	[System.Flags]
	public enum PatchType
	{
		Lead,
		Bass,
		Pad,
		FX,
		Percussion,


	}

}

