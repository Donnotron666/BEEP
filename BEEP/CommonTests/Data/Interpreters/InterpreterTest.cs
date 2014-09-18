using System;
using System.IO;
using Common.Data.Loaders;
using Common.Data;
using Common;
using Common.Core.IO;

namespace CommonTests.Data.Interpreters
{
	public class InterpreterTest
	{
		public InterpreterTest ()
		{

		}

		public byte[] LoadBytes(string path)
		{
			return new PatchLoader (path).GetBytes ();
		}

		public SysExStream LoadHex(string path)
		{
			return new PatchLoader (path).GetHex ();
		}

	}
}

