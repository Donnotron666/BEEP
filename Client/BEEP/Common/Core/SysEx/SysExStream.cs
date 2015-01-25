using System;
using System.Collections.Generic;

namespace Common.Core.SysEx
{
	public class SysExStream
	{
		public int Position = 0;
		private byte[] bytes;

		public enum BitPackingMode
		{
			Normal,
			MSB,		//Most Significant Bit. 7 bytes "compressed" to 8, -> http://en.wikipedia.org/wiki/Most_significant_bit
			//LSB			//Least Signficant Bit
		}

		public SysExStream ()
		{
		}

		public int Length
		{
			get {
				return bytes.Length;
			}
		}

		public byte this[int index]
		{
			get {
				return bytes [index];
			}
		}

		public SysExStream(byte[] inBytes) : this()
		{
			bytes = inBytes;
		}

		public byte ReadByte(){
			return bytes [Position++];
		}

		public SysExStream ReadBlock(int count, BitPackingMode mode = BitPackingMode.Normal)
		{
			byte[] buffer = null;
			if (mode == BitPackingMode.Normal) {
				buffer = new byte[count];
				Buffer.BlockCopy (bytes, Position, buffer, 0, count);
				Position += count;
			} else if( mode == BitPackingMode.MSB) {
				if (count % 8 != 0)
					throw new System.Exception ("Block count isn't divisible by 8, which is required for MSB decoding");

				buffer = new byte[count / 8 * 7];

				for (int i = 0, j = 0; i < count; i+=8, j+=7) {
					byte[] msbytes = ReadMSBitPacket ();

					Buffer.BlockCopy (msbytes, 0, buffer, j, 7);
				}
			} 

			return new SysExStream(buffer);
		}


		public byte[] ReadMSBitPacket()
		{
			byte[] ret = new byte[7];
			byte header = ReadByte ();
			//int flag = 1<<6;
			for (int i = 0; i < 7; i++) {
				byte b = ReadByte ();

				var flag = 1 << i;
				//get most significant bit from header
				int msb = (header & flag) == flag ? 1 : 0;

				//re-apply the most significant bit from the header into the byte that we're reading
				b = (byte)(b | (msb << 7));

				ret [i] = b;

			}

			return ret;
		}

		//converts an 8x8 matrix of zero-prefixed bytes to 8x7
		public byte[] ReadMSBytePacket(int packetSize = 64)
		{
			byte[] headers = new byte[8];
			packetSize -= 8;
			byte[] ret = new byte[packetSize];
			int i = 0;

			while (i < 8) {
				headers [i] = ReadByte ();
				//ret [i * 8] = ReadByte ();
				i++;
			}

			i = 0;
			int headerIndex = 7;
			while (i < packetSize) {

				if (i % 8 == 0) {
					ret [i] = headers [headerIndex];
					headerIndex--;
					//read a byte anyways
					ReadByte ();
				} else {
					ret [i] = ReadByte ();
				}

				i++;
			}

			return ret;
		}

		public string ReadString()
		{
			return string.Format ("{0:x2}", bytes[Position++]);
		}
	}
}

