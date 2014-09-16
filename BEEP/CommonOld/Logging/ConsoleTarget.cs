using System;

namespace Common.Logging
{
	public class ConsoleTarget : ILogTarget
	{
		public ConsoleTarget ()
		{
		}

		public void Log(string msg)
		{
			Console.WriteLine (msg);
		}
	}
}

