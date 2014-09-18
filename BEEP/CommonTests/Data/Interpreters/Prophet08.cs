using System;
using NUnit.Framework;
using Common.Data.Interpreters;

namespace CommonTests.Data.Interpreters
{
	[TestFixture()]
	public class Prophet08 : InterpreterTest
	{

		[Test()]
		public void TestRead()
		{
			var hexStream = LoadHex ("/../../../Data/Patches/1/CB_Dr3am_Arp.syx");

			var interpreter = new DSIProphet08Interpreter ();

			interpreter.Interpret (hexStream);
			Assert.True (true);
		}
	}
}

