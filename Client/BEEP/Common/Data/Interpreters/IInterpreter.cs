using System;
using Common.Core.SysEx;

namespace Common.Data.Interpreters
{
	public interface IInterpreter
	{
		PatchData Interpret(SysExStream bytes);
	}
}

