using System;

namespace Common.Data.Interpreters
{
	public interface IInterpreter
	{
		PatchData Interpret(byte[] bytes);
	}
}

