using System;
using System.IO;
using Common.Data.Loaders;

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

	}
}

