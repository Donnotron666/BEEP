using System;
using Common.Core.Net;

namespace Common.Core.Application
{
	public interface IBeepApp 
	{
		void StartStateMachine();
		Framework Framework { get; }
		StateMachine StateMachine { get; }
	}
}

