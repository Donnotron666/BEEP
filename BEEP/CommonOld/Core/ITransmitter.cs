using System;

namespace Common.IO
{
	public interface ITransmitter
	{
		void SendOne();
		void ReceiveOne();
		void SendMany();
		void ReceiveMany();
	}
}

