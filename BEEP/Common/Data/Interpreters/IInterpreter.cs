using System;
using Common.Core.IO;

namespace Common.Data.Interpreters
{
	public interface IInterpreter
	{
		PatchData Interpret(SysExStream bytes);
	}
}

