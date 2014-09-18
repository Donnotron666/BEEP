using System;
using NUnit.Framework;
using Common.Data.Interpreters;
using Common.Data;
using Common.Core.IO;

namespace CommonTests.Data.Interpreters
{
	[TestFixture()]
	public class SubPhatty : InterpreterTest
	{
		[Test()]
		public void TestRead()
		{
			SysExStream stream = LoadBytes ("/../../../Data/Patches/5/Bonobass.syx");

			var interpreter = new MoogSubPhattyInterpreter ();
			interpreter.Interpret (stream);

			Assert.True (true);
		}
	}
}

