using System;
using System.Collections.Generic;

namespace Common.Core.IO
{
	public class SysExStream
	{
		public int Position = 0;
		private byte[] bytes;

		public SysExStream ()
		{
		}

		public SysExStream(byte[] inBytes) : this()
		{
			bytes = inBytes;
		}

		public byte ReadByte(){
			return bytes [Position++];
		}

		public byte[] ReadBlock(int count)
		{
			byte[] buffer = new byte[count];
			Buffer.BlockCopy (bytes, Position, buffer, 0, count);
			Position += count;
			return buffer;
		}


		public string ReadString()
		{
			return string.Format ("{0:x2}", bytes[Position++]);
		}
	}
}

