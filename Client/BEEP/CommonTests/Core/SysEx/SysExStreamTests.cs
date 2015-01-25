using System;
using NUnit.Framework;
using Common.Core.SysEx;
using System.Collections.Generic;

namespace CommonTests.Core.SysEx
{

	[TestFixture()]
	public class SysExStreamTests
	{
		[Test()]
		public void TestMSByteDecoding()
		{
			byte[] bytes = new byte[]{
				0, 77, 67, 57, 47, 37, 27, 17,
				0, 16, 15, 14, 13, 12, 11, 10,
				0, 26, 25, 24, 23, 22, 21, 20,
				0, 36, 35, 34, 33, 32, 31, 30,
				0, 46, 45, 44, 43, 42, 41, 40,
				0, 56, 55, 54, 53, 52, 51, 50,
				0, 66, 65, 64, 63, 62, 61, 60,
				0, 76, 75, 74, 73, 72, 71, 70
			};

			byte[] shouldDecodeTo = new byte[] {
				17, 16, 15, 14, 13, 12, 11, 10,
				27, 26, 25, 24, 23, 22, 21, 20,
				37, 36, 35, 34, 33, 32, 31, 30,
				47, 46, 45, 44, 43, 42, 41, 40,
				57, 56, 55, 54, 53, 52, 51, 50,
				67, 66, 65, 64, 63, 62, 61, 60,
				77, 76, 75, 74, 73, 72, 71, 70
			};

			var stream = new SysExStream (bytes);
			byte[] decoded = stream.ReadMSBytePacket ();

			Assert.True (decoded.Length == shouldDecodeTo.Length);


			bool didMatch = true;
			for (int i = 0; i < decoded.Length; i++) {
				if (decoded [i] != shouldDecodeTo [i]) {
					didMatch = false;
					break;
				}

			}
			Assert.True (didMatch);

		}

		[Test()]
		public void TestMSByteEncoding()
		{
		}


		[Test()]
		public void TestMSBitDecoding()
		{
			byte[] bytes = new byte[]{
				0x7F,
				0,
				0, 
				0, 
				0, 
				0, 
				0, 
				0, 
			};



			byte[] shouldDecodeTo = new byte[] {
				0x80,
				0x80,
				0x80,
				0x80,
				0x80,
				0x80,
				0x80
			};

			var stream = new SysExStream (bytes);
			var decoded = stream.ReadMSBitPacket ();
			Assert.True (decoded.Length == shouldDecodeTo.Length, "MSBit decoding returned the wrong length");

			bool identical = true;
			for (int i = 0; i < decoded.Length; i++) {
				if (decoded [i] != shouldDecodeTo [i]) {
					identical = false;
					break;
				}
			}

			Assert.True (identical, "MSBit decoding came back with something unexpected");

		}


		[Test()]
		public void NormalReadBlock()
		{
			List<byte> byteList = new List<byte>();
			for (int i = 0; i < 100; i++) {
				byteList.Add(0x7F);
			}

			var stream = new SysExStream (byteList.ToArray ());

			var bytesBack = stream.ReadBlock (byteList.Count, SysExStream.BitPackingMode.Normal);
			Assert.True (bytesBack.Length == byteList.Count, "Got wrong number of bytes back on read block");

			int count = bytesBack.Length;
			bool ioValid = true;
			while (count > 0) {
				if (bytesBack.ReadByte () != 0x7f) {
					ioValid = false;
					break;
				}

				count--;
			}
			Assert.True (ioValid, "Input bytes didn't match output bytes!!");


		}

		[Test()]
		public void MSBReadBlock()
		{
			int writeCount = 10;

			List<byte> byteList = new List<byte>();
			for (int i = 0; i < (writeCount); i++) {
				byteList.Add(0x7F);
				byteList.Add(0x0);
				byteList.Add(0x0);
				byteList.Add(0x0);
				byteList.Add(0x0);
				byteList.Add(0x0);
				byteList.Add(0x0);
				byteList.Add(0x0);

			}

			var stream = new SysExStream (byteList.ToArray ());

			var bytesBack = stream.ReadBlock (writeCount*8, SysExStream.BitPackingMode.MSB);
			Assert.True (bytesBack.Length == (writeCount*7), "Got wrong number of bytes back on read block");

			int count = bytesBack.Length;
			bool ioValid = true;
			while (count > 0) {
				if (bytesBack.ReadByte () != 0x80) {
					ioValid = false;
					break;
				}

				count--;
			}
			Assert.True (ioValid, "Input bytes didn't match output bytes!!");
		}
	}
}

