using System;
using NUnit.Framework;
using Common.Data.Interpreters;
using Common.Data;

namespace CommonTests.Data.Interpreters
{
	[TestFixture()]
	public class SubPhatty : InterpreterTest
	{
		[Test()]
		public void TestRead()
		{
			byte[] bytes = LoadBytes ("/../../../Data/Patches/5/Bonobass.syx");

			var interpreter = new MoogSubPhattyInterpreter ();
			interpreter.Interpret (bytes);

			Assert.True (true);
		}
	}
}

