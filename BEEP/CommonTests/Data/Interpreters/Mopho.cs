using System;
using NUnit.Framework;
using Common.Data.Interpreters;

namespace CommonTests.Data.Interpreters
{
	[TestFixture()]
	public class Mopho : InterpreterTest
	{

		[Test()]
		public void TestRead()
		{
			var stream = LoadBytes ("/../../../Data/Patches/7/MEM_Casita_Lead.syx");

			var interpreter = new DSIMophoInterpreter ();
			interpreter.Interpret (stream);
			Assert.True (true);
		}
	}
}

