using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Core.Reflection
{
	public static class ReflectionUtils
	{
		public static List<Type> SubClassesOfAbstract(Type type)
		{
			List<Type> ret = new List<Type> ();

			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies ().SelectMany (p => p.GetTypes ());
			foreach (Type t in types) {

				if (type.IsAssignableFrom (t) && !t.IsAbstract) {
					ret.Add (t);
				}
			}

			return ret;

		}

		public static List<Type> ImplementersOfInterface(Type type)
		{
			List<Type> ret = new List<Type> ();

			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies ().SelectMany (p => p.GetTypes ());
			foreach (Type t in types) {

				if (type.IsAssignableFrom (t) && !t.IsAbstract) {
					ret.Add (t);
				}
			}

			return ret;

		}
	}
}

