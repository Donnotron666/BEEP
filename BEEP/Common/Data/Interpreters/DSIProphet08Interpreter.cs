using System;
using System.Collections.Generic;
using Common.Core.IO;

namespace Common.Data.Interpreters
{
	public class DSIProphet08Interpreter : IInterpreter
	{
		public DSIProphet08Interpreter ()
		{
		}

		#region IInterpreter implementation

		public PatchData Interpret(byte[] bytes)
		{
			return null;
		}

		public PatchData Interpret(SysExStream sysEx)
		{
			//temp attribute placeholder!!
			var dict = new Dictionary<string, object> ();
			//we expect 439 bytes of patch data after the first 6 hex bytes.
			var start = sysEx.ReadByte ();
			var ManufacturerId = sysEx.ReadByte ();
			var DeviceId = sysEx.ReadByte ();
			var ProgramData = sysEx.ReadByte (); //???
			var BankNumber = sysEx.ReadByte ();
			var programNumber = sysEx.ReadByte ();
			var patchData = sysEx.ReadBlock (439);
			var endProgram = sysEx.ReadString ();
			//endProgram should == 0xF7
			return null;
		}

		#endregion
	}
}

