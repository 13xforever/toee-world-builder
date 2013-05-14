using System;
using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class GenHelperTests
	{
		[Test]
		public void ConvertBytesToStringGuid()
		{
			var guid = Guid.NewGuid();
			var guidBytes = new byte[24];
			guid.ToByteArray().CopyTo(guidBytes, 8);

			var expected = "G_" + guid.ToString("D").Replace('-', '_').ToUpper();
			Assert.That(GenHelper.ConvertBytesToStringGuid(guidBytes), Is.EqualTo(expected));
		}

		[Test]
		[TestCase(0xffffffff, Result = 0xff)]
		[TestCase(0x07f80000, Result = 0xff)] //00000|111 11111|000 00000000 00000000
		[TestCase(0x04080000, Result = 0x81)] //00000|100 00001|000 00000000 00000000
		[TestCase(0x0c0c0000, Result = 0x81)] //00001|100 00001|100 00000000 00000000
		[TestCase(0x08040000, Result = 0x00)] //00001|000 00000|100 00000000 00000000
		[TestCase(0x00000000, Result = 0x00)]
		public int GeneratorEncoderGet(long value)
		{
			return GeneratorEncoder.GenId.Get((int)value);
		}
	
		[Test]
		[TestCase(0xffffffff, 0xff, Result = 0xffffffff)]
		[TestCase(0x07f80000, 0xff, Result = 0x07f80000)] //00000|111 11111|000 00000000 00000000 ← 11111111 = 00000|111 11111|000 00000000 00000000
		[TestCase(0x07f80000, 0x00, Result = 0x00000000)] //00000|111 11111|000 00000000 00000000 ← 00000000 = 00000|000 00000|000 00000000 00000000
		[TestCase(0x04080000, 0x81, Result = 0x04080000)] //00000|100 00001|000 00000000 00000000 ← 10000001 = 00000|100 00001|000 00000000 00000000
		[TestCase(0x0c0c0000, 0x81, Result = 0x0c0c0000)] //00001|100 00001|100 00000000 00000000 ← 10000001 = 00001|100 00001|100 00000000 00000000
		[TestCase(0x08040000, 0x81, Result = 0x0c0c0000)] //00001|000 00000|100 00000000 00000000 ← 10000001 = 00001|100 00001|100 00000000 00000000
		[TestCase(0x00000000, 0x00, Result = 0x00000000)]
		[TestCase(0xaaaaaaaa, 0xaa, Result = 0xad52aaaa)] //10101|010 10101|010 10101010 10101010 ← 10101010 = 10101|101 01010|010 10101010 10101010
		[TestCase(0x55555555, 0x55, Result = 0x52ad5555)] //01010|101 01010|101 01010101 01010101 ← 01010101 = 01010|010 10101|101 01010101 01010101
		public uint GeneratorEncoderSet(long value1, long value2)
		{
			return GeneratorEncoder.GenId.Set((uint)value1, (int)value2);
		}
	}
}