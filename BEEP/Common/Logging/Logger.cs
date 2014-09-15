using System;

namespace Common.Logging
{
	public class Logger
	{

		string LogName;
		ILogTarget[] Targets;

		public Logger (string logName, ILogTarget[] targets)
		{
			this.LogName = logName;
			Targets = targets;
		}

		public void Log(string msg)
		{
			foreach (var target in Targets) {
				target.Log (string.Format("[{0}]: {1}", LogName, msg));
			}
		}

		public void Log(string msg, params object[] args)
		{
			msg = String.Format (msg, args);

			foreach (var target in Targets) {
				target.Log (string.Format("[{0}]: {1}", LogName, msg));
			}
		}

	}
}

