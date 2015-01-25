﻿using System;
using System.IO;
using Common.Data.Loaders;
using Common.Data;
using Common;
using Common.Core.SysEx;

namespace CommonTests.Data.Interpreters
{
	public class InterpreterTest
	{
		public InterpreterTest ()
		{

		}

		public SysExStream LoadBytes(string path)
		{
			return new PatchLoader (path).GetBytes ();
		}


	}
}
