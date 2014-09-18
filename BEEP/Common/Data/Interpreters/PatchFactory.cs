using System;
using System.Collections.Generic;
using Common.Core.Reflection;

namespace Common.Data.Interpreters
{
	public static class PatchFactory
	{
		static Dictionary<string, Type> InterpreterTable;
		static Dictionary<Type, IInterpreter> InstanceTable;

		static PatchFactory ()
		{
			InterpreterTable = new Dictionary<string, Type> ();
			var types = ReflectionUtils.ImplementersOfInterface (typeof(IInterpreter));
			foreach (var t in types) {
				InterpreterTable.Add (t.Name, t);
			}


		}

		static PatchData Create(string interpreterType, byte[] data)
		{
			Type type = InterpreterTable [interpreterType];
			if (!InstanceTable.ContainsKey (type)) {
				IInterpreter instance = Activator.CreateInstance (type) as IInterpreter;
				InstanceTable.Add (type, instance);
			}

			IInterpreter interpreter = InstanceTable [type];
			return interpreter.Interpret (new Common.Core.IO.SysExStream(data));
		}
	}
}

