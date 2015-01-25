using System;

namespace Common.Logging
{
	public static class LogManager
	{
		private static ILogTarget[] targets;

		static LogManager ()
		{
			targets = new ILogTarget[]{new ConsoleTarget()};
		}

		public static Logger Create(object owner)
		{
			return new Logger (owner.GetType ().Name, targets);
		}

		public static Logger Create(string name)
		{
			return new Logger (name, targets);
		}
	}
}

